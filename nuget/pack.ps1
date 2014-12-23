$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\src\Conditions\bin\Release\Conditions.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\NuGet\Conditions.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\nuget\Conditions.compiled.nuspec

& $root\NuGet\NuGet.exe pack $root\nuget\Conditions.compiled.nuspec -Symbols
