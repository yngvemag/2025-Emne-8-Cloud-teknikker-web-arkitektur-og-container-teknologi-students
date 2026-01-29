# Dag 2

## Integrasjons testing

```bash
dotnet new install xunit.v3.templates

dotnet new sln -n stud-blogg-ap
dotnet sln add .\StudentBloggAPI\StudentBloggAPI.csproj

dotnet --list-sdks
dotnet new xunit -n IntegrationTests -f net8.0

cd IntegrationTests



dotnet add package  Microsoft.AspNetCore.Mvc.Testing 
dotnet add package  Testcontainers.MySql

dotnet add package  Microsoft.AspNetCore.Mvc.Testing --version 8.0.11
dotnet add package  Testcontainers.MySql

# nuget
# Microsoft.AspNetCore.Mvc.Testing
# Testcontainers.MySql

<ItemGroup>
    <ProjectReference Include="..\StudentBloggAPI\StudentBloggAPI.csproj" />
</ItemGroup>

```

[youtube: https://www.youtube.com/watch?v=8IRNC7qZBmk](https://www.youtube.com/watch?v=8IRNC7qZBmk)