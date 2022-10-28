

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 8.01.0626 */
/* at Tue Jan 19 12:14:07 2038
 */
/* Compiler settings for .\credentialprovider.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.01.0626 
    protocol : all , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */



#ifdef __cplusplus
extern "C"{
#endif 


#include <rpc.h>
#include <rpcndr.h>

#ifdef _MIDL_USE_GUIDDEF_

#ifndef INITGUID
#define INITGUID
#include <guiddef.h>
#undef INITGUID
#else
#include <guiddef.h>
#endif

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        DEFINE_GUID(name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8)

#else // !_MIDL_USE_GUIDDEF_

#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        EXTERN_C __declspec(selectany) const type name = {l,w1,w2,{b1,b2,b3,b4,b5,b6,b7,b8}}

#endif // !_MIDL_USE_GUIDDEF_

MIDL_DEFINE_GUID(IID, LIBID_CredentialProviders,0xd545db01,0xe522,0x4a63,0xaf,0x83,0xd8,0xdd,0xf9,0x54,0x00,0x4f);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderCredentialEvents,0xfa6fa76b,0x66b7,0x4b11,0x95,0xf1,0x86,0x17,0x11,0x18,0xe8,0x16);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderCredential,0x63913a93,0x40c1,0x481a,0x81,0x8d,0x40,0x72,0xff,0x8c,0x70,0xcc);


MIDL_DEFINE_GUID(IID, IID_IQueryContinueWithStatus,0x9090be5b,0x502b,0x41fb,0xbc,0xcc,0x00,0x49,0xa6,0xc7,0x25,0x4b);


MIDL_DEFINE_GUID(IID, IID_IConnectableCredentialProviderCredential,0x9387928b,0xac75,0x4bf9,0x8a,0xb2,0x2b,0x93,0xc4,0xa5,0x52,0x90);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderEvents,0x34201e5a,0xa787,0x41a3,0xa5,0xa4,0xbd,0x6d,0xcf,0x2a,0x85,0x4e);


MIDL_DEFINE_GUID(IID, IID_ICredentialProvider,0xd27c3481,0x5a1c,0x45b2,0x8a,0xaa,0xc2,0x0e,0xbb,0xe8,0x22,0x9e);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderFilter,0xa5da53f9,0xd475,0x4080,0xa1,0x20,0x91,0x0c,0x4a,0x73,0x98,0x80);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderCredential2,0xfd672c54,0x40ea,0x4d6e,0x9b,0x49,0xcf,0xb1,0xa7,0x50,0x7b,0xd7);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderCredentialWithFieldOptions,0xDBC6FB30,0xC843,0x49E3,0xA6,0x45,0x57,0x3E,0x6F,0x39,0x44,0x6A);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderCredentialEvents2,0xB53C00B6,0x9922,0x4B78,0xB1,0xF4,0xDD,0xFE,0x77,0x4D,0xC3,0x9B);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderUser,0x13793285,0x3ea6,0x40fd,0xb4,0x20,0x15,0xf4,0x7d,0xa4,0x1f,0xbb);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderUserArray,0x90C119AE,0x0F18,0x4520,0xA1,0xF1,0x11,0x43,0x66,0xA4,0x0F,0xE8);


MIDL_DEFINE_GUID(IID, IID_ICredentialProviderSetUserArray,0x095c1484,0x1c0c,0x4388,0x9c,0x6d,0x50,0x0e,0x61,0xbf,0x84,0xbd);


MIDL_DEFINE_GUID(CLSID, CLSID_PasswordCredentialProvider,0x60b78e88,0xead8,0x445c,0x9c,0xfd,0x0b,0x87,0xf7,0x4e,0xa6,0xcd);


MIDL_DEFINE_GUID(CLSID, CLSID_V1PasswordCredentialProvider,0x6f45dc1e,0x5384,0x457a,0xbc,0x13,0x2c,0xd8,0x1b,0x0d,0x28,0xed);


MIDL_DEFINE_GUID(CLSID, CLSID_PINLogonCredentialProvider,0xcb82ea12,0x9f71,0x446d,0x89,0xe1,0x8d,0x09,0x24,0xe1,0x25,0x6e);


MIDL_DEFINE_GUID(CLSID, CLSID_NPCredentialProvider,0x3dd6bec0,0x8193,0x4ffe,0xae,0x25,0xe0,0x8e,0x39,0xea,0x40,0x63);


MIDL_DEFINE_GUID(CLSID, CLSID_SmartcardCredentialProvider,0x8FD7E19C,0x3BF7,0x489B,0xA7,0x2C,0x84,0x6A,0xB3,0x67,0x8C,0x96);


MIDL_DEFINE_GUID(CLSID, CLSID_V1SmartcardCredentialProvider,0x8bf9a910,0xa8ff,0x457f,0x99,0x9f,0xa5,0xca,0x10,0xb4,0xa8,0x85);


MIDL_DEFINE_GUID(CLSID, CLSID_SmartcardPinProvider,0x94596c7e,0x3744,0x41ce,0x89,0x3e,0xbb,0xf0,0x91,0x22,0xf7,0x6a);


MIDL_DEFINE_GUID(CLSID, CLSID_SmartcardReaderSelectionProvider,0x1b283861,0x754f,0x4022,0xad,0x47,0xa5,0xea,0xaa,0x61,0x88,0x94);


MIDL_DEFINE_GUID(CLSID, CLSID_SmartcardWinRTProvider,0x1ee7337f,0x85ac,0x45e2,0xa2,0x3c,0x37,0xc7,0x53,0x20,0x97,0x69);


MIDL_DEFINE_GUID(CLSID, CLSID_GenericCredentialProvider,0x25CBB996,0x92ED,0x457e,0xB2,0x8C,0x47,0x74,0x08,0x4B,0xD5,0x62);


MIDL_DEFINE_GUID(CLSID, CLSID_RASProvider,0x5537E283,0xB1E7,0x4EF8,0x9C,0x6E,0x7A,0xB0,0xAF,0xE5,0x05,0x6D);


MIDL_DEFINE_GUID(CLSID, CLSID_OnexCredentialProvider,0x07AA0886,0xCC8D,0x4e19,0xA4,0x10,0x1C,0x75,0xAF,0x68,0x6E,0x62);


MIDL_DEFINE_GUID(CLSID, CLSID_OnexPlapSmartcardCredentialProvider,0x33c86cd6,0x705f,0x4ba1,0x9a,0xdb,0x67,0x07,0x0b,0x83,0x77,0x75);


MIDL_DEFINE_GUID(CLSID, CLSID_VaultProvider,0x503739d0,0x4c5e,0x4cfd,0xb3,0xba,0xd8,0x81,0x33,0x4f,0x0d,0xf2);


MIDL_DEFINE_GUID(CLSID, CLSID_WinBioCredentialProvider,0xBEC09223,0xB018,0x416D,0xA0,0xAC,0x52,0x39,0x71,0xB6,0x39,0xF5);


MIDL_DEFINE_GUID(CLSID, CLSID_V1WinBioCredentialProvider,0xAC3AC249,0xE820,0x4343,0xA6,0x5B,0x37,0x7A,0xC6,0x34,0xDC,0x09);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



