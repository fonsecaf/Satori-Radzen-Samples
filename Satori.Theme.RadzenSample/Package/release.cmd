del "*.nupkg"
"..\..\Oqtane-Framework-5.0.1\oqtane.package\nuget.exe" pack Satori.Theme.RadzenSample.nuspec 
XCOPY "*.nupkg" "..\..\Oqtane-Framework-5.0.1\Oqtane.Server\wwwroot\Themes\" /Y
