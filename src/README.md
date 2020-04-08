# Hello! #

This is intended to be a Web API template to create new projects moving forward.

We can all as a team contribute to enhance this template.

This template is based on: .Net Core 3.1 and it's compatible with Visual Studio 2017/2019

## Dependencies ##

- Visual Studio 2017/2019
- .Net Core 3.1
- Live Dependency Validation project

![Extension needed to install][logo]

## Features ##

- Very simple architecture, three layers: API -> Core -> Infrastructure
- Clean separation of concerns between layers
- Analyzers pre-configured with most common coding standards
- Swagger pre-configured to support versioning.
- Dependency Injection made easy using conventions.
- Exceptions are handled automatically via middlewares
- NLog is configured via JSON (no more custom config transformations required other than web.config)
- We don't require Microsoft.VisualStudio.SlowCheetah NuGet
- Integration tests hosting the service in memory
- Integration tests driven by SpecFlow (Examples coming soon!)
- Git ignore with default settings for Visual Studio related projects
- Docker ignore with default settings for Visual Studio related projects
- Editor settings files (Visual Studio and Visual Studio Code configurations) matching the analyzer rules
- [Visual Studio 2019 only]. Support for Dependency Validation projects (Architecture projects)
  - These projects will enforce the service architecture at build time
  - For example, you won't be able to reference classes from a project that is not allowed by the Architecture diagram
  
## NuGets ##

- Please update the NuGets when a new project is created.
- NOTE: Please don't update the Microsoft NuGet packages that are tight with a specific .Net Core version since that would break the build.

## Manual steps after creating your project based on this template ##

1. Copy the entire content of this folder and check it in under your actual service repository.
1. Rename the solution file to something meaningful for you
   - Also rename the ReSharper settings file to match yoru solution's file name (WebServiceProject1.sln.DotSettings)- 
1. Update the global settings in this file: /ServiceTemplate/NetCore/3.1/Api/Settings/GlobalSettings.cs
```
		public const string ServiceName = "WebServiceProject1";

		public const string FriendlyServiceName = "Web Service Project1";
```
1. Update the launch settings in this file: /ServiceTemplate/NetCore/3.1/Api/Properties/launchSettings.json
   - Use the port assigned to your service by Prod team
```
{
   "iisSettings": {
    "iisExpress": {
      "applicationUrl": "http://localhost:62588",
     }
  },
  "profiles": {
    "IIS Express": {
      "launchUrl": "swagger/WebServiceProject1",
    },
    "WebServiceProject1": {
      "launchUrl": "swagger/WebServiceProject1",
      "applicationUrl": "http://localhost:62588",
    }
  }
}
```
1. Update the NLog default folder setting for local development in this file: /ServiceTemplate/NetCore/3.1/Api/appsettings.Development.json
```
  "NLog": {
    ...
    "variables": {
      "logDir": "/logs/WebServiceProject1"
    }
    ...
  }
```

### Optional steps ###

1. Change the default namespace for all the projects
   - This step is needed in case you want your service namespace to look more **specific** to you. Example: `FeatureToggleService.Core.Domain` instead of the generic version: `Core.Domain`
   - You will need to change the namespace in all current _cs_ files.
   - If you have ReSharper installed, this can be done in just few clicks.
   - Example:
```
  <PropertyGroup>
    <RootNamespace>Api</RootNamespace>
  </PropertyGroup>
```
1. Change the assembly name for all your projects
   - You can match the assembly filename with the default namespace.
   - Example:
```
  <PropertyGroup>
    <AssemblyName>Api</AssemblyName>
  </PropertyGroup>
```
1. Update the Service Description file. (Api\ServiceDescription.md)
1. Remove the code for two "example" endpoints that exist in the template:
  - /api/HistoricalPerformance/v1/HelloWorld/greeting/{name}
  - /api/HistoricalPerformance/v1/HelloWorld/playPowerBall
  - To easily remove it you can run this PowerShell script:
    - Remove-SampleEndpointCode.ps1


[logo]: LiveDependencyValidation.PNG "Extension needed to install"
