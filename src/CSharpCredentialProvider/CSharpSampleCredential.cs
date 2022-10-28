using CredentialProvider.Interop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace CSharpCredentialProvider
{
    [ComVisible(true)]
    [Guid(Constants.CredentialProviderTileUID)]
    [ClassInterface(ClassInterfaceType.None)]
    public class CSharpSampleCredential : ICredentialProviderCredential2, ICredentialProviderCredentialWithFieldOptions
    {        
        // The usage scenario for which we were enumerated.
        private _CREDENTIAL_PROVIDER_USAGE_SCENARIO _cpus;
        
        // An array holding the type and name of each field in the tile.
        private _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR[] _rgCredProvFieldDescriptors = new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR[(int)Field.SAMPLE_FIELD_ID.SFI_NUM_FIELDS];
        // An array holding the state of each field in the tile.
        private Field.FIELD_STATE_PAIR[] _rgFieldStatePairs = new Field.FIELD_STATE_PAIR[(int)Field.SAMPLE_FIELD_ID.SFI_NUM_FIELDS];
        // An array holding the string value of each field. This is different from the name of the field held in _rgCredProvFieldDescriptors.
        private string[] _rgFieldStrings = new string[(int)Field.SAMPLE_FIELD_ID.SFI_NUM_FIELDS];
        private string _pszUserSid;
        // The user name that's used to pack the authentication buffer
        private string _pszQualifiedUserName;
        // Used to update fields. CredentialEvents2 for Begin and EndFieldUpdates.
        private ICredentialProviderCredentialEvents2 _pCredProvCredentialEvents;
        // Tracks the state of our checkbox.
        private bool _fChecked;
        // Tracks the current index of our combobox.
        private uint _dwComboIndex;
        // Tracks the state of our show/hide controls link.
        private bool _fShowControls;
        // If the cred prov is assosiating with a local user tile
        private bool _fIsLocalUser;


        // Initializes one credential with the field information passed in.
        // Set the value of the SFI_LARGE_TEXT field to pwzUsername.
        public int Initialize(_CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus,
            _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR[] rgcpfd,
            Field.FIELD_STATE_PAIR[] rgfsp,
            ICredentialProviderUser pcpUser)
        {
            Log.LogMethodCall();
#if DEBUG
            MessageBox.Show("initialize braek point");
#endif
            int hr = HResultValues.S_OK;
            _cpus = cpus;
            Guid guidProvider;
            pcpUser.GetProviderID(out guidProvider);
            _fIsLocalUser = (guidProvider == Guid.Parse(Constants.Identity_LocalUserProvider));

            // Copy the field descriptors for each field. This is useful if you want to vary the field
            // descriptors based on what Usage scenario the credential was created for.
            for (int i = 0; hr >= 0 && i < _rgCredProvFieldDescriptors.Length; i++)
            {
                _rgFieldStatePairs[i] = rgfsp[i];
                hr = Helpers.FieldDescriptorCopy(rgcpfd[i], out _rgCredProvFieldDescriptors[i]);
            }
            // Initialize the String value of all the fields.
            _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_LABEL] = "Sample Credential";
            _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_LARGE_TEXT] = "Sample Credential Provider";
            _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_EDIT_TEXT] = "Edit Text";
            _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_PASSWORD] = "";
            _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_SUBMIT_BUTTON] = "Submit";
            _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_CHECKBOX] = "Checkbox";
            _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_COMBOBOX] = "Combobox";
            _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_LAUNCHWINDOW_LINK] = "Launch helper window";
            _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_HIDECONTROLS_LINK] = "Hide additional controls";

            hr = pcpUser.GetStringValue(Constants.PKEY_Identity_QualifiedUserName, out _pszQualifiedUserName);
            if (hr >= 0)
            {
                string pszUserName;
                pcpUser.GetStringValue(Constants.PKEY_Identity_UserName, out pszUserName);
                if (!string.IsNullOrEmpty(pszUserName))
                {
                    _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_FULLNAME_TEXT] = "User Name: " + pszUserName;
                }
                else
                {
                    _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_FULLNAME_TEXT] = "User Name is NULL";
                }
            }
            if (hr >= 0)
            {
                string pszDisplayName;
                pcpUser.GetStringValue(Constants.PKEY_Identity_DisplayName, out pszDisplayName);
                if (!string.IsNullOrEmpty(pszDisplayName))
                {
                    _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_DISPLAYNAME_TEXT] = "Display Name: " + pszDisplayName;
                }
                else
                {
                    _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_DISPLAYNAME_TEXT] = "Display Name is NULL";
                }
            }
            if (hr >= 0)
            {
                string pszLogonStatus;
                pcpUser.GetStringValue(Constants.PKEY_Identity_LogonStatusString, out pszLogonStatus);
                if (!string.IsNullOrEmpty(pszLogonStatus))
                {
                    _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_LOGONSTATUS_TEXT] = "Logon Status: " + pszLogonStatus;
                }
                else
                {
                    _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_LOGONSTATUS_TEXT] = "Logon Status is NULL";
                }
            }
            if (hr >= 0)
            {
                hr = pcpUser.GetSid(out _pszUserSid);
            }
            return hr;
        }

        // LogonUI calls this in order to give us a callback in case we need to notify it of anything.
        public int Advise(ICredentialProviderCredentialEvents pcpce)
        {
            Log.LogMethodCall();
            if (_pCredProvCredentialEvents != null)
            {
                var intPtr = Marshal.GetIUnknownForObject(_pCredProvCredentialEvents);
                Marshal.Release(intPtr);
            }

            if (pcpce != null)
            {
                _pCredProvCredentialEvents = (ICredentialProviderCredentialEvents2)pcpce;
                var intPtr = Marshal.GetIUnknownForObject(pcpce);
                Marshal.AddRef(intPtr);
            }
            return HResultValues.S_OK;
        }

        // LogonUI calls this to tell us to release the callback.
        public int UnAdvise()
        {
            Log.LogMethodCall();
            if (_pCredProvCredentialEvents != null)
            {
                var intPtr = Marshal.GetIUnknownForObject(_pCredProvCredentialEvents);
                Marshal.Release(intPtr);
            }
            _pCredProvCredentialEvents = null;
            return HResultValues.S_OK;
        }

        // LogonUI calls this function when our tile is selected (zoomed)
        // If you simply want fields to show/hide based on the selected state,
        // there's no need to do anything here - you can set that up in the
        // field definitions. But if you want to do something
        // more complicated, like change the contents of a field when the tile is
        // selected, you would do it here.
        public int SetSelected(out int pbAutoLogon)
        {
            Log.LogMethodCall();
            pbAutoLogon = 0;
            return HResultValues.S_OK;
        }

        // Similarly to SetSelected, LogonUI calls this when your tile was selected
        // and now no longer is. The most common thing to do here (which we do below)
        // is to clear out the password field.
        public int SetDeselected()
        {
            Log.LogMethodCall();
            if (!string.IsNullOrEmpty(_rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_PASSWORD]))
            {
                _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_PASSWORD] = "";

                if (_pCredProvCredentialEvents != null)
                {
                    _pCredProvCredentialEvents.SetFieldString(this, (uint)Field.SAMPLE_FIELD_ID.SFI_PASSWORD, _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_PASSWORD]);
                }                
            }

            return HResultValues.S_OK;
        }

        // Get info for a particular field of a tile. Called by logonUI to get information
        // to display the tile.
        public int GetFieldState(uint dwFieldID, out _CREDENTIAL_PROVIDER_FIELD_STATE pcpfs, out _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE pcpfis)
        {
            Log.LogMethodCall();
            int hr = HResultValues.S_OK;
            // Validate our parameters.
            if ((dwFieldID) < _rgFieldStatePairs.Length)
            {
                pcpfs = _rgFieldStatePairs[dwFieldID].cpfs;
                pcpfis = _rgFieldStatePairs[dwFieldID].cpfis;
                hr = HResultValues.S_OK;
            }
            else
            {
                pcpfs = default;
                pcpfis = default;
                hr = HResultValues.E_INVALIDARG;
            }

            return hr;
        }

        // Sets ppwsz to the string value of the field at the index dwFieldID
        public int GetStringValue(uint dwFieldID, out string ppsz)
        {
            Log.LogMethodCall();
            ppsz = null;
            int hr = HResultValues.S_OK;
            
            if(dwFieldID < _rgCredProvFieldDescriptors.Length)
            {
                // Make a copy of the string and return that. The caller
                // is responsible for freeing it.
                ppsz = _rgFieldStrings[dwFieldID];
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }
            
            return hr;
        }

        // Get the image to show in the user tile
        public int GetBitmapValue(uint dwFieldID, out IntPtr phbmp)
        {
            Log.LogMethodCall();
            int hr = HResultValues.S_OK;
            phbmp = IntPtr.Zero;

            if(((uint)Field.SAMPLE_FIELD_ID.SFI_TILEIMAGE == dwFieldID))
            {
                Bitmap bitmap = new Bitmap(Properties.Resources.tileimage);
                if (bitmap != null)
                {
                    hr = HResultValues.S_OK;
                    phbmp = bitmap.GetHbitmap();
                }
                else
                {
                    hr = HResultValues.E_FAIL;
                }
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }

            return hr;
        }

        // Returns whether a checkbox is checked or not as well as its label.
        public int GetCheckboxValue(uint dwFieldID, out int pbChecked, out string ppszLabel)
        {
            Log.LogMethodCall();
            int hr = HResultValues.S_OK;
            pbChecked = 0;
            ppszLabel = null;

            // Validate parameters.
            if (dwFieldID < _rgCredProvFieldDescriptors.Length &&
                _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_CHECKBOX == Field.s_rgCredProvFieldDescriptors[dwFieldID].cpft)
            {
                pbChecked = Convert.ToInt32(_fChecked);
                ppszLabel = _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_CHECKBOX];
                hr = HResultValues.S_OK;
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }

            return hr;
        }

        // Sets pdwAdjacentTo to the index of the field the submit button should be
        // adjacent to. We recommend that the submit button is placed next to the last
        // field which the user is required to enter information in. Optional fields
        // should be below the submit button.
        public int GetSubmitButtonValue(uint dwFieldID, out uint pdwAdjacentTo)
        {
            Log.LogMethodCall();
            int hr = HResultValues.S_OK;
            pdwAdjacentTo = 0;

            if ((uint)Field.SAMPLE_FIELD_ID.SFI_SUBMIT_BUTTON == dwFieldID)
            {
                // pdwAdjacentTo is a pointer to the fieldID you want the submit button to
                // appear next to.
                pdwAdjacentTo = (uint)Field.SAMPLE_FIELD_ID.SFI_PASSWORD;
                hr = HResultValues.S_OK;
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }

            return hr;
        }

        // Returns the number of items to be included in the combobox (pcItems), as well as the
        // currently selected item (pdwSelectedItem).
        public int GetComboBoxValueCount(uint dwFieldID, out uint pcItems, out uint pdwSelectedItem)
        {
            Log.LogMethodCall();
            int hr = HResultValues.S_OK;
            pcItems = 0;
            pdwSelectedItem = 0;

            // Validate parameters.
            if((dwFieldID < _rgCredProvFieldDescriptors.Length) &&
                (_CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_COMBOBOX == _rgCredProvFieldDescriptors[dwFieldID].cpft))
            {
                pcItems = (uint)Field.s_rgComboBoxStrings.Length;
                pdwSelectedItem = 0;
                hr = HResultValues.S_OK;
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }

            return hr;
        }

        // Called iteratively to fill the combobox with the string (ppwszItem) at index dwItem.
        public int GetComboBoxValueAt(uint dwFieldID, uint dwItem, out string ppszItem)
        {
            Log.LogMethodCall();
            int hr = HResultValues.S_OK;
            ppszItem = null;

            // Validate parameters.
            if ((dwFieldID < _rgCredProvFieldDescriptors.Length) &&
                (_CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_COMBOBOX == _rgCredProvFieldDescriptors[dwFieldID].cpft))
            {
                ppszItem = Field.s_rgComboBoxStrings[dwItem];
                hr = HResultValues.S_OK;
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }

            return hr;
        }

        // Sets the value of a field which can accept a string as a value.
        // This is called on each keystroke when a user types into an edit field
        public int SetStringValue(uint dwFieldID, string psz)
        {
            Log.LogMethodCall();
            int hr = HResultValues.S_OK;

            if((dwFieldID < _rgCredProvFieldDescriptors.Length) && 
                (_CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_EDIT_TEXT == _rgCredProvFieldDescriptors[dwFieldID].cpft ||
                _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_PASSWORD_TEXT == _rgCredProvFieldDescriptors[dwFieldID].cpft))
            {
                _rgFieldStrings[dwFieldID] = psz;
                hr = HResultValues.S_OK;
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }

            return hr;
        }

        // Sets whether the specified checkbox is checked or not.
        public int SetCheckboxValue(uint dwFieldID, int bChecked)
        {
            Log.LogMethodCall();
            int hr = HResultValues.S_OK;

            // Validate parameters.
            if ((dwFieldID < _rgCredProvFieldDescriptors.Length) &&
               (_CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_CHECKBOX == _rgCredProvFieldDescriptors[dwFieldID].cpft))
            {
                _fChecked = Convert.ToBoolean(bChecked);                
                hr = HResultValues.S_OK;
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }

            return hr;
        }

        // Called when the user changes the selected item in the combobox.
        public int SetComboBoxSelectedValue(uint dwFieldID, uint dwSelectedItem)
        {
            int hr = HResultValues.S_OK;

            // Validate parameters.
            if ((dwFieldID < _rgCredProvFieldDescriptors.Length) &&
                (_CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_COMBOBOX == _rgCredProvFieldDescriptors[dwFieldID].cpft))
            {
                _dwComboIndex = dwSelectedItem;
                hr = HResultValues.S_OK;
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }

            return hr;
        }

        public int CommandLinkClicked(uint dwFieldID)
        {
            Log.LogMethodCall();
            int hr = HResultValues.S_OK;

            _CREDENTIAL_PROVIDER_FIELD_STATE cpfsShow = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_HIDDEN;

            // Validate parameter.
            if((dwFieldID < _rgCredProvFieldDescriptors.Length) &&
                (_CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_COMMAND_LINK == _rgCredProvFieldDescriptors[dwFieldID].cpft))
            {
                IntPtr hwndOwner = IntPtr.Zero;                
                switch (dwFieldID)
                {
                    case (uint)Field.SAMPLE_FIELD_ID.SFI_LAUNCHWINDOW_LINK:
                        if (_pCredProvCredentialEvents != null)
                        {
                            _pCredProvCredentialEvents.OnCreatingWindow(out hwndOwner);
                        }

                        // Pop a messagebox indicating the click.                                                   
                        PInvoke.MessageBox(hwndOwner, "Command link clicked", "Click!", (uint)PInvoke.MessageBoxCheckFlags.MB_OK);
                        break;
                    case (uint)Field.SAMPLE_FIELD_ID.SFI_HIDECONTROLS_LINK:
                        _pCredProvCredentialEvents.BeginFieldUpdates();
                        cpfsShow = _fShowControls ? _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE : _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_HIDDEN;
                        _pCredProvCredentialEvents.SetFieldState(null, (uint)Field.SAMPLE_FIELD_ID.SFI_FULLNAME_TEXT, cpfsShow);
                        _pCredProvCredentialEvents.SetFieldState(null, (uint)Field.SAMPLE_FIELD_ID.SFI_DISPLAYNAME_TEXT, cpfsShow);
                        _pCredProvCredentialEvents.SetFieldState(null, (uint)Field.SAMPLE_FIELD_ID.SFI_LOGONSTATUS_TEXT, cpfsShow);
                        _pCredProvCredentialEvents.SetFieldState(null, (uint)Field.SAMPLE_FIELD_ID.SFI_CHECKBOX, cpfsShow);
                        _pCredProvCredentialEvents.SetFieldState(null, (uint)Field.SAMPLE_FIELD_ID.SFI_EDIT_TEXT, cpfsShow);
                        _pCredProvCredentialEvents.SetFieldState(null, (uint)Field.SAMPLE_FIELD_ID.SFI_COMBOBOX, cpfsShow);
                        _pCredProvCredentialEvents.SetFieldString(null, (uint)Field.SAMPLE_FIELD_ID.SFI_HIDECONTROLS_LINK, _fShowControls ? "Hide additional controls" : "Show additional controls");
                        _pCredProvCredentialEvents.EndFieldUpdates();
                        _fShowControls = !_fShowControls;
                        break;
                    default:
                        hr = HResultValues.E_INVALIDARG;
                        break;
                }
            }
            else
            {
                hr = HResultValues.E_INVALIDARG;
            }
            return hr;
        }

        // Collect the username and password into a serialized credential for the correct usage scenario
        // (logon/unlock is what's demonstrated in this sample).  LogonUI then passes these credentials
        // back to the system to log on.
        public int GetSerialization(
            out _CREDENTIAL_PROVIDER_GET_SERIALIZATION_RESPONSE pcpgsr,
            out _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION pcpcs, 
            out string ppszOptionalStatusText,
            out _CREDENTIAL_PROVIDER_STATUS_ICON pcpsiOptionalStatusIcon)
        {
            Log.LogMethodCall();
            int hr = HResultValues.E_UNEXPECTED;
            pcpcs = new _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION();
            pcpgsr = _CREDENTIAL_PROVIDER_GET_SERIALIZATION_RESPONSE.CPGSR_NO_CREDENTIAL_NOT_FINISHED;
            ppszOptionalStatusText = null;
            pcpsiOptionalStatusIcon = _CREDENTIAL_PROVIDER_STATUS_ICON.CPSI_NONE;

            // For local user, the domain and user name can be split from _pszQualifiedUserName (domain\username).
            // CredPackAuthenticationBuffer() cannot be used because it won't work with unlock scenario.
            if (_fIsLocalUser)
            {

                string pwzProtectedPassword;
                hr = Helpers.ProtectIfNecessaryAndCopyPassword(_rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_PASSWORD], _cpus, out pwzProtectedPassword);
                if (hr >= 0)
                {
                    string pszDomain;
                    string pszUsername;
                    bool result = Helpers.SplitDomainAndUsername(_pszQualifiedUserName, out pszDomain, out pszUsername);
                    if (result)
                    {
                        PInvoke.KERB_INTERACTIVE_UNLOCK_LOGON kiul;
                        hr = Helpers.KerbInteractiveUnlockLogonInit(pszDomain, pszUsername, pwzProtectedPassword, _cpus, out kiul);
                        if (hr >= 0)
                        {
                            hr = Helpers.KerbInteractiveUnlockLogonPack(kiul, out pcpcs.rgbSerialization, out pcpcs.cbSerialization);
                            if (hr >= 0)
                            {
                                hr = Helpers.RetrieveNegotiateAuthPackage(out var authPackage);
                                if (hr >= 0)
                                {
                                    pcpcs.clsidCredentialProvider = Guid.Parse(Constants.CredentialProviderUID);
                                    pcpcs.ulAuthenticationPackage = authPackage;
                                    pcpgsr = _CREDENTIAL_PROVIDER_GET_SERIALIZATION_RESPONSE.CPGSR_RETURN_CREDENTIAL_FINISHED;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                uint dwAuthFlags = 0x01/*CRED_PACK_PROTECTED_CREDENTIALS*/ | 0x08 /*CRED_PACK_ID_PROVIDER_CREDENTIALS*/;
                // First get the size of the authentication buffer to allocate
                var inCredSize = 0;
                var inCredBuffer = Marshal.AllocCoTaskMem(0);

                // First get the size of the authentication buffer to allocate
                if (!PInvoke.CredPackAuthenticationBuffer((int)dwAuthFlags, _pszQualifiedUserName, _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_PASSWORD], inCredBuffer, ref inCredSize))
                {
                    Marshal.FreeCoTaskMem(inCredBuffer);
                    inCredBuffer = Marshal.AllocCoTaskMem(inCredSize);

                    // Retrieve the authentication buffer
                    if (PInvoke.CredPackAuthenticationBuffer((int)dwAuthFlags, _pszQualifiedUserName, _rgFieldStrings[(int)Field.SAMPLE_FIELD_ID.SFI_PASSWORD], inCredBuffer, ref inCredSize))
                    {
                        
                        pcpcs.rgbSerialization = inCredBuffer;
                        pcpcs.cbSerialization = (uint)inCredSize;

                        hr = Helpers.RetrieveNegotiateAuthPackage(out var ulAuthPackage);
                        if(hr >= 0)
                        {
                            pcpcs.ulAuthenticationPackage = ulAuthPackage;
                            pcpcs.clsidCredentialProvider = Guid.Parse(Constants.CredentialProviderUID);

                            // At this point the credential has created the serialized credential used for logon
                            // By setting this to CPGSR_RETURN_CREDENTIAL_FINISHED we are letting logonUI know
                            // that we have all the information we need and it should attempt to submit the
                            // serialized credential.
                            pcpgsr = _CREDENTIAL_PROVIDER_GET_SERIALIZATION_RESPONSE.CPGSR_RETURN_CREDENTIAL_FINISHED;
                        }                        
                    }
                    else
                    {
                        hr = HResultValues.E_FAIL;
                    }

                    if(hr < 0)
                    {
                        Marshal.FreeCoTaskMem(inCredBuffer);
                    }
                }
                else
                {
                    hr = HResultValues.E_OUTOFMEMORY;
                }
            }          
            
            return hr;
        }

        // ReportResult is completely optional.  Its purpose is to allow a credential to customize the string
        // and the icon displayed in the case of a logon failure.  For example, we have chosen to
        // customize the error shown in the case of bad username/password and in the case of the account
        // being disabled.
        public int ReportResult(int ntsStatus, int ntsSubstatus, out string ppszOptionalStatusText, out _CREDENTIAL_PROVIDER_STATUS_ICON pcpsiOptionalStatusIcon)
        {
            Log.LogMethodCall();
            ppszOptionalStatusText = string.Empty;
            pcpsiOptionalStatusIcon = _CREDENTIAL_PROVIDER_STATUS_ICON.CPSI_NONE;

            int dwStatusInfo = -1;

            // Look for a match on status and substatus.
            for(int i = 0; i< Constants.s_rgLogonStatusInfo.Length; i++)
            {
                if (Constants.s_rgLogonStatusInfo[i].ntsStatus == ntsStatus && Constants.s_rgLogonStatusInfo[i].ntsSubstatus == ntsSubstatus)
                {
                    dwStatusInfo = i;
                    break;
                }
            }

            if(dwStatusInfo != -1)
            {
                ppszOptionalStatusText = Constants.s_rgLogonStatusInfo[dwStatusInfo].pwzMessage;
                pcpsiOptionalStatusIcon = Constants.s_rgLogonStatusInfo[dwStatusInfo].cpsi;
            }

            // If we failed the logon, try to erase the password field.
            if ((ntsStatus | 0x10000000) < 0)
            {
                if (_pCredProvCredentialEvents != null)
                {
                    _pCredProvCredentialEvents.SetFieldString(this, (uint)Field.SAMPLE_FIELD_ID.SFI_PASSWORD, "");
                }
            }

            // Since nullptr is a valid value for *ppwszOptionalStatusText and *pcpsiOptionalStatusIcon
            // this function can't fail.
            return HResultValues.S_OK;
        }

        // Gets the SID of the user corresponding to the credential.
        public int GetUserSid(out string sid)
        {
            Log.LogMethodCall();
            sid = _pszUserSid;
            // Return S_FALSE with a null SID in ppszSid for the
            // credential to be associated with an empty user tile.
            return HResultValues.S_OK; ;
        }

        // GetFieldOptions to enable the password reveal button and touch keyboard auto-invoke in the password field.
        public int GetFieldOptions(uint fieldID, out CREDENTIAL_PROVIDER_CREDENTIAL_FIELD_OPTIONS options)
        {
            Log.LogMethodCall();
            options = CREDENTIAL_PROVIDER_CREDENTIAL_FIELD_OPTIONS.CPCFO_NONE;

            if(fieldID == (uint)Field.SAMPLE_FIELD_ID.SFI_PASSWORD)
            {
                options = CREDENTIAL_PROVIDER_CREDENTIAL_FIELD_OPTIONS.CPCFO_ENABLE_PASSWORD_REVEAL;
            }
            else if(fieldID == (uint)Field.SAMPLE_FIELD_ID.SFI_TILEIMAGE)
            {
                options = CREDENTIAL_PROVIDER_CREDENTIAL_FIELD_OPTIONS.CPCFO_ENABLE_TOUCH_KEYBOARD_AUTO_INVOKE;
            }

            return HResultValues.S_OK;
        }
    }
}
