using CredentialProvider.Interop;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static CSharpCredentialProvider.PInvoke;

namespace CSharpCredentialProvider
{
    public class Helpers
    {
        public static int FieldDescriptorCoAllocCopy(_CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR rcpfd, [Out] IntPtr ppcpfd)
        {
            try
            {
                var pcpfd = Marshal.AllocCoTaskMem(Marshal.SizeOf(rcpfd)); /* _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR* */
                Marshal.StructureToPtr(rcpfd, pcpfd, false); /* pcpfd = &CredentialProviderFieldDescriptorList */
                Marshal.StructureToPtr(pcpfd, ppcpfd, false); /* *ppcpfd = pcpfd */

                return HResultValues.S_OK;
            }
            catch
            {
                return HResultValues.E_FAIL;
            }
        }

        public static int FieldDescriptorCopy(_CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR rcpfd, out _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR pcpfd)
        {
            pcpfd.dwFieldID = rcpfd.dwFieldID;
            pcpfd.cpft = rcpfd.cpft;
            pcpfd.guidFieldType = rcpfd.guidFieldType;
            pcpfd.pszLabel = rcpfd.pszLabel;
            return HResultValues.S_OK;
        }

        public static bool SplitDomainAndUsername(string pszQualifiedUserName, out string pszDomain, out string pszUsername)
        {
            string[] splited = pszQualifiedUserName.Split('\\');
            if(splited.Length != 2)
            {
                pszDomain = string.Empty;
                pszUsername = string.Empty;
                return false;
            }
            pszDomain = splited[0];
            pszUsername = splited[1];
            return true;
        }

        public static int KerbInteractiveUnlockLogonInit(
            string pszDomain, 
            string pszUsername, 
            string pwzProtectedPassword, 
            _CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, 
            out PInvoke.KERB_INTERACTIVE_UNLOCK_LOGON kiul)
        {
            int hr = HResultValues.E_UNEXPECTED;

            kiul = new KERB_INTERACTIVE_UNLOCK_LOGON();

            // Note: this method uses custom logic to pack a KERB_INTERACTIVE_UNLOCK_LOGON with a
            // serialized credential.  We could replace the calls to UnicodeStringInitWithString
            // and KerbInteractiveUnlockLogonPack with a single cal to CredPackAuthenticationBuffer,
            // but that API has a drawback: it returns a KERB_INTERACTIVE_UNLOCK_LOGON whose
            // MessageType is always KerbInteractiveLogon.
            //
            // If we only handled CPUS_LOGON, this drawback would not be a problem.  For
            // CPUS_UNLOCK_WORKSTATION, we could cast the output buffer of CredPackAuthenticationBuffer
            // to KERB_INTERACTIVE_UNLOCK_LOGON and modify the MessageType to KerbWorkstationUnlockLogon,
            // but such a cast would be unsupported -- the output format of CredPackAuthenticationBuffer
            // is not officially documented.

            // Initialize the UNICODE_STRINGS to share our username and password strings.
            kiul.Logon.LogonDomainName = new UNICODE_STRING(pszDomain);
            kiul.Logon.UserName = new UNICODE_STRING(pszUsername);
            kiul.Logon.Password = new UNICODE_STRING(pwzProtectedPassword);

            if (kiul.Logon.LogonDomainName.Buffer != IntPtr.Zero &&
                kiul.Logon.UserName.Buffer != IntPtr.Zero &&
                kiul.Logon.Password.Buffer != IntPtr.Zero)
            {
                // Set a MessageType based on the usage scenario.
                switch (cpus)
                {
                    case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_UNLOCK_WORKSTATION:
                        kiul.Logon.MessageType = KERB_LOGON_SUBMIT_TYPE.KerbWorkstationUnlockLogon;
                        hr = HResultValues.S_OK;
                        break;

                    case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_LOGON:
                        kiul.Logon.MessageType = KERB_LOGON_SUBMIT_TYPE.KerbInteractiveLogon;
                        hr = HResultValues.S_OK;
                        break;

                    case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_CREDUI:
                        kiul.Logon.MessageType = (KERB_LOGON_SUBMIT_TYPE)0; // MessageType does not apply to CredUI
                        hr = HResultValues.S_OK;
                        break;

                    default:
                        hr = HResultValues.E_FAIL;
                        break;
                }
            }

            return hr;
        }

        //
        // Return a copy of pwzToProtect encrypted with the CredProtect API.
        //
        // pwzToProtect must not be NULL or the empty string.
        //
        static int _ProtectAndCopyString(string szToProtect, out string szProtected)
        {
            int hr = HResultValues.E_UNEXPECTED;
            szProtected = String.Empty;

            // pwzToProtect is const, but CredProtect takes a non-const string.
            // So, make a copy that we know isn't const.
            string szToProtectCopy = szToProtect;
            if (szToProtectCopy != String.Empty)
            {
                // The first call to CredProtect determines the length of the encrypted string.
                // Because we pass a NULL output buffer, we expect the call to fail.
                //
                // Note that the third parameter to CredProtect, the number of characters of pwzToProtectCopy
                // to encrypt, must include the NULL terminator!
                uint cchProtected = 0;
                CRED_PROTECTION_TYPE cpt;
                StringBuilder szProtectedCredentials = new StringBuilder(szToProtectCopy.Length + 1);
                if (!CredProtect(false, szToProtectCopy, szToProtectCopy.Length + 1, szProtectedCredentials, ref cchProtected, out cpt))
                {                    
                    hr = Marshal.GetLastWin32Error();

                    if ((WINERROR.ERROR_INSUFFICIENT_BUFFER == (WINERROR)hr) && (0 < cchProtected))
                    {
                        // Allocate a buffer long enough for the encrypted string.
                        StringBuilder szProtectedTmp = new StringBuilder((int)cchProtected);                        

                        // The second call to CredProtect actually encrypts the string.
                        if (CredProtect(false, szToProtectCopy, szToProtectCopy.Length + 1, szProtectedTmp, ref cchProtected, out cpt))
                        {
                            szProtected = szProtectedTmp.ToString();
                            hr = HResultValues.S_OK;
                        }
                        else
                        {
                            hr = Marshal.GetLastWin32Error();
                        }

                        szProtectedTmp.Clear();
                    }
                }
                else
                {
                    szProtected = szProtectedCredentials.ToString();
                }

                szProtectedCredentials.Clear();
                szToProtectCopy = String.Empty;
            }

            return hr;
        }

