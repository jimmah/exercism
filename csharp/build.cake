#tool nuget:?package=NUnit.ConsoleRunner&version=3.6.0

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var buildDir = Directory("./bin") + Directory(configuration);

Task("Clean")
    .Does(() => 
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./exercism.csproj", new NuGetRestoreSettings {PackagesDirectory = "./packages"});
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() => 
{
    if(IsRunningOnWindows()) 
    {
        MSBuild("./exercism.csproj", s => s.SetConfiguration(configuration));
    }
    else 
    {
        XBuild("./exercism.csproj", s => s.SetConfiguration(configuration));
    }
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() => 
{
    NUnit3("./bin/" + configuration + "/exercism.dll", new NUnit3Settings {NoResults = true});
});

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

RunTarget(target);