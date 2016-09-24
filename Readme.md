Sales Portal Core Library

|    CI    |      Status   |
|----------|:-------------:|
| AppVeyor(Windows): |  [![Build status](https://ci.appveyor.com/api/projects/status/7hl877vofntbissm?svg=true)](https://ci.appveyor.com/project/dominikus1993/salesportal-core) |
| MyGet: | [![rosskoks MyGet Build Status](https://www.myget.org/BuildSource/Badge/rosskoks?identifier=2cee9f18-c6ef-4375-b545-af48f27bb951)](https://www.myget.org/) |
## How to Build
1. Install dotnet core SDK https://www.microsoft.com/net/core#Windows
2. dotnet restore 
3. dotnet build src/Domain
4. dotnet test test/Domain.Tests