        public static int ProtectIfNecessaryAndCopyPassword(string pszPassword, _CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, out string pszProtectedPassword)
        {
            int hr = HResultValues.E_UNEXPECTED;
            pszProtectedPassword = String.Empty;

            // ProtectAndCopyString is intended for non-empty strings only.  Empty passwords
            // do not need to be encrypted.  
            // pwzPassword is const, but CredIsProtected takes a non-const string.
            // So, ake a copy that we know isn't const.
            string pszPasswordCopy = pszPassword;
            if (pszPasswordCopy != String.Empty)
            {
                bool bCredAlreadyEncrypted = false;
                CRED_PROTECTION_TYPE protectionType;

                // If the password is already encrypted, we should not encrypt it again.
                // An encrypted password may be received through SetSerialization in the
                // CPUS_LOGON scenario during a Terminal Services connection, for instance.
                if (CredIsProtected(pszPasswordCopy, out protectionType))
                {
                    if (CRED_PROTECTION_TYPE.CredUnprotected != protectionType)
                    {
                        bCredAlreadyEncrypted = true;
                    }
                }

                // Passwords should not be encrypted in the CPUS_CREDUI scenario.  We
                // cannot know if our caller expects or can handle an encryped password.
                if (_CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_CREDUI == cpus || bCredAlreadyEncrypted)
                {
                    pszProtectedPassword = pszPasswordCopy;
                }
                else
                {
                    hr = _ProtectAndCopyString(pszPasswordCopy, out pszProtectedPassword);
                }

                pszPasswordCopy = String.Empty;
            }

            return hr;
        }

        public static int RetrieveNegotiateAuthPackage(out uint authPackage)
        {
            // TODO: better checking on the return codes

            var status = PInvoke.LsaConnectUntrusted(out var lsaHandle);

            using (var name = new PInvoke.LsaStringWrapper("Negotiate"))
            {
                status = PInvoke.LsaLookupAuthenticationPackage(lsaHandle, ref name._string, out authPackage);
            }

            PInvoke.LsaDeregisterLogonProcess(lsaHandle);

            return (int)status;
        }

        internal static int KerbInteractiveUnlockLogonPack(PInvoke.KERB_INTERACTIVE_UNLOCK_LOGON kiul, out IntPtr rgbSerialization, out uint cbSerialization)
        {
            // set up the Logon structure within the KERB_INTERACTIVE_UNLOCK_LOGON
            PInvoke.KERB_INTERACTIVE_UNLOCK_LOGON kiulOut = kiul;
            KERB_INTERACTIVE_LOGON kil = kiulOut.Logon;

            // alloc space for struct plus extra for the three strings
            int cb = Marshal.SizeOf(kiulOut) +
                kil.LogonDomainName.Length +
                kil.UserName.Length +
                kil.Password.Length;

            //
            // copy each string,
            // fix up appropriate buffer pointer to be offset,
            // advance buffer pointer over copied characters in extra space
            //
            IntPtr buffer = Marshal.AllocHGlobal(cb);
            IntPtr structBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(kiulOut));

            int pos = Marshal.SizeOf(kiulOut);
            CopyMemory(buffer + pos, kil.LogonDomainName.Buffer, kil.LogonDomainName.Length);
            kiulOut.Logon.LogonDomainName.Buffer = (IntPtr)((buffer.ToInt64() + (Int64)pos) - buffer.ToInt64());

            pos += kil.LogonDomainName.Length;
            CopyMemory(buffer + pos, kil.UserName.Buffer, kil.UserName.Length);
            kiulOut.Logon.UserName.Buffer = (IntPtr)((buffer.ToInt64() + (Int64)pos) - buffer.ToInt64());

            pos +=  kil.UserName.Length;
            CopyMemory(buffer + pos, kil.Password.Buffer, kil.Password.Length);
            kiulOut.Logon.Password.Buffer = (IntPtr)((buffer.ToInt64() + (Int64)pos) - buffer.ToInt64());

            Marshal.StructureToPtr(kiulOut, structBuffer, false);
            CopyMemory(buffer, structBuffer, Marshal.SizeOf(kiulOut));

            rgbSerialization = Marshal.AllocHGlobal(cb);
            CopyMemory(rgbSerialization, buffer, cb);

            Marshal.FreeHGlobal(buffer);

            cbSerialization = (uint)cb;

            return HResultValues.S_OK;
        }
    }
}
