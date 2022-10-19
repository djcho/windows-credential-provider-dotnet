using CredentialProvider.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCredentialProvider
{
    public class Field
    {
        // The indexes of each of the fields in our credential provider's tiles. Note that we're
// using each of the nine available field types here.
        public enum SAMPLE_FIELD_ID
        {
            SFI_TILEIMAGE = 0,
            SFI_LABEL = 1,
            SFI_LARGE_TEXT = 2,
            SFI_PASSWORD = 3,
            SFI_SUBMIT_BUTTON = 4,
            SFI_LAUNCHWINDOW_LINK = 5,
            SFI_HIDECONTROLS_LINK = 6,
            SFI_FULLNAME_TEXT = 7,
            SFI_DISPLAYNAME_TEXT = 8,
            SFI_LOGONSTATUS_TEXT = 9,
            SFI_CHECKBOX = 10,
            SFI_EDIT_TEXT = 11,
            SFI_COMBOBOX = 12,
            SFI_NUM_FIELDS = 13,  // Note: if new fields are added, keep NUM_FIELDS last.  This is used as a count of the number of fields
        };

        // The first value indicates when the tile is displayed (selected, not selected)
        // the second indicates things like whether the field is enabled, whether it has key focus, etc.
        public struct FIELD_STATE_PAIR
        {
            public _CREDENTIAL_PROVIDER_FIELD_STATE cpfs;
            public _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE cpfis;
        };

        // These two arrays are seperate because a credential provider might
        // want to set up a credential with various combinations of field state pairs
        // and field descriptors.

        // The field state value indicates whether the field is displayed
        // in the selected tile, the deselected tile, or both.
        // The Field interactive state indicates when
        public static readonly FIELD_STATE_PAIR[] s_rgFieldStatePairs = {
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_BOTH, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, //SFI_TILEIMAGE
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_HIDDEN, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_LABEL
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_LARGE_TEXT
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_FOCUSED },  // SFI_PASSWORD
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_SUBMIT_BUTTON
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_LAUNCHWINDOW_LINK
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_HIDECONTROLS_LINK
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_FULLNAME_TEXT
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_DISPLAYNAME_TEXT
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_LOGONSTATUS_TEXT
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_CHECKBOX
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_EDIT_TEXT
             new FIELD_STATE_PAIR { cpfs = _CREDENTIAL_PROVIDER_FIELD_STATE.CPFS_DISPLAY_IN_SELECTED_TILE, cpfis = _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE.CPFIS_NONE }, // SFI_COMBOBOX
        };

        // Field descriptors for unlock and logon.
        // The first field is the index of the field.
        // The second is the type of the field.
        // The third is the name of the field, NOT the value which will appear in the field.
        public static readonly _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR[] s_rgCredProvFieldDescriptors = {
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_TILEIMAGE, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_TILE_IMAGE, pszLabel = "Image", guidFieldType = Guid.Parse(Constants.CPFG_CREDENTIAL_PROVIDER_LOGO) },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_LABEL, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_SMALL_TEXT, pszLabel = "Tooltip", guidFieldType = Guid.Parse(Constants.CPFG_CREDENTIAL_PROVIDER_LABEL) },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_LARGE_TEXT, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_LARGE_TEXT, pszLabel = "Sample Credential Provider" },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_PASSWORD, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_PASSWORD_TEXT, pszLabel = "Password text" },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_SUBMIT_BUTTON, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_SUBMIT_BUTTON, pszLabel = "Submit" },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_LAUNCHWINDOW_LINK, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_COMMAND_LINK, pszLabel = "Launch helper window" },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_HIDECONTROLS_LINK, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_COMMAND_LINK, pszLabel = "Hide additional controls" },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_FULLNAME_TEXT, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_SMALL_TEXT, pszLabel = "Full name: " },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_DISPLAYNAME_TEXT, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_SMALL_TEXT, pszLabel = "Display name: " },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_LOGONSTATUS_TEXT, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_SMALL_TEXT, pszLabel = "Logon status: " },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_CHECKBOX, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_CHECKBOX, pszLabel = "Checkbox" },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_EDIT_TEXT, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_EDIT_TEXT, pszLabel = "Edit text" },
            new _CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR{ dwFieldID = (uint)SAMPLE_FIELD_ID.SFI_COMBOBOX, cpft = _CREDENTIAL_PROVIDER_FIELD_TYPE.CPFT_COMBOBOX, pszLabel = "Combobox" },
        };

        public static readonly string[] s_rgComboBoxStrings = { 
            "First",
            "Second",
            "Third",
        };
    }
}
