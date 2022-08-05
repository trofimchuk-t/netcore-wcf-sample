# .NET CORE WCF Demo solution

Sample WCF solution with two projects: service server `WCF.Demo.Service` and client `WCF.Demo.Client`.

Service based on Minimal API CoreWCF Sample [sample](https://github.com/CoreWCF/samples/tree/main/Scenarios/Getting-Started-with-CoreWCF/MinimalAPIServer). To create client please follow the walkthrough [article](https://github.com/CoreWCF/CoreWCF/blob/main/Documentation/Walkthrough.md#to-consume-the-service).

## Parameters

1. Server listening ports (configured in service `appsettings.json` config file):
   ```json
   "Urls": "http://*:8088;https://*:8443"
   ```
1. WSDL link:
   ```
   https://localhost:8443/EchoService?wsdl
   ```

## Steps to create service

1. Create an ASP.NET Core Empty application
1. Add references to the CoreWCF Nuget Packages:
   - `CoreWCF.Http`
   - `CoreWCF.Primitives`
1. Create the Service Contract and Data Contract definitions (see _WCF.Demo.Service_ `Contracts.cs` and `EchoService.cs` files)
1. Update Program.cs
1. Update the `appsettings.json` with `Urls` config
1. Run the service

## Steps to create client:

1. Create a console application
1. Right-click on client project and select `Add > Service reference...` and choose `WCF Web Service`
1. In the URI field paste WSDL url (see above). Click `Go` to check whether service is available. Adjust namespace for service in the appropriate field. Finish wizard
1. Update Program.cs (see _WCF.Demo.Client_ `Program.cs` file)
1. Run client

Another way to create client is to use `svcutil` CLI tool:

```shell
dotnet tool install --global dotnet-svcutil

dotnet-svcutil --roll-forward LatestMajor https://localhost:8443/EchoService?wsdl
```
