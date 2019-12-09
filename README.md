# String.Extensions

[![Build status](https://dev.azure.com/teh13th/HandleUtility/_apis/build/status/teh13th.HandleUtility)](https://dev.azure.com/teh13th/HandleUtility/_build/latest?definitionId=4)
![Release status](https://vsrm.dev.azure.com/teh13th/_apis/public/Release/badge/79d2174a-c89a-48b3-921b-dd17b458298c/1/1)
![Code coverage](https://img.shields.io/azure-devops/coverage/teh13th/HandleUtility/4)
![Nuget version](https://img.shields.io/nuget/v/teh13th.HandleUtility)
![Nuget downloads](https://img.shields.io/nuget/dt/teh13th.HandleUtility)

Some string extensions (comparing with ignore case and so on).

## Usage

For example, for case-insensitive check for equility use the following code:

```csharp
using teh13th.String.Extensions;
"test".EqualsI("TEST");
```
