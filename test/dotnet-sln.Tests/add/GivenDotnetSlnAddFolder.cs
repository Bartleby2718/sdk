// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.DotNet.Cli.Sln.Internal;
using Microsoft.DotNet.Cli.Utils;
using Microsoft.DotNet.Tools;
using Microsoft.DotNet.Tools.Common;

namespace Microsoft.DotNet.Cli.Sln.Add.Tests;

public class GivenDotnetSlnAddFolder(ITestOutputHelper log) : SdkTest(log)
{
    private readonly Func<string, string> HelpText = (defaultVal) => $@"Description:
  Add one or more solution folders to a solution file.

Usage:
  dotnet solution [<SLN_FILE>] add [<PROJECT_PATH>...] folder <FOLDER_PATH>... [options]

Arguments:
  <SLN_FILE>        The solution file to operate on. If not specified, the command will search the current directory for one. [default: {PathUtility.EnsureTrailingSlash(defaultVal)}]
  <PROJECT_PATH>    The paths to the projects to add to the solution.
  <FOLDER_PATH>     The paths to the solution folders to add to the solution.

Options:
  --in-root                                  Place folder in root of the solution, rather than creating a solution folder.
  -s, --solution-folder <solution-folder>    The destination solution folder path to add the folders to.
  -?, -h, --help                             Show command line help.";
    private const string ExpectedSlnFileAfterAddingNestedFolder = @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26006.2
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{9A19103F-16F7-4668-BE54-9A1E7A4F7556}"") = ""App"", ""App.csproj"", ""{7072A694-548F-4CAE-A58F-12D257D5F486}""
EndProject
Project(""{2150E333-8FDC-42A3-9474-1A3956D46DE8}"") = ""Lib"", ""src\Lib"", ""__SRC_LIB_FOLDER_GUID__""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Debug|x64 = Debug|x64
		Debug|x86 = Debug|x86
		Release|Any CPU = Release|Any CPU
		Release|x64 = Release|x64
		Release|x86 = Release|x86
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x64.ActiveCfg = Debug|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x64.Build.0 = Debug|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x86.ActiveCfg = Debug|x86
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x86.Build.0 = Debug|x86
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|Any CPU.Build.0 = Release|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x64.ActiveCfg = Release|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x64.Build.0 = Release|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x86.ActiveCfg = Release|x86
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x86.Build.0 = Release|x86
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
";
    private const string ExpectedSlnFileAfterAddingFolderWithInRootOption = @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26006.2
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{9A19103F-16F7-4668-BE54-9A1E7A4F7556}"") = ""App"", ""App.csproj"", ""{7072A694-548F-4CAE-A58F-12D257D5F486}""
EndProject
Project(""{2150E333-8FDC-42A3-9474-1A3956D46DE8}"") = ""Lib"", ""src\Lib"", ""__SRC_LIB_FOLDER_GUID__""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Debug|x64 = Debug|x64
		Debug|x86 = Debug|x86
		Release|Any CPU = Release|Any CPU
		Release|x64 = Release|x64
		Release|x86 = Release|x86
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x64.ActiveCfg = Debug|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x64.Build.0 = Debug|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x86.ActiveCfg = Debug|x86
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x86.Build.0 = Debug|x86
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|Any CPU.Build.0 = Release|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x64.ActiveCfg = Release|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x64.Build.0 = Release|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x86.ActiveCfg = Release|x86
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x86.Build.0 = Release|x86
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
";

    private const string ExpectedSlnFileAfterAddingProjectWithSolutionFolderOption = @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26006.2
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{9A19103F-16F7-4668-BE54-9A1E7A4F7556}"") = ""App"", ""App.csproj"", ""{7072A694-548F-4CAE-A58F-12D257D5F486}""
EndProject
Project(""{2150E333-8FDC-42A3-9474-1A3956D46DE8}"") = ""TestFolder"", ""TestFolder"", ""__SOLUTION_FOLDER_GUID__""
EndProject
Project(""{2150E333-8FDC-42A3-9474-1A3956D46DE8}"") = ""src"", ""src"", ""__SRC_FOLDER_GUID__""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Debug|x64 = Debug|x64
		Debug|x86 = Debug|x86
		Release|Any CPU = Release|Any CPU
		Release|x64 = Release|x64
		Release|x86 = Release|x86
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x64.ActiveCfg = Debug|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x64.Build.0 = Debug|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x86.ActiveCfg = Debug|x86
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Debug|x86.Build.0 = Debug|x86
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|Any CPU.Build.0 = Release|Any CPU
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x64.ActiveCfg = Release|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x64.Build.0 = Release|x64
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x86.ActiveCfg = Release|x86
		{7072A694-548F-4CAE-A58F-12D257D5F486}.Release|x86.Build.0 = Release|x86
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(NestedProjects) = preSolution
		__SRC_FOLDER_GUID__ = __SOLUTION_FOLDER_GUID__
	EndGlobalSection
