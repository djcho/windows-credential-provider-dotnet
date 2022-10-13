

/* this ALWAYS GENERATED file contains the proxy stub code */


 /* File created by MIDL compiler version 8.01.0622 */
/* at Tue Jan 19 12:14:07 2038
 */
/* Compiler settings for C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\um\credentialprovider.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.01.0622 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#if defined(_M_AMD64)


#if _MSC_VER >= 1200
#pragma warning(push)
#endif

#pragma warning( disable: 4211 )  /* redefine extern to static */
#pragma warning( disable: 4232 )  /* dllimport identity*/
#pragma warning( disable: 4024 )  /* array to pointer mapping*/
#pragma warning( disable: 4152 )  /* function/data pointer conversion in expression */
#pragma warning( disable: 4100 ) /* unreferenced arguments in x86 call */

#pragma optimize("", off ) 

#define USE_STUBLESS_PROXY


/* verify that the <rpcproxy.h> version is high enough to compile this file*/
#ifndef __REDQ_RPCPROXY_H_VERSION__
#define __REQUIRED_RPCPROXY_H_VERSION__ 475
#endif


#include "rpcproxy.h"
#ifndef __RPCPROXY_H_VERSION__
#error this stub requires an updated version of <rpcproxy.h>
#endif /* __RPCPROXY_H_VERSION__ */


#include "credentialprovider.h"

#define TYPE_FORMAT_STRING_SIZE   137                               
#define PROC_FORMAT_STRING_SIZE   647                               
#define EXPR_FORMAT_STRING_SIZE   1                                 
#define TRANSMIT_AS_TABLE_SIZE    0            
#define WIRE_MARSHAL_TABLE_SIZE   2            

typedef struct _credentialprovider_MIDL_TYPE_FORMAT_STRING
    {
    short          Pad;
    unsigned char  Format[ TYPE_FORMAT_STRING_SIZE ];
    } credentialprovider_MIDL_TYPE_FORMAT_STRING;

typedef struct _credentialprovider_MIDL_PROC_FORMAT_STRING
    {
    short          Pad;
    unsigned char  Format[ PROC_FORMAT_STRING_SIZE ];
    } credentialprovider_MIDL_PROC_FORMAT_STRING;

typedef struct _credentialprovider_MIDL_EXPR_FORMAT_STRING
    {
    long          Pad;
    unsigned char  Format[ EXPR_FORMAT_STRING_SIZE ];
    } credentialprovider_MIDL_EXPR_FORMAT_STRING;


static const RPC_SYNTAX_IDENTIFIER  _RpcTransferSyntax = 
{{0x8A885D04,0x1CEB,0x11C9,{0x9F,0xE8,0x08,0x00,0x2B,0x10,0x48,0x60}},{2,0}};


extern const credentialprovider_MIDL_TYPE_FORMAT_STRING credentialprovider__MIDL_TypeFormatString;
extern const credentialprovider_MIDL_PROC_FORMAT_STRING credentialprovider__MIDL_ProcFormatString;
extern const credentialprovider_MIDL_EXPR_FORMAT_STRING credentialprovider__MIDL_ExprFormatString;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ICredentialProviderCredentialEvents_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ICredentialProviderCredentialEvents_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ICredentialProviderEvents_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ICredentialProviderEvents_ProxyInfo;


extern const MIDL_STUB_DESC Object_StubDesc;


extern const MIDL_SERVER_INFO ICredentialProviderCredentialEvents2_ServerInfo;
extern const MIDL_STUBLESS_PROXY_INFO ICredentialProviderCredentialEvents2_ProxyInfo;


extern const USER_MARSHAL_ROUTINE_QUADRUPLE UserMarshalRoutines[ WIRE_MARSHAL_TABLE_SIZE ];

#if !defined(__RPC_WIN64__)
#error  Invalid build platform for this stub.
#endif
#if !(TARGET_IS_NT60_OR_LATER)
#error You need Windows Vista or later to run this stub because it uses these features:
#error   forced complex structure or array, compiled for Windows Vista.
#error However, your C/C++ compilation flags indicate you intend to run this app on earlier systems.
#error This app will fail with the RPC_X_WRONG_STUB_VERSION error.
#endif


