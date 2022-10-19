namespace CSharpCredentialProvider
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using CredentialProvider.Interop;

    [ComVisible(true)]
    [Guid(Constants.CredentialProviderUID)]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Rebootify.TestWindowsCredentialProvider")]
    public class CSharpSampleProvider : ICharpSampleProvider
    {
        private _CREDENTIAL_PROVIDER_USAGE_SCENARIO _cpus = _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_INVALID;
        private ICredentialProviderUserArray _pCredProviderUserArray = null;
        private CSharpSampleCredential _pCredential = null;
        private bool _fRecreateEnumeratedCredentials = false;


        public CSharpSampleProvider()
        {
            Log.LogText("TestWindowsCredentialProvider: Created object");
        }

        // SetUsageScenario is the provider's cue that it's going to be asked for tiles
        // in a subsequent call.
        public int SetUsageScenario(_CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, uint dwFlags)
        {
            Log.LogMethodCall();

            int hr = HResultValues.S_OK;
            // Decide which scenarios to support here. Returning E_NOTIMPL simply tells the caller
            // that we're not designed for that scenario.
            switch (cpus)
            {               
                case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_LOGON:
                case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_UNLOCK_WORKSTATION:
                    // The reason why we need _fRecreateEnumeratedCredentials is because ICredentialProviderSetUserArray::SetUserArray() is called after ICredentialProvider::SetUsageScenario(),
                    // while we need the ICredentialProviderUserArray during enumeration in ICredentialProvider::GetCredentialCount()
                    _cpus = cpus;
                    _fRecreateEnumeratedCredentials = true;
                    hr = HResultValues.S_OK;
                    break;
                case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_CHANGE_PASSWORD:
                case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_CREDUI:
                    hr = HResultValues.E_NOTIMPL;
                    break;                    
                default:
                    hr = HResultValues.E_INVALIDARG;
                    break;
            }

            return hr;
        }

        // SetSerialization takes the kind of buffer that you would normally return to LogonUI for
        // an authentication attempt.  It's the opposite of ICredentialProviderCredential::GetSerialization.
        // GetSerialization is implement by a credential and serializes that credential.  Instead,
        // SetSerialization takes the serialization and uses it to create a tile.
        //
        // SetSerialization is called for two main scenarios.  The first scenario is in the credui case
        // where it is prepopulating a tile with credentials that the user chose to store in the OS.
        // The second situation is in a remote logon case where the remote client may wish to
        // prepopulate a tile with a username, or in some cases, completely populate the tile and
        // use it to logon without showing any UI.
        //
        // If you wish to see an example of SetSerialization, please see either the SampleCredentialProvider
        // sample or the SampleCredUICredentialProvider sample.  [The logonUI team says, "The original sample that
        // this was built on top of didn't have SetSerialization.  And when we decided SetSerialization was
        // important enough to have in the sample, it ended up being a non-trivial amount of work to integrate
        // it into the main sample.  We felt it was more important to get these samples out to you quickly than to
        // hold them in order to do the work to integrate the SetSerialization changes from SampleCredentialProvider
        // into this sample.]
        public int SetSerialization(ref _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION pcpcs)
        {
            Log.LogMethodCall();
            return HResultValues.E_NOTIMPL;
        }

        // Called by LogonUI to give you a callback.  Providers often use the callback if they
        // some event would cause them to need to change the set of tiles that they enumerated.
        public int Advise(ICredentialProviderEvents pcpe, ulong upAdviseContext)
        {
            Log.LogMethodCall();
            return HResultValues.E_NOTIMPL;
        }

        // Called by LogonUI when the ICredentialProviderEvents callback is no longer valid.
        public int UnAdvise()
        {
            Log.LogMethodCall();
            return HResultValues.E_NOTIMPL;
        }

        // Called by LogonUI to determine the number of fields in your tiles.  This
        // does mean that all your tiles must have the same number of fields.
        // This number must include both visible and invisible fields. If you want a tile
        // to have different fields from the other tiles you enumerate for a given usage
        // scenario you must include them all in this count and then hide/show them as desired
        // using the field descriptors.
        public int GetFieldDescriptorCount(out uint pdwCount)
        {
            Log.LogMethodCall();
            pdwCount = (uint)Field.SAMPLE_FIELD_ID.SFI_NUM_FIELDS;
            return HResultValues.S_OK;
        }

        // Gets the field descriptor for a particular field.
        public int GetFieldDescriptorAt(uint dwIndex, [Out] IntPtr ppcpfd) /* _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR** */
        {
            Log.LogMethodCall();

            // Verify dwIndex is a valid field.
            if ((dwIndex < (uint)Field.SAMPLE_FIELD_ID.SFI_NUM_FIELDS) && ppcpfd != IntPtr.Zero)
            {
                return Helpers.FieldDescriptorCoAllocCopy(Field.s_rgCredProvFieldDescriptors[dwIndex], ppcpfd);
            }
            else
            {
                return HResultValues.E_INVALIDARG;
            }
        }

        // Sets pdwCount to the number of tiles that we wish to show at this time.
        // Sets pdwDefault to the index of the tile which should be used as the default.
        // The default tile is the tile which will be shown in the zoomed view by default. If
        // more than one provider specifies a default the last used cred prov gets to pick
        // the default. If *pbAutoLogonWithDefault is TRUE, LogonUI will immediately call
        // GetSerialization on the credential you've specified as the default and will submit
        // that credential for authentication without showing any further UI.
        public int GetCredentialCount(out uint pdwCount, out uint pdwDefault, out int pbAutoLogonWithDefault)
        {
            Log.LogMethodCall();


            pdwDefault = unchecked ((uint)-1);
            pbAutoLogonWithDefault = 0; // Try to auto-logon when all credential managers are enumerated (before the tile selection)

            if (_fRecreateEnumeratedCredentials)
            {
                _fRecreateEnumeratedCredentials = false;
                ReleaseEnumeratedCredentials();
                CreateEnumeratedCredentials();
            }

            pdwCount = 1; // Credential tiles number

            return HResultValues.S_OK;
        }

        // Returns the credential at the index specified by dwIndex. This function is called by logonUI to enumerate
        // the tiles.
        public int GetCredentialAt(uint dwIndex, out ICredentialProviderCredential ppcpc)
        {
            Log.LogMethodCall();

            if (_pCredential == null)
            {
                _pCredential = new CSharpSampleCredential();
            }
            
            ppcpc = (ICredentialProviderCredential)_pCredential;
            return HResultValues.S_OK;
        }

        // This function will be called by LogonUI after SetUsageScenario succeeds.
        // Sets the User Array with the list of users to be enumerated on the logon screen.

        public int SetUserArray(ICredentialProviderUserArray users)
        {
            Log.LogMethodCall();
            if(_pCredProviderUserArray != null)
            {
                var intPtr = Marshal.GetIUnknownForObject(_pCredProviderUserArray);
                Marshal.Release(intPtr);
            }

            _pCredProviderUserArray = users;
            {
                var intPtr = Marshal.GetIUnknownForObject(_pCredProviderUserArray);
                Marshal.AddRef(intPtr);
            }
            
            uint userCount = 0;
            _pCredProviderUserArray.GetCount(out userCount);

            MessageBox.Show(userCount.ToString());

            return HResultValues.S_OK;
        }
        void CreateEnumeratedCredentials()
        {
            switch (_cpus)
            {
                case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_LOGON:
                case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_UNLOCK_WORKSTATION:
                    {
                        EnumerateCredentials();
                        break;
                    }
                default:
                    break;
            }
        }

        void ReleaseEnumeratedCredentials()
        {
            if (_pCredential != null)
            {
                var intPtr = Marshal.GetIUnknownForObject(_pCredential);
                Marshal.Release(intPtr);
                _pCredential = null;
            }
        }
       
        int EnumerateCredentials()
        {
            int hr = HResultValues.E_UNEXPECTED;
            if (_pCredProviderUserArray != null)
            {
                uint dwUserCount = 0;
                _pCredProviderUserArray.GetCount(out dwUserCount);
                if (dwUserCount > 0)
                {
                    ICredentialProviderUser pCredUser;
                    hr = _pCredProviderUserArray.GetAt(0, out pCredUser);
                    if (hr >= 0)
                    {
                        _pCredential = new CSharpSampleCredential();
                        if (_pCredential != null)
                        {
                            hr = _pCredential.Initialize(_cpus, Field.s_rgCredProvFieldDescriptors, Field.s_rgFieldStatePairs, pCredUser);
                            if (hr < 0)
                            {
                                var intPtr = Marshal.GetIUnknownForObject(_pCredential);
                                Marshal.Release(intPtr);
                                _pCredential = null;
                            }
                        }
                        else
                        {
                            hr = HResultValues.E_OUTOFMEMORY;
                        }
                        {
                            var intPtr = Marshal.GetIUnknownForObject(pCredUser);
                            Marshal.Release(intPtr);                            
                        }
                    }
                }
            }
            return hr;
        }
    }
}
