# Windows Credential Provider in C# 

## Overview

이 저장소는 Windows 시작 시 가장 처음으로 출력되는 사용자 인증 화면을 커스터마이징 할 수 있도록 기능을 제공하는 Windows Credential Provider(이하 CP) 의 C# 버전이다. Windows 에서 제공하는 CP 관련 idl 파일(Interface Description Language)을 사용하여 tlb파일(Type Library)을 추출한 뒤 COM Interop 기술을 사용해 .NET용 dll 파일(Managed Library)을 생성하여 LogonUI.exe 에 의해 호출되도록 한다.



## Caution

Windows 의 데스크탑 진입 전의 모듈인만큼 문제가 발생 시 최악의 경우에는 데스크탑으로 진입을 못하는 상황이 발생할 수 있기 때문에 해당 바이너리를 테스트할 경우 가상 버신을 사용하는 것을 권고한다. 가상 머신을 사용할 수 없다면 안전모드로 부팅이 가능하게 사전 조취를 취해야 하며, 문제가 발생 했을 때  안전모드로 테스트 바이너리를 제거한다.



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

-  TlbImp2.exe : https://github.com/clrinterop/TypeLibraryImporter
  - 기본  Microsoft 에서 제공하는 tlbimp.exe 를 사용하여 컴파일할 경우에는 HRESULT 반환 유형을 생략하고 .NET의 예외(Exception)을 사용하도록 변경되므로 Winlogon 또는 credUI 호스트앱이 예외를 발생시키면서 프로스가 종료되는 이슈가 있다. 때문에 이를 해결하려면 tlbimp2.exe 를 사용해 컴파일 해야 한다.

## Reference

- https://github.com/phaetto/windows-credentials-provider
- https://stackoverflow.com/questions/36425318/windows-credential-provider-in-c-sharp
- https://stackoverflow.com/questions/16092696/windows-credential-provider-with-c-sharp/23496878#23496878
- https://learn.microsoft.com/en-us/windows/win32/secauthn/credential-providers-in-windows

- https://learn.microsoft.com/en-us/samples/microsoft/windows-classic-samples/credential-provider/