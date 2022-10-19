using CredentialProvider.Interop;
using System;

namespace CSharpCredentialProvider
{
    public static class Constants
    {
        public const string CredentialProviderUID = "298D9F84-9BC5-435C-9FC2-EB3746625954";
        public const string CredentialProviderTileUID = "062AF153-00EF-4DFE-9A57-222A9309657B";
        public const string CPFG_CREDENTIAL_PROVIDER_LOGO = "2d837775-f6cd-464e-a745-482fd0b47493";
        public const string CPFG_CREDENTIAL_PROVIDER_LABEL = "286BBFF3-BAD4-438F-B007-79B7267C3D48";
        public const string Identity_LocalUserProvider = "A198529B-730F-4089-B646-A12557F5665E";

        public static readonly _tagpropertykey PKEY_Identity_QualifiedUserName = new _tagpropertykey {
            fmtid = Guid.Parse("DA520E51-F4E9-4739-AC82-02E0A95C9030"),
            pid = 100
        };

        public static readonly _tagpropertykey PKEY_Identity_UserName = new _tagpropertykey
        {
            fmtid = Guid.Parse("C4322503-78CA-49C6-9ACC-A68E2AFD7B6B"),
            pid = 100
        };

        public static readonly _tagpropertykey PKEY_Identity_DisplayName = new _tagpropertykey
        {
            fmtid = Guid.Parse("7D683FC9-D155-45A8-BB1F-89D19BCB792F"),
            pid = 100
        };
        public static readonly _tagpropertykey PKEY_Identity_LogonStatusString = new _tagpropertykey
        {
            fmtid = Guid.Parse("F18DEDF3-337F-42C0-9E03-CEE08708A8C3"),
            pid = 100
        };

        public struct REPORT_RESULT_STATUS_INFO
        {
            public long ntsStatus;
            public long ntsSubstatus;
            public string pwzMessage;
            public _CREDENTIAL_PROVIDER_STATUS_ICON cpsi;
        };

        public enum NTSTATUS : long
        {
            STATUS_LOGON_FAILURE = 0xC000006DL,
            STATUS_SUCCESS = 0x00000000L,
            STATUS_ACCOUNT_RESTRICTION = 0xC000006EL,
            STATUS_ACCOUNT_DISABLED = 0xC0000072L
        };

        public static readonly REPORT_RESULT_STATUS_INFO[] s_rgLogonStatusInfo = {
            new REPORT_RESULT_STATUS_INFO { ntsStatus =  (long)NTSTATUS.STATUS_LOGON_FAILURE, ntsSubstatus =  (long)NTSTATUS.STATUS_SUCCESS, pwzMessage = "Incorrect password or username.", cpsi = _CREDENTIAL_PROVIDER_STATUS_ICON.CPSI_ERROR },
            new REPORT_RESULT_STATUS_INFO { ntsStatus =  (long)NTSTATUS.STATUS_ACCOUNT_RESTRICTION, ntsSubstatus = (long)NTSTATUS.STATUS_ACCOUNT_DISABLED, pwzMessage = "The account is disabled.", cpsi = _CREDENTIAL_PROVIDER_STATUS_ICON.CPSI_WARNING }
        };
    }
}