static const credentialprovider_MIDL_PROC_FORMAT_STRING credentialprovider__MIDL_ProcFormatString =
    {
        0,
        {

	/* Procedure SetFieldState */

			0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/*  2 */	NdrFcLong( 0x0 ),	/* 0 */
/*  6 */	NdrFcShort( 0x3 ),	/* 3 */
/*  8 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 10 */	NdrFcShort( 0x10 ),	/* 16 */
/* 12 */	NdrFcShort( 0x8 ),	/* 8 */
/* 14 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 16 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 18 */	NdrFcShort( 0x0 ),	/* 0 */
/* 20 */	NdrFcShort( 0x0 ),	/* 0 */
/* 22 */	NdrFcShort( 0x0 ),	/* 0 */
/* 24 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pcpc */

/* 26 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 28 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 30 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter dwFieldID */

/* 32 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 34 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 36 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter cpfs */

/* 38 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 40 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 42 */	0xe,		/* FC_ENUM32 */
			0x0,		/* 0 */

	/* Return value */

/* 44 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 46 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 48 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFieldInteractiveState */

/* 50 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 52 */	NdrFcLong( 0x0 ),	/* 0 */
/* 56 */	NdrFcShort( 0x4 ),	/* 4 */
/* 58 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 60 */	NdrFcShort( 0x10 ),	/* 16 */
/* 62 */	NdrFcShort( 0x8 ),	/* 8 */
/* 64 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 66 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 68 */	NdrFcShort( 0x0 ),	/* 0 */
/* 70 */	NdrFcShort( 0x0 ),	/* 0 */
/* 72 */	NdrFcShort( 0x0 ),	/* 0 */
/* 74 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pcpc */

/* 76 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 78 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 80 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter dwFieldID */

/* 82 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 84 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 86 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter cpfis */

/* 88 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 90 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 92 */	0xe,		/* FC_ENUM32 */
			0x0,		/* 0 */

	/* Return value */

/* 94 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 96 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 98 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFieldString */

/* 100 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 102 */	NdrFcLong( 0x0 ),	/* 0 */
/* 106 */	NdrFcShort( 0x5 ),	/* 5 */
/* 108 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 110 */	NdrFcShort( 0x8 ),	/* 8 */
/* 112 */	NdrFcShort( 0x8 ),	/* 8 */
/* 114 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 116 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 118 */	NdrFcShort( 0x0 ),	/* 0 */
/* 120 */	NdrFcShort( 0x0 ),	/* 0 */
/* 122 */	NdrFcShort( 0x0 ),	/* 0 */
/* 124 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pcpc */

/* 126 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 128 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 130 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter dwFieldID */

/* 132 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 134 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 136 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter psz */

/* 138 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 140 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 142 */	NdrFcShort( 0x14 ),	/* Type Offset=20 */

	/* Return value */

/* 144 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 146 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 148 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFieldCheckbox */

/* 150 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 152 */	NdrFcLong( 0x0 ),	/* 0 */
/* 156 */	NdrFcShort( 0x6 ),	/* 6 */
/* 158 */	NdrFcShort( 0x30 ),	/* x86 Stack size/offset = 48 */
/* 160 */	NdrFcShort( 0x10 ),	/* 16 */
/* 162 */	NdrFcShort( 0x8 ),	/* 8 */
/* 164 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x5,		/* 5 */
/* 166 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 168 */	NdrFcShort( 0x0 ),	/* 0 */
/* 170 */	NdrFcShort( 0x0 ),	/* 0 */
/* 172 */	NdrFcShort( 0x0 ),	/* 0 */
/* 174 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pcpc */

/* 176 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 178 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 180 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter dwFieldID */

/* 182 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 184 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 186 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter bChecked */

/* 188 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 190 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 192 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter pszLabel */

/* 194 */	NdrFcShort( 0x10b ),	/* Flags:  must size, must free, in, simple ref, */
/* 196 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 198 */	NdrFcShort( 0x1a ),	/* Type Offset=26 */

	/* Return value */

/* 200 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 202 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 204 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFieldBitmap */

/* 206 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 208 */	NdrFcLong( 0x0 ),	/* 0 */
/* 212 */	NdrFcShort( 0x7 ),	/* 7 */
/* 214 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 216 */	NdrFcShort( 0x8 ),	/* 8 */
/* 218 */	NdrFcShort( 0x8 ),	/* 8 */
/* 220 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 222 */	0xa,		/* 10 */
			0x5,		/* Ext Flags:  new corr desc, srv corr check, */
/* 224 */	NdrFcShort( 0x0 ),	/* 0 */
/* 226 */	NdrFcShort( 0x1 ),	/* 1 */
/* 228 */	NdrFcShort( 0x0 ),	/* 0 */
/* 230 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pcpc */

/* 232 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 234 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 236 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter dwFieldID */

/* 238 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 240 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 242 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter hbmp */

/* 244 */	NdrFcShort( 0x8b ),	/* Flags:  must size, must free, in, by val, */
/* 246 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 248 */	NdrFcShort( 0x58 ),	/* Type Offset=88 */

	/* Return value */

/* 250 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 252 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 254 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFieldComboBoxSelectedItem */

/* 256 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 258 */	NdrFcLong( 0x0 ),	/* 0 */
/* 262 */	NdrFcShort( 0x8 ),	/* 8 */
/* 264 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 266 */	NdrFcShort( 0x10 ),	/* 16 */
/* 268 */	NdrFcShort( 0x8 ),	/* 8 */
/* 270 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 272 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 274 */	NdrFcShort( 0x0 ),	/* 0 */
/* 276 */	NdrFcShort( 0x0 ),	/* 0 */
/* 278 */	NdrFcShort( 0x0 ),	/* 0 */
/* 280 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pcpc */

/* 282 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 284 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 286 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter dwFieldID */

/* 288 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 290 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 292 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter dwSelectedItem */

/* 294 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 296 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 298 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 300 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 302 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 304 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure DeleteFieldComboBoxItem */

/* 306 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 308 */	NdrFcLong( 0x0 ),	/* 0 */
/* 312 */	NdrFcShort( 0x9 ),	/* 9 */
/* 314 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 316 */	NdrFcShort( 0x10 ),	/* 16 */
/* 318 */	NdrFcShort( 0x8 ),	/* 8 */
/* 320 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 322 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 324 */	NdrFcShort( 0x0 ),	/* 0 */
/* 326 */	NdrFcShort( 0x0 ),	/* 0 */
/* 328 */	NdrFcShort( 0x0 ),	/* 0 */
/* 330 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pcpc */

/* 332 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 334 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 336 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter dwFieldID */

/* 338 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 340 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 342 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter dwItem */

/* 344 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 346 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 348 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 350 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 352 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 354 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure AppendFieldComboBoxItem */

/* 356 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 358 */	NdrFcLong( 0x0 ),	/* 0 */
/* 362 */	NdrFcShort( 0xa ),	/* 10 */
/* 364 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 366 */	NdrFcShort( 0x8 ),	/* 8 */
/* 368 */	NdrFcShort( 0x8 ),	/* 8 */
/* 370 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 372 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 374 */	NdrFcShort( 0x0 ),	/* 0 */
/* 376 */	NdrFcShort( 0x0 ),	/* 0 */
/* 378 */	NdrFcShort( 0x0 ),	/* 0 */
/* 380 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pcpc */

/* 382 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 384 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 386 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter dwFieldID */

/* 388 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 390 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 392 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter pszItem */

/* 394 */	NdrFcShort( 0x10b ),	/* Flags:  must size, must free, in, simple ref, */
/* 396 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 398 */	NdrFcShort( 0x1a ),	/* Type Offset=26 */

	/* Return value */

/* 400 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 402 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 404 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFieldSubmitButton */

/* 406 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 408 */	NdrFcLong( 0x0 ),	/* 0 */
/* 412 */	NdrFcShort( 0xb ),	/* 11 */
/* 414 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 416 */	NdrFcShort( 0x10 ),	/* 16 */
/* 418 */	NdrFcShort( 0x8 ),	/* 8 */
/* 420 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 422 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 424 */	NdrFcShort( 0x0 ),	/* 0 */
/* 426 */	NdrFcShort( 0x0 ),	/* 0 */
/* 428 */	NdrFcShort( 0x0 ),	/* 0 */
/* 430 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter pcpc */

/* 432 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 434 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 436 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter dwFieldID */

/* 438 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 440 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 442 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter dwAdjacentTo */

/* 444 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 446 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 448 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Return value */

/* 450 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 452 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 454 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure OnCreatingWindow */

/* 456 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 458 */	NdrFcLong( 0x0 ),	/* 0 */
/* 462 */	NdrFcShort( 0xc ),	/* 12 */
/* 464 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 466 */	NdrFcShort( 0x0 ),	/* 0 */
/* 468 */	NdrFcShort( 0x8 ),	/* 8 */
/* 470 */	0x45,		/* Oi2 Flags:  srv must size, has return, has ext, */
			0x2,		/* 2 */
/* 472 */	0xa,		/* 10 */
			0x3,		/* Ext Flags:  new corr desc, clt corr check, */
/* 474 */	NdrFcShort( 0x1 ),	/* 1 */
/* 476 */	NdrFcShort( 0x0 ),	/* 0 */
/* 478 */	NdrFcShort( 0x0 ),	/* 0 */
/* 480 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter phwndOwner */

/* 482 */	NdrFcShort( 0x2113 ),	/* Flags:  must size, must free, out, simple ref, srv alloc size=8 */
/* 484 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 486 */	NdrFcShort( 0x7e ),	/* Type Offset=126 */

	/* Return value */

/* 488 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 490 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 492 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure CredentialsChanged */

/* 494 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 496 */	NdrFcLong( 0x0 ),	/* 0 */
/* 500 */	NdrFcShort( 0x3 ),	/* 3 */
/* 502 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 504 */	NdrFcShort( 0x8 ),	/* 8 */
/* 506 */	NdrFcShort( 0x8 ),	/* 8 */
/* 508 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x2,		/* 2 */
/* 510 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 512 */	NdrFcShort( 0x0 ),	/* 0 */
/* 514 */	NdrFcShort( 0x0 ),	/* 0 */
/* 516 */	NdrFcShort( 0x0 ),	/* 0 */
/* 518 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter upAdviseContext */

/* 520 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 522 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 524 */	0xb9,		/* FC_UINT3264 */
			0x0,		/* 0 */

	/* Return value */

/* 526 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 528 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 530 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure BeginFieldUpdates */

/* 532 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 534 */	NdrFcLong( 0x0 ),	/* 0 */
/* 538 */	NdrFcShort( 0xd ),	/* 13 */
/* 540 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 542 */	NdrFcShort( 0x0 ),	/* 0 */
/* 544 */	NdrFcShort( 0x8 ),	/* 8 */
/* 546 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 548 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 550 */	NdrFcShort( 0x0 ),	/* 0 */
/* 552 */	NdrFcShort( 0x0 ),	/* 0 */
/* 554 */	NdrFcShort( 0x0 ),	/* 0 */
/* 556 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 558 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 560 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 562 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure EndFieldUpdates */

/* 564 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 566 */	NdrFcLong( 0x0 ),	/* 0 */
/* 570 */	NdrFcShort( 0xe ),	/* 14 */
/* 572 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 574 */	NdrFcShort( 0x0 ),	/* 0 */
/* 576 */	NdrFcShort( 0x8 ),	/* 8 */
/* 578 */	0x44,		/* Oi2 Flags:  has return, has ext, */
			0x1,		/* 1 */
/* 580 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 582 */	NdrFcShort( 0x0 ),	/* 0 */
/* 584 */	NdrFcShort( 0x0 ),	/* 0 */
/* 586 */	NdrFcShort( 0x0 ),	/* 0 */
/* 588 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Return value */

/* 590 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 592 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 594 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Procedure SetFieldOptions */

/* 596 */	0x33,		/* FC_AUTO_HANDLE */
			0x6c,		/* Old Flags:  object, Oi2 */
/* 598 */	NdrFcLong( 0x0 ),	/* 0 */
/* 602 */	NdrFcShort( 0xf ),	/* 15 */
/* 604 */	NdrFcShort( 0x28 ),	/* x86 Stack size/offset = 40 */
/* 606 */	NdrFcShort( 0x10 ),	/* 16 */
/* 608 */	NdrFcShort( 0x8 ),	/* 8 */
/* 610 */	0x46,		/* Oi2 Flags:  clt must size, has return, has ext, */
			0x4,		/* 4 */
/* 612 */	0xa,		/* 10 */
			0x1,		/* Ext Flags:  new corr desc, */
/* 614 */	NdrFcShort( 0x0 ),	/* 0 */
/* 616 */	NdrFcShort( 0x0 ),	/* 0 */
/* 618 */	NdrFcShort( 0x0 ),	/* 0 */
/* 620 */	NdrFcShort( 0x0 ),	/* 0 */

	/* Parameter credential */

/* 622 */	NdrFcShort( 0xb ),	/* Flags:  must size, must free, in, */
/* 624 */	NdrFcShort( 0x8 ),	/* x86 Stack size/offset = 8 */
/* 626 */	NdrFcShort( 0x2 ),	/* Type Offset=2 */

	/* Parameter fieldID */

/* 628 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 630 */	NdrFcShort( 0x10 ),	/* x86 Stack size/offset = 16 */
/* 632 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

	/* Parameter options */

/* 634 */	NdrFcShort( 0x48 ),	/* Flags:  in, base type, */
/* 636 */	NdrFcShort( 0x18 ),	/* x86 Stack size/offset = 24 */
/* 638 */	0xe,		/* FC_ENUM32 */
			0x0,		/* 0 */

	/* Return value */

/* 640 */	NdrFcShort( 0x70 ),	/* Flags:  out, return, base type, */
/* 642 */	NdrFcShort( 0x20 ),	/* x86 Stack size/offset = 32 */
/* 644 */	0x8,		/* FC_LONG */
			0x0,		/* 0 */

			0x0
        }
    };

