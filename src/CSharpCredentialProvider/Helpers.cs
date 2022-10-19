using CredentialProvider.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

        public static int FieldDescriptorCopy(_CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR rcpfd, [Out] _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR pcpfd)
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

        public static int KerbInteractiveUnlockLogonInit(string pszDomain, string pszUsername, string pwzProtectedPassword, _CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, out PInvoke.KERB_INTERACTIVE_UNLOCK_LOGON kiul)
        {
            throw new NotImplementedException();
        }

        public static int ProtectIfNecessaryAndCopyPassword(string v, _CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, out string pwzProtectedPassword)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
