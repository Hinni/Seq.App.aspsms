
# Arrange
$directory = Split-Path $MyInvocation.MyCommand.Path

# Create NuGet Package
& $directory\packages\NuGet.CommandLine.4.5.1\tools\NuGet.exe pack $directory\Seq.App.aspsms\Seq.App.aspsms.csproj -OutputDirectory $directory -Prop Configuration=Release