static const credentialprovider_MIDL_TYPE_FORMAT_STRING credentialprovider__MIDL_TypeFormatString =
    {
        0,
        {
			NdrFcShort( 0x0 ),	/* 0 */
/*  2 */	
			0x2f,		/* FC_IP */
			0x5a,		/* FC_CONSTANT_IID */
/*  4 */	NdrFcLong( 0x63913a93 ),	/* 1670462099 */
/*  8 */	NdrFcShort( 0x40c1 ),	/* 16577 */
/* 10 */	NdrFcShort( 0x481a ),	/* 18458 */
/* 12 */	0x81,		/* 129 */
			0x8d,		/* 141 */
/* 14 */	0x40,		/* 64 */
			0x72,		/* 114 */
/* 16 */	0xff,		/* 255 */
			0x8c,		/* 140 */
/* 18 */	0x70,		/* 112 */
			0xcc,		/* 204 */
/* 20 */	
			0x12, 0x8,	/* FC_UP [simple_pointer] */
/* 22 */	
			0x25,		/* FC_C_WSTRING */
			0x5c,		/* FC_PAD */
/* 24 */	
			0x11, 0x8,	/* FC_RP [simple_pointer] */
/* 26 */	
			0x25,		/* FC_C_WSTRING */
			0x5c,		/* FC_PAD */
/* 28 */	
			0x12, 0x0,	/* FC_UP */
/* 30 */	NdrFcShort( 0x2 ),	/* Offset= 2 (32) */
/* 32 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x88,		/* 136 */
/* 34 */	NdrFcShort( 0x8 ),	/* 8 */
/* 36 */	NdrFcShort( 0x3 ),	/* 3 */
/* 38 */	NdrFcLong( 0x48746457 ),	/* 1215587415 */
/* 42 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 44 */	NdrFcLong( 0x52746457 ),	/* 1383359575 */
/* 48 */	NdrFcShort( 0xa ),	/* Offset= 10 (58) */
/* 50 */	NdrFcLong( 0x50746457 ),	/* 1349805143 */
/* 54 */	NdrFcShort( 0x800b ),	/* Simple arm type: FC_HYPER */
/* 56 */	NdrFcShort( 0xffff ),	/* Offset= -1 (55) */
/* 58 */	
			0x12, 0x0,	/* FC_UP */
/* 60 */	NdrFcShort( 0xe ),	/* Offset= 14 (74) */
/* 62 */	
			0x1b,		/* FC_CARRAY */
			0x0,		/* 0 */
/* 64 */	NdrFcShort( 0x1 ),	/* 1 */
/* 66 */	0x9,		/* Corr desc: FC_ULONG */
			0x0,		/*  */
/* 68 */	NdrFcShort( 0xfffc ),	/* -4 */
/* 70 */	NdrFcShort( 0x1 ),	/* Corr flags:  early, */
/* 72 */	0x1,		/* FC_BYTE */
			0x5b,		/* FC_END */
/* 74 */	
			0x17,		/* FC_CSTRUCT */
			0x3,		/* 3 */
/* 76 */	NdrFcShort( 0x18 ),	/* 24 */
/* 78 */	NdrFcShort( 0xfff0 ),	/* Offset= -16 (62) */
/* 80 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 82 */	0x8,		/* FC_LONG */
			0x8,		/* FC_LONG */
/* 84 */	0x6,		/* FC_SHORT */
			0x6,		/* FC_SHORT */
/* 86 */	0x8,		/* FC_LONG */
			0x5b,		/* FC_END */
/* 88 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 90 */	NdrFcShort( 0x0 ),	/* 0 */
/* 92 */	NdrFcShort( 0x8 ),	/* 8 */
/* 94 */	NdrFcShort( 0x0 ),	/* 0 */
/* 96 */	NdrFcShort( 0xffbc ),	/* Offset= -68 (28) */
/* 98 */	
			0x11, 0x4,	/* FC_RP [alloced_on_stack] */
/* 100 */	NdrFcShort( 0x1a ),	/* Offset= 26 (126) */
/* 102 */	
			0x13, 0x0,	/* FC_OP */
/* 104 */	NdrFcShort( 0x2 ),	/* Offset= 2 (106) */
/* 106 */	
			0x2a,		/* FC_ENCAPSULATED_UNION */
			0x48,		/* 72 */
/* 108 */	NdrFcShort( 0x4 ),	/* 4 */
/* 110 */	NdrFcShort( 0x2 ),	/* 2 */
/* 112 */	NdrFcLong( 0x48746457 ),	/* 1215587415 */
/* 116 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 118 */	NdrFcLong( 0x52746457 ),	/* 1383359575 */
/* 122 */	NdrFcShort( 0x8008 ),	/* Simple arm type: FC_LONG */
/* 124 */	NdrFcShort( 0xffff ),	/* Offset= -1 (123) */
/* 126 */	0xb4,		/* FC_USER_MARSHAL */
			0x83,		/* 131 */
/* 128 */	NdrFcShort( 0x1 ),	/* 1 */
/* 130 */	NdrFcShort( 0x8 ),	/* 8 */
/* 132 */	NdrFcShort( 0x0 ),	/* 0 */
/* 134 */	NdrFcShort( 0xffe0 ),	/* Offset= -32 (102) */

			0x0
        }
    };

