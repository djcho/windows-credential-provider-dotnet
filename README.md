# Windows Credential Provider in C# 

## Overview

이 저장소는 Windows 시작 시 가장 처음으로 출력되는 사용자 인증 화면을 커스터마이징 할 수 있도록 기능을 제공하는 Windows Credential Provider(이하 CP) 의 C# 버전이다. Windows 에서 제공하는 CP 관련 idl 파일(Interface Description Language)을 사용하여 tlb파일(Type Library)을 추출한 뒤 COM Interop 기술을 사용해 .NET용 dll 파일(Managed Library)을 생성하여 LogonUI.exe 에 의해 호출되도록 한다.



## Caution

Windows 의 데스크탑 진입 전의 모듈인만큼 문제가 발생 시 최악의 경우에는 데스크탑으로 진입을 못하는 상황이 발생할 수 있기 때문에 해당 바이너리를 테스트할 경우 가상 버신을 사용하는 것을 권고한다. 가상 머신을 사용할 수 없다면 안전모드로 부팅이 가능하게 사전 조취를 취해야 하며, 문제가 발생 했을 때  안전모드로 테스트 바이너리를 제거한다.



## How to create interop library

#### idl 파일 수정

Windows SDK 에서 제공하는 기본 credentialprovider.idl을 그대로 사용할 경우에는 일부 인터페이스(예를 들어 ICredentialProviderCredential2)가 Export되지 않기 때문에  파일을 수정해야 한다. 

idl 파일 경로 : C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\um\credentialprovider.idl 

위 경로의 idl파일을 임의의 경로로 복사한 뒤 아래와 같이 수정한다. 수정이 필요한 항목은 아래와 같다.

- 라이브러리 선언부를 최상위로 옮겨 모든 항목이 Export 되도록 수정

```c++
//중간에 존재하는 위 코드 조각을 파일 가장 윗 부분으로 옮겨야 한다.
[
    uuid(d545db01-e522-4a63-af83-d8ddf954004f), // LIBID_CredentialProviders
]
library CredentialProviders
{
```

- `HBITMAP` 타입을 `HANDLE`로 변경
- ICredentialProviderFilter 메서드 변경
  - GUID* rgclsidProviders -> GUID** rgclsidProviders[]
  - [in, out, size_is(cProviders), annotation("_Inout_updates_(cProviders)")] BOOL* rgbAllow -> [ref] BOOL** rgbAllow[]

#### TypeLibrary 파일 생성

위에서 수정한 credentialprovider.idl 파일이 준비되었다면 **x64 Native Tools Command Prompt VS 2022** 를 실행하여 아래와 같이 명령어를 입력하고 tlb 파일을 생성한다.

Developer Command Prompt for VS 2022 가 아님을 주의 해야하며 관리자 권한이 필요하다. {: .notice--warning}

```> midl /target NT100 /x64 "C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\um\credentialprovider.idl"```



CredentialProvider는 Windows 의 LogonUI.exe 에 의해 호출되므로 Windows 에 아키텍쳐를 따른다. 더이상 x86 Windows는 없기 때문에 x64로 명시해야 하며 Windows10 을 대상으로 하는 NT100 옵션을 추가한다. CredentialProvider V2 는 Vista 이후에 추가되었기 때문에 반드시 NT60 이상으로 명시해야 한다.

`.tlb`파일이 생성되었다면 VisualStudio 로 해당 파일을 열어 개체 브라우저에서 필요한 인터페이스들이 잘 Export 되었는지 확인한다.  아래 그림과 같이 인터페이스가 존재하는지 확인한다.



#### TypeLibraryImporter2 빌드

기본  Microsoft 에서 제공하는 tlbimp.exe 를 사용하여 컴파일할 경우에는 HRESULT 반환 유형을 생략하고 .NET의 예외(Exception)을 사용하도록 변경되므로 Winlogon 또는 credUI 호스트앱이 예외를 발생시키면서 프로스가 종료되는 이슈가 있다. 때문에 이를 해결하려면 tlbimp2.exe 를 사용해 컴파일 해야 한다.

TypeLibraryImporter2 Github 저장소 : https://github.com/clrinterop/TypeLibraryImporter

위 저장소에서 프로젝트를 받은 뒤 TlbImp2.sln 을 열어 Tlbmp2 프로젝트를 빌드한다.



### Interop 파일 생성

tlbimp2.exe 가 준비되었다면 이제 위에서 만든 tlb 파일로 Interop.dll 을 생성할 차례이다. 위에서와 마찬가지로 **x64 Native Tools Command Prompt VS 2022** 를 관리자로 실행하여 아래와 같이 명령을 입력한다.

```> tlbImp2.exe credentialprovider.tlb /out:CredentialProvider.Interop.dll /unsafe /verbose /preservesig```

이제 VisualStudio 에서 CredentialProvider.Interop.dll 파일을 [참조 추가]하면 CP관련 인터페이스를 호출할 수 있게되고 C# CredentialProvider 를 개발할 준비가 끝났다.



## Installation

Windows Credential Provider 모듈은 LogonUI.exe 에게 호출되는 입장이기 때문에 시스템에 우선 등록해야 한다. 등록은 아래 형식으로 .reg 파일을 생성하여 등록한다.

```
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\Credential Providers\{GUID}]
@="SampleV2CredentialProvider"

[HKEY_CLASSES_ROOT\CLSID\{GUID}]
@="SampleV2CredentialProvider"

[HKEY_CLASSES_ROOT\CLSID\{GUID}\InprocServer32]
@="SampleV2CredentialProvider.dll"
"ThreadingModel"="Apartment"
```



## Dependency

-  Windows SDK
-  TlbImp2.exe : https://github.com/clrinterop/TypeLibraryImporter
  - 기본  Microsoft 에서 제공하는 tlbimp.exe 를 사용하여 컴파일할 경우에는 HRESULT 반환 유형을 생략하고 .NET의 예외(Exception)을 사용하도록 변경되므로 Winlogon 또는 credUI 호스트앱이 예외를 발생시키면서 프로스가 종료되는 이슈가 있다. 때문에 이를 해결하려면 tlbimp2.exe 를 사용해 컴파일 해야 한다.
  
  

## Reference

- https://github.com/phaetto/windows-credentials-provider
- https://stackoverflow.com/questions/36425318/windows-credential-provider-in-c-sharp
- https://stackoverflow.com/questions/16092696/windows-credential-provider-with-c-sharp/23496878#23496878
- https://learn.microsoft.com/en-us/windows/win32/secauthn/credential-providers-in-windows
- https://learn.microsoft.com/en-us/samples/microsoft/windows-classic-samples/credential-provider/