EndGlobal
";

    [Theory]
    [InlineData("sln", "--help")]
    [InlineData("sln", "-h")]
    [InlineData("sln", "-?")]
    [InlineData("sln", "/?")]
    [InlineData("solution", "--help")]
    [InlineData("solution", "-h")]
    [InlineData("solution", "-?")]
    [InlineData("solution", "/?")]
    public void WhenHelpOptionIsPassedItPrintsUsage(string solutionCommand, string helpArg)
    {
        var cmd = new DotnetCommand(Log)
            .Execute(solutionCommand, "add", "folder", helpArg);
        cmd.Should().Pass();
        cmd.StdOut.Should().BeVisuallyEquivalentToIfNotLocalized(HelpText(Directory.GetCurrentDirectory()));
    }

    [Theory]
    [InlineData("sln", "")]
    [InlineData("sln", "unknownCommandName")]
    [InlineData("solution", "")]
    [InlineData("solution", "unknownCommandName")]
    public void WhenNoCommandIsPassedItPrintsError(string solutionCommand, string commandName)
    {
        var cmd = new DotnetCommand(Log)
            .Execute($"{solutionCommand} {commandName}".Trim().Split());
        cmd.Should().Fail()
            .And.HaveStdErr(CommonLocalizableStrings.RequiredCommandNotPassed);
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenTooManyArgumentsArePassedItPrintsError(string solutionCommand)
    {
        var cmd = new DotnetCommand(Log)
            .Execute(solutionCommand, "one.sln", "two.sln", "three.sln", "add", "folder", "myFolder");
        cmd.Should().Fail();
        cmd.StdErr.Should().BeVisuallyEquivalentTo($@"{string.Format(CommandLineValidation.LocalizableStrings.UnrecognizedCommandOrArgument, "two.sln")}
{string.Format(CommandLineValidation.LocalizableStrings.UnrecognizedCommandOrArgument, "three.sln")}");
    }

    [Theory]
    [InlineData("sln", "idontexist.sln")]
    [InlineData("sln", "ihave?invalidcharacters")]
    [InlineData("sln", "ihaveinv@lidcharacters")]
    [InlineData("sln", "ihaveinvalid/characters")]
    [InlineData("sln", "ihaveinvalidchar\\acters")]
    [InlineData("solution", "idontexist.sln")]
    [InlineData("solution", "ihave?invalidcharacters")]
    [InlineData("solution", "ihaveinv@lidcharacters")]
    [InlineData("solution", "ihaveinvalid/characters")]
    [InlineData("solution", "ihaveinvalidchar\\acters")]
    public void WhenNonExistingSolutionIsPassedItPrintsErrorAndUsage(string solutionCommand, string solutionName)
    {
        var cmd = new DotnetCommand(Log)
            .Execute(solutionCommand, solutionName, "add", "folder", "myFolder");
        cmd.Should().Fail()
            .And.HaveStdErr(string.Format(CommonLocalizableStrings.CouldNotFindSolutionOrDirectory, solutionName))
            .And.HaveStdOut("");
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenInvalidSolutionIsPassedItPrintsErrorAndUsage(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("InvalidSolution", identifier: solutionCommand)
            .WithSource()
            .Path;

        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "InvalidSolution.sln", "add", "folder", "MyFolder");
        cmd.Should().Fail()
            .And.HaveStdErr(string.Format(CommonLocalizableStrings.InvalidSolutionFormatString, "InvalidSolution.sln", LocalizableStrings.FileHeaderMissingError))
            .And.HaveStdOut("");
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenInvalidSolutionIsFoundAddPrintsErrorAndUsage(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("InvalidSolution", identifier: solutionCommand)
            .WithSource()
            .Path;

        var solutionPath = Path.Combine(projectDirectory, "InvalidSolution.sln");
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "add", "folder", "MyFolder");
        cmd.Should().Fail()
            .And.HaveStdErr(string.Format(CommonLocalizableStrings.InvalidSolutionFormatString, solutionPath, LocalizableStrings.FileHeaderMissingError))
            .And.HaveStdOut("");
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenNoFolderIsPassedItPrintsErrorAndUsage(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCsprojFiles", identifier: solutionCommand)
            .WithSource()
            .Path;

        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder");
        cmd.Should().Fail()
            .And.HaveStdErr("Required argument missing for command: 'folder'.");
        cmd.StdOut.Should().BeVisuallyEquivalentToIfNotLocalized(HelpText(projectDirectory));
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenNoSolutionExistsInTheDirectoryAddPrintsErrorAndUsage(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCsprojFiles", identifier: solutionCommand)
            .WithSource()
            .Path;

        var solutionPath = Path.Combine(projectDirectory, "App");
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(solutionPath)
            .Execute(solutionCommand, "add", "folder", "App");
        cmd.Should().Fail()
            .And.HaveStdErr(string.Format(CommonLocalizableStrings.SolutionDoesNotExist, solutionPath + Path.DirectorySeparatorChar))
            .And.HaveStdOut("");
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenMoreThanOneSolutionExistsInTheDirectoryItPrintsErrorAndUsage(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithMultipleSlnFiles", identifier: "GivenDotnetSlnAddFolder")
            .WithSource()
            .Path;

        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "add", "folder", "folderToAdd");
        cmd.Should().Fail()
            .And.HaveStdErr(string.Format(CommonLocalizableStrings.MoreThanOneSolutionInDirectory, projectDirectory + Path.DirectorySeparatorChar))
            .And.HaveStdOut("");
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenNestedFolderIsAddedSolutionFoldersAreCreated(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCsprojInSubDir")
            .WithSource()
            .Path;

        var folderToAdd = Path.Combine("src", "Lib");
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));

        var slnPath = Path.Combine(projectDirectory, "App.sln");
        var expectedSlnContents = GetExpectedSlnContents(slnPath, ExpectedSlnFileAfterAddingNestedFolder);
        File.ReadAllText(slnPath)
            .Should().BeVisuallyEquivalentTo(expectedSlnContents);
    }

    [Theory]
    [InlineData("sln", true)]
    [InlineData("sln", false)]
    [InlineData("solution", true)]
    [InlineData("solution", false)]
    public void WhenNestedProjectIsAddedSolutionFoldersAreCreatedBuild(string solutionCommand, bool fooFirst)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCsprojInSubDirVS", identifier: $"{solutionCommand}{fooFirst}")
            .WithSource()
            .Path;
        string folderToAdd;
        CommandResult cmd;

        if (fooFirst)
        {
            folderToAdd = "foo";
            cmd = new DotnetCommand(Log)
                .WithWorkingDirectory(projectDirectory)
                .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
            cmd.Should().Pass()
                .And.HaveStdErr("")
                .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));
        }

        folderToAdd = Path.Combine("foo", "bar");
        cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));

        if (!fooFirst)
        {
            folderToAdd = "foo";
            cmd = new DotnetCommand(Log)
                .WithWorkingDirectory(projectDirectory)
                .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
            cmd.Should().Pass()
                .And.HaveStdErr("")
                .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));
        }
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenNestedDuplicateProjectIsAddedToASolutionFolder(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
           .CopyTestAsset("TestAppWithSlnAndCsprojInSubDirVSErrors", identifier: solutionCommand)
           .WithSource()
           .Path;
        string folderToAdd;
        CommandResult cmd;

        folderToAdd = Path.Combine("Base", "Second", "TestCollision.csproj");
        cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        cmd.Should().Fail()
            .And.HaveStdErrContaining("TestCollision")
            .And.HaveStdErrContaining("Base");

        folderToAdd = Path.Combine("Base", "Second", "Third", "Second.csproj");
        cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        cmd.Should().Fail()
            .And.HaveStdErrContaining("Second")
            .And.HaveStdErrContaining("Base");
    }

    [Theory]
    [InlineData("sln", ".")]
    [InlineData("sln", "")]
    [InlineData("solution", ".")]
    [InlineData("solution", "")]
    public void WhenSolutionFolderExistsItDoesNotGetAdded(string solutionCommand, string firstComponent)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndSolutionFolders", identifier: $"{solutionCommand}{firstComponent}")
            .WithSource()
            .Path;

        var normalizedFolderPath = Path.Combine("src", "src", "Lib");
        var folderToAdd = Path.Combine(firstComponent, normalizedFolderPath);
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, normalizedFolderPath));

        var slnFile = SlnFile.Read(Path.Combine(projectDirectory, "App.sln"));
        slnFile.Projects.Count.Should().Be(3);

        var solutionFolderProjects = slnFile.Projects.Where(
            p => p.TypeGuid == ProjectTypeGuids.SolutionFolderGuid);
        solutionFolderProjects.Count().Should().Be(2);

        var solutionFolders = slnFile.Sections.GetSection("NestedProjects").Properties;
        solutionFolders.Count.Should().Be(2);

        solutionFolders["{DDF3765C-59FB-4AA6-BE83-779ED13AA64A}"]
            .Should().Be("{72BFCA87-B033-4721-8712-4D12166B4A39}");

        var newlyAddedSrcFolder = solutionFolderProjects.Single(p => p.Id != "{72BFCA87-B033-4721-8712-4D12166B4A39}");
        solutionFolders[newlyAddedSrcFolder.Id]
            .Should().Be("{72BFCA87-B033-4721-8712-4D12166B4A39}");

        var libFolder = slnFile.Projects.Single(p => p.Name == "Lib");
        solutionFolders[libFolder.Id]
            .Should().Be("{72BFCA87-B033-4721-8712-4D12166B4A39}");
    }

    [Theory]
    [InlineData("sln", "TestAppWithSlnAndCsprojFiles")]
    [InlineData("sln", "TestAppWithSlnAndCsprojProjectGuidFiles")]
    [InlineData("sln", "TestAppWithEmptySln")]
    [InlineData("solution", "TestAppWithSlnAndCsprojFiles")]
    [InlineData("solution", "TestAppWithSlnAndCsprojProjectGuidFiles")]
    [InlineData("solution", "TestAppWithEmptySln")]
    public void WhenValidFolderIsPassedItGetsAdded(string solutionCommand, string testAsset)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset(testAsset, identifier: $"{solutionCommand}{testAsset}")
            .WithSource()
            .Path;

        const string folderToAdd = "Empty";
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));
    }

    [Theory]
    [InlineData("sln", "TestAppWithSlnAndCsprojFiles")]
    [InlineData("sln", "TestAppWithSlnAndCsprojProjectGuidFiles")]
    [InlineData("sln", "TestAppWithEmptySln")]
    [InlineData("solution", "TestAppWithSlnAndCsprojFiles")]
    [InlineData("solution", "TestAppWithSlnAndCsprojProjectGuidFiles")]
    [InlineData("solution", "TestAppWithEmptySln")]
    public void WhenValidSolutionFolderInSolutionRootIsPassedItGetsAdded(string solutionCommand, string testAsset)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset(testAsset, identifier: $"{solutionCommand}{testAsset}")
            .WithSource()
            .Path;

        const string folderToAdd = "MySolutionFolder";
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));
    }

    [Theory]
    [InlineData("sln", "TestAppWithSlnAndCsprojFiles")]
    [InlineData("sln", "TestAppWithSlnAndCsprojProjectGuidFiles")]
    [InlineData("sln", "TestAppWithEmptySln")]
    [InlineData("solution", "TestAppWithSlnAndCsprojFiles")]
    [InlineData("solution", "TestAppWithSlnAndCsprojProjectGuidFiles")]
    [InlineData("solution", "TestAppWithEmptySln")]
    public void WhenValidNestedSolutionFolderIsPassedItGetsAdded(string solutionCommand, string testAsset)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset(testAsset, identifier: $"{solutionCommand}{testAsset}")
            .WithSource()
            .Path;

        const string folderToAdd = "Empty";
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));
    }

    [Theory]
    [InlineData("sln", "TestAppWithSlnAndSolutionFolders")]
    [InlineData("solution", "TestAppWithSlnAndSolutionFolders")]
    public void WhenSolutionAlreadyContainsFolderItDoesntDuplicate(string solutionCommand, string testAsset)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset(testAsset, identifier: $"{solutionCommand}{testAsset}")
            .WithSource()
            .Path;

        const string folderToAdd = "src";
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        var slnPath = Path.Combine(projectDirectory, "App.sln");
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionAlreadyContainsFolder, slnPath, folderToAdd));
    }

    [Theory]
    [InlineData("sln", "SlnFileWithNoProjectReferencesAndCSharpProject", "CSharpProject", ProjectTypeGuids.SolutionFolderGuid)]
    public void WhenPassedAFolderItAddsCorrectProjectTypeGuid(
        string solutionCommand,
        string testAsset,
        string folderToAdd,
        string expectedTypeGuid)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset(testAsset, identifier: $"{solutionCommand}{testAsset}")
            .WithSource()
            .Path;

        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", folderToAdd);
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));

        var slnFile = SlnFile.Read(Path.Combine(projectDirectory, "App.sln"));
        var solutionFolderProjects = slnFile.Projects.Where(
            p => p.TypeGuid == ProjectTypeGuids.SolutionFolderGuid);
        solutionFolderProjects.Count().Should().Be(1);
        solutionFolderProjects.Single().TypeGuid.Should().Be(expectedTypeGuid);
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenSlnContainsSolutionFolderWithDifferentCasingItDoesNotCreateDuplicate(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCaseSensitiveSolutionFolders", identifier: solutionCommand)
            .WithSource()
            .Path;

        const string folderToAdd = "src";
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", "src");
        var slnPath = Path.Combine(projectDirectory, "App.sln");
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionAlreadyContainsFolder, slnPath, folderToAdd));

        var slnFile = SlnFile.Read(slnPath);
        var solutionFolderProjects = slnFile.Projects.Where(
            p => p.TypeGuid == ProjectTypeGuids.SolutionFolderGuid);
        solutionFolderProjects.Count().Should().Be(1);
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenNestedProjectIsAddedAndInRootOptionIsPassedNoSolutionFoldersAreCreated(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCsprojInSubDir", identifier: solutionCommand)
            .WithSource()
            .Path;

        var folderToAdd = Path.Combine("src", "Lib");
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", "--in-root", folderToAdd);
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));

        var slnPath = Path.Combine(projectDirectory, "App.sln");
        var expectedSlnContents = GetExpectedSlnContents(slnPath, ExpectedSlnFileAfterAddingFolderWithInRootOption);
        File.ReadAllText(slnPath)
            .Should().BeVisuallyEquivalentTo(expectedSlnContents);
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenSolutionFolderIsPassedProjectsAreAddedThere(string solutionCommand)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCsprojInSubDir", identifier: solutionCommand)
            .WithSource()
            .Path;

        const string folderToAdd = "src";
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", "--solution-folder", "TestFolder", folderToAdd);
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));

        var slnPath = Path.Combine(projectDirectory, "App.sln");
        var expectedSlnContents = GetExpectedSlnContents(slnPath, ExpectedSlnFileAfterAddingProjectWithSolutionFolderOption);
        File.ReadAllText(slnPath)
            .Should().BeVisuallyEquivalentTo(expectedSlnContents);
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenSolutionFolderAndInRootIsPassedItFails(string solutionCommand)
    {
        var solutionDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCsprojInSubDir", identifier: solutionCommand)
            .WithSource()
            .Path;

        var solutionPath = Path.Combine(solutionDirectory, "App.sln");
        var contentBefore = File.ReadAllText(solutionPath);

        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(solutionDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", "--solution-folder", "blah", "--in-root", "src");
        cmd.Should().Fail()
            .And.HaveStdErr(Tools.Sln.LocalizableStrings.SolutionFolderAndInRootMutuallyExclusive)
            .And.HaveStdOut("");

        File.ReadAllText(solutionPath)
            .Should()
            .BeVisuallyEquivalentTo(contentBefore);
    }

    [Theory]
    [InlineData("sln", "/TestFolder//", "ForwardSlash")]
    [InlineData("sln", "\\TestFolder\\\\", "BackwardSlash")]
    [InlineData("solution", "/TestFolder//", "ForwardSlash")]
    [InlineData("solution", "\\TestFolder\\\\", "BackwardSlash")]
    public void WhenSolutionFolderIsPassedWithDirectorySeparatorFolderStructureIsCorrect(string solutionCommand, string solutionFolder, string testIdentifier)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCsprojInSubDir", identifier: $"{solutionCommand}{testIdentifier}")
            .WithSource()
            .Path;

        const string folderToAdd = "src";
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute(solutionCommand, "App.sln", "add", "folder", "--solution-folder", solutionFolder, "src");
        cmd.Should().Pass()
            .And.HaveStdErr("")
            .And.HaveStdOut(string.Format(CommonLocalizableStrings.SolutionFolderAddedToTheSolution, folderToAdd));

        var slnPath = Path.Combine(projectDirectory, "App.sln");
        var expectedSlnContents = GetExpectedSlnContents(slnPath, ExpectedSlnFileAfterAddingProjectWithSolutionFolderOption);
        File.ReadAllText(slnPath)
            .Should().BeVisuallyEquivalentTo(expectedSlnContents);
    }

    private static string GetExpectedSlnContents(
        string slnPath,
        string slnTemplate)
    {
        var slnFile = SlnFile.Read(slnPath);

        var slnContents = slnTemplate;

        var matchingSrcFolder = slnFile.Projects
                .Where((p) => p.FilePath == "src")
                .ToList();
        if (matchingSrcFolder.Count == 1)
        {
            slnContents = slnContents.Replace("__SRC_FOLDER_GUID__", matchingSrcFolder[0].Id);
        }

        var matchingSrcLibFolder = slnFile.Projects
                .Where((p) => p.FilePath == @"src\Lib")
                .ToList();
        if (matchingSrcLibFolder.Count == 1)
        {
            slnContents = slnContents.Replace("__SRC_LIB_FOLDER_GUID__", matchingSrcLibFolder[0].Id);
        }

        var matchingSolutionFolder = slnFile.Projects
                .Where((p) => p.FilePath == "TestFolder")
                .ToList();
        if (matchingSolutionFolder.Count == 1)
        {
            slnContents = slnContents.Replace("__SOLUTION_FOLDER_GUID__", matchingSolutionFolder[0].Id);
        }

        return slnContents;
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenSolutionIsPassedAsFolderItPrintsSuggestionAndUsage(string solutionCommand)
    {
        VerifySuggestionAndUsage(solutionCommand, "");
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenSolutionIsPassedAsFolderWithInRootItPrintsSuggestionAndUsage(string solutionCommand)
    {
        VerifySuggestionAndUsage(solutionCommand, "--in-root");
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("solution")]
    public void WhenSolutionIsPassedAsFolderWithSolutionFolderItPrintsSuggestionAndUsage(string solutionCommand)
    {
        VerifySuggestionAndUsage(solutionCommand, "--solution-folder", "TestFolder");
    }

    private void VerifySuggestionAndUsage(string solutionCommand, params string[] arguments)
    {
        var projectDirectory = _testAssetsManager
            .CopyTestAsset("TestAppWithSlnAndCsprojFiles", identifier: $"{solutionCommand}{arguments}")
            .WithSource()
            .Path;

        const string folderArg = "src";
        var cmd = new DotnetCommand(Log)
            .WithWorkingDirectory(projectDirectory)
            .Execute([solutionCommand, "add", "folder", .. arguments, folderArg, "App.sln"]);
        cmd.Should().Fail()
            .And.HaveStdOut("");
        cmd.StdErr.Should().BeVisuallyEquivalentTo(
            string.Format(CommonLocalizableStrings.SolutionArgumentMisplaced, "App.sln") + Environment.NewLine
            + CommonLocalizableStrings.DidYouMean + Environment.NewLine
            + (arguments.Length == 0
                ? $"  dotnet solution App.sln add folder {folderArg}"
                : $"  dotnet solution App.sln add folder {string.Join(" ", arguments)} {folderArg}")
        );
    }
}