static const USER_MARSHAL_ROUTINE_QUADRUPLE UserMarshalRoutines[ WIRE_MARSHAL_TABLE_SIZE ] = 
        {
            
            {
            HBITMAP_UserSize
            ,HBITMAP_UserMarshal
            ,HBITMAP_UserUnmarshal
            ,HBITMAP_UserFree
            },
            {
            HWND_UserSize
            ,HWND_UserMarshal
            ,HWND_UserUnmarshal
            ,HWND_UserFree
            }

        };



/* Standard interface: __MIDL_itf_credentialprovider_0000_0000, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}} */


/* Object interface: IUnknown, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0xC0,0x00,0x00,0x00,0x00,0x00,0x00,0x46}} */


/* Object interface: ICredentialProviderCredential, ver. 0.0,
   GUID={0x63913a93,0x40c1,0x481a,{0x81,0x8d,0x40,0x72,0xff,0x8c,0x70,0xcc}} */


/* Object interface: IQueryContinue, ver. 0.0,
   GUID={0x7307055c,0xb24a,0x486b,{0x9f,0x25,0x16,0x3e,0x59,0x7a,0x28,0xa9}} */


/* Object interface: IQueryContinueWithStatus, ver. 0.0,
   GUID={0x9090be5b,0x502b,0x41fb,{0xbc,0xcc,0x00,0x49,0xa6,0xc7,0x25,0x4b}} */


