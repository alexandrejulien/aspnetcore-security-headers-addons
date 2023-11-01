

# Add Permissions Policy headers to ASP.NET Core (Addons to Joonasw ASP.NET Core Security Headers library)
 ![Nuget](https://img.shields.io/nuget/v/Peppermint.AspNetCore.SecurityHeaders.Addons)
[![GitHub tag](https://img.shields.io/github/tag/alexandrejulien/aspnetcore-security-headers-addons?include_prereleases=&sort=semver&color=blue)](https://github.com/alexandrejulien/aspnetcore-security-headers-addons/releases/)
[![License](https://img.shields.io/badge/License-MIT-blue)](#license)
[![issues - aspnetcore-security-headers-addons](https://img.shields.io/github/issues/alexandrejulien/aspnetcore-security-headers-addons)](https://github.com/alexandrejulien/aspnetcore-security-headers-addons/issues)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=alexandrejulien_aspnetcore-security-headers-addons&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=alexandrejulien_aspnetcore-security-headers-addons)

"AspNetCore.SecurityHeaders.Addons" is an extensions library to the greafull Joonasw ASP.NET Core Security Headers library :
https://github.com/juunas11/aspnetcore-security-headers

Actualy, the addons cover the "Permissions-Policy" which is the renamed version of "Features-Policy" headers.

The library is available on Nuget : https://www.nuget.org/packages/Peppermint.AspNetCore.SecurityHeaders.Addons

# Usage

```csharp
// Dependency injection
app.UsePermissionsPolicy();
```

# Compatibility

- .NET 6 runtime (LTS)
- .NET 7 runtime (STS)
- .NET 8 (Preview) (LTS)

# Tiers-libraries

Thanks to Joonasw library : https://github.com/juunas11/aspnetcore-security-headers

# Badges

[![Quality gate](https://sonarcloud.io/api/project_badges/quality_gate?project=alexandrejulien_aspnetcore-security-headers-addons)](https://sonarcloud.io/summary/new_code?id=alexandrejulien_aspnetcore-security-headers-addons)
