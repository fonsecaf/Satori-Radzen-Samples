del "*.nupkg"
"..\..\Oqtane-Framework-5.0.1\oqtane.package\nuget.exe" pack Satori.Module.RadzenSample.nuspec 
XCOPY "*.nupkg" "..\..\Oqtane-Framework-5.0.1\Oqtane.Server\Packages\" /Y