/* Object interface: IConnectableCredentialProviderCredential, ver. 0.0,
   GUID={0x9387928b,0xac75,0x4bf9,{0x8a,0xb2,0x2b,0x93,0xc4,0xa5,0x52,0x90}} */


/* Object interface: ICredentialProviderCredentialEvents, ver. 0.0,
   GUID={0xfa6fa76b,0x66b7,0x4b11,{0x95,0xf1,0x86,0x17,0x11,0x18,0xe8,0x16}} */

#pragma code_seg(".orpc")
static const unsigned short ICredentialProviderCredentialEvents_FormatStringOffsetTable[] =
    {
    0,
    50,
    100,
    150,
    206,
    256,
    306,
    356,
    406,
    456
    };

static const MIDL_STUBLESS_PROXY_INFO ICredentialProviderCredentialEvents_ProxyInfo =
    {
    &Object_StubDesc,
    credentialprovider__MIDL_ProcFormatString.Format,
    &ICredentialProviderCredentialEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ICredentialProviderCredentialEvents_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    credentialprovider__MIDL_ProcFormatString.Format,
    &ICredentialProviderCredentialEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(13) _ICredentialProviderCredentialEventsProxyVtbl = 
{
    &ICredentialProviderCredentialEvents_ProxyInfo,
    &IID_ICredentialProviderCredentialEvents,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldState */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldInteractiveState */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldString */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldCheckbox */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldBitmap */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldComboBoxSelectedItem */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::DeleteFieldComboBoxItem */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::AppendFieldComboBoxItem */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldSubmitButton */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::OnCreatingWindow */
};

const CInterfaceStubVtbl _ICredentialProviderCredentialEventsStubVtbl =
{
    &IID_ICredentialProviderCredentialEvents,
    &ICredentialProviderCredentialEvents_ServerInfo,
    13,
    0, /* pure interpreted */
    CStdStubBuffer_METHODS
};


/* Standard interface: __MIDL_itf_credentialprovider_0000_0004, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}} */


/* Object interface: ICredentialProvider, ver. 0.0,
   GUID={0xd27c3481,0x5a1c,0x45b2,{0x8a,0xaa,0xc2,0x0e,0xbb,0xe8,0x22,0x9e}} */


/* Object interface: ICredentialProviderEvents, ver. 0.0,
   GUID={0x34201e5a,0xa787,0x41a3,{0xa5,0xa4,0xbd,0x6d,0xcf,0x2a,0x85,0x4e}} */

#pragma code_seg(".orpc")
static const unsigned short ICredentialProviderEvents_FormatStringOffsetTable[] =
    {
    494
    };

static const MIDL_STUBLESS_PROXY_INFO ICredentialProviderEvents_ProxyInfo =
    {
    &Object_StubDesc,
    credentialprovider__MIDL_ProcFormatString.Format,
    &ICredentialProviderEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ICredentialProviderEvents_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    credentialprovider__MIDL_ProcFormatString.Format,
    &ICredentialProviderEvents_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(4) _ICredentialProviderEventsProxyVtbl = 
{
    &ICredentialProviderEvents_ProxyInfo,
    &IID_ICredentialProviderEvents,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    (void *) (INT_PTR) -1 /* ICredentialProviderEvents::CredentialsChanged */
};

const CInterfaceStubVtbl _ICredentialProviderEventsStubVtbl =
{
    &IID_ICredentialProviderEvents,
    &ICredentialProviderEvents_ServerInfo,
    4,
    0, /* pure interpreted */
    CStdStubBuffer_METHODS
};


/* Object interface: ICredentialProviderFilter, ver. 0.0,
   GUID={0xa5da53f9,0xd475,0x4080,{0xa1,0x20,0x91,0x0c,0x4a,0x73,0x98,0x80}} */


/* Standard interface: __MIDL_itf_credentialprovider_0000_0007, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}} */


/* Object interface: ICredentialProviderCredential2, ver. 0.0,
   GUID={0xfd672c54,0x40ea,0x4d6e,{0x9b,0x49,0xcf,0xb1,0xa7,0x50,0x7b,0xd7}} */


/* Object interface: ICredentialProviderCredentialWithFieldOptions, ver. 0.0,
   GUID={0xDBC6FB30,0xC843,0x49E3,{0xA6,0x45,0x57,0x3E,0x6F,0x39,0x44,0x6A}} */


/* Object interface: ICredentialProviderCredentialEvents2, ver. 0.0,
   GUID={0xB53C00B6,0x9922,0x4B78,{0xB1,0xF4,0xDD,0xFE,0x77,0x4D,0xC3,0x9B}} */

#pragma code_seg(".orpc")
static const unsigned short ICredentialProviderCredentialEvents2_FormatStringOffsetTable[] =
    {
    0,
    50,
    100,
    150,
    206,
    256,
    306,
    356,
    406,
    456,
    532,
    564,
    596
    };

static const MIDL_STUBLESS_PROXY_INFO ICredentialProviderCredentialEvents2_ProxyInfo =
    {
    &Object_StubDesc,
    credentialprovider__MIDL_ProcFormatString.Format,
    &ICredentialProviderCredentialEvents2_FormatStringOffsetTable[-3],
    0,
    0,
    0
    };


static const MIDL_SERVER_INFO ICredentialProviderCredentialEvents2_ServerInfo = 
    {
    &Object_StubDesc,
    0,
    credentialprovider__MIDL_ProcFormatString.Format,
    &ICredentialProviderCredentialEvents2_FormatStringOffsetTable[-3],
    0,
    0,
    0,
    0};
CINTERFACE_PROXY_VTABLE(16) _ICredentialProviderCredentialEvents2ProxyVtbl = 
{
    &ICredentialProviderCredentialEvents2_ProxyInfo,
    &IID_ICredentialProviderCredentialEvents2,
    IUnknown_QueryInterface_Proxy,
    IUnknown_AddRef_Proxy,
    IUnknown_Release_Proxy ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldState */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldInteractiveState */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldString */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldCheckbox */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldBitmap */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldComboBoxSelectedItem */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::DeleteFieldComboBoxItem */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::AppendFieldComboBoxItem */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::SetFieldSubmitButton */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents::OnCreatingWindow */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents2::BeginFieldUpdates */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents2::EndFieldUpdates */ ,
    (void *) (INT_PTR) -1 /* ICredentialProviderCredentialEvents2::SetFieldOptions */
};

const CInterfaceStubVtbl _ICredentialProviderCredentialEvents2StubVtbl =
{
    &IID_ICredentialProviderCredentialEvents2,
    &ICredentialProviderCredentialEvents2_ServerInfo,
    16,
    0, /* pure interpreted */
    CStdStubBuffer_METHODS
};


/* Object interface: ICredentialProviderUser, ver. 0.0,
   GUID={0x13793285,0x3ea6,0x40fd,{0xb4,0x20,0x15,0xf4,0x7d,0xa4,0x1f,0xbb}} */


/* Standard interface: __MIDL_itf_credentialprovider_0000_0011, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}} */


/* Object interface: ICredentialProviderUserArray, ver. 0.0,
   GUID={0x90C119AE,0x0F18,0x4520,{0xA1,0xF1,0x11,0x43,0x66,0xA4,0x0F,0xE8}} */


/* Object interface: ICredentialProviderSetUserArray, ver. 0.0,
   GUID={0x095c1484,0x1c0c,0x4388,{0x9c,0x6d,0x50,0x0e,0x61,0xbf,0x84,0xbd}} */


/* Standard interface: __MIDL_itf_credentialprovider_0000_0013, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}} */


/* Standard interface: __MIDL_itf_credentialprovider_0000_0014, ver. 0.0,
   GUID={0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}} */

static const MIDL_STUB_DESC Object_StubDesc = 
    {
    0,
    NdrOleAllocate,
    NdrOleFree,
    0,
    0,
    0,
    0,
    0,
    credentialprovider__MIDL_TypeFormatString.Format,
    1, /* -error bounds_check flag */
    0x60001, /* Ndr library version */
    0,
    0x801026e, /* MIDL Version 8.1.622 */
    0,
    UserMarshalRoutines,
    0,  /* notify & notify_flag routine table */
    0x1, /* MIDL flag */
    0, /* cs routines */
    0,   /* proxy/server info */
    0
    };

const CInterfaceProxyVtbl * const _credentialprovider_ProxyVtblList[] = 
{
    ( CInterfaceProxyVtbl *) &_ICredentialProviderEventsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ICredentialProviderCredentialEventsProxyVtbl,
    ( CInterfaceProxyVtbl *) &_ICredentialProviderCredentialEvents2ProxyVtbl,
    0
};

const CInterfaceStubVtbl * const _credentialprovider_StubVtblList[] = 
{
    ( CInterfaceStubVtbl *) &_ICredentialProviderEventsStubVtbl,
    ( CInterfaceStubVtbl *) &_ICredentialProviderCredentialEventsStubVtbl,
    ( CInterfaceStubVtbl *) &_ICredentialProviderCredentialEvents2StubVtbl,
    0
};

PCInterfaceName const _credentialprovider_InterfaceNamesList[] = 
{
    "ICredentialProviderEvents",
    "ICredentialProviderCredentialEvents",
    "ICredentialProviderCredentialEvents2",
    0
};


#define _credentialprovider_CHECK_IID(n)	IID_GENERIC_CHECK_IID( _credentialprovider, pIID, n)

int __stdcall _credentialprovider_IID_Lookup( const IID * pIID, int * pIndex )
{
    IID_BS_LOOKUP_SETUP

    IID_BS_LOOKUP_INITIAL_TEST( _credentialprovider, 3, 2 )
    IID_BS_LOOKUP_NEXT_TEST( _credentialprovider, 1 )
    IID_BS_LOOKUP_RETURN_RESULT( _credentialprovider, 3, *pIndex )
    
}

const ExtendedProxyFileInfo credentialprovider_ProxyFileInfo = 
{
    (PCInterfaceProxyVtblList *) & _credentialprovider_ProxyVtblList,
    (PCInterfaceStubVtblList *) & _credentialprovider_StubVtblList,
    (const PCInterfaceName * ) & _credentialprovider_InterfaceNamesList,
    0, /* no delegation */
    & _credentialprovider_IID_Lookup, 
    3,
    2,
    0, /* table of [async_uuid] interfaces */
    0, /* Filler1 */
    0, /* Filler2 */
    0  /* Filler3 */
};
#pragma optimize("", on )
#if _MSC_VER >= 1200
#pragma warning(pop)
#endif


#endif /* defined(_M_AMD64)*/

