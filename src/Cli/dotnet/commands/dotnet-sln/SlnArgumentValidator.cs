// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.DotNet.Cli;
using Microsoft.DotNet.Cli.Utils;

namespace Microsoft.DotNet.Tools.Sln;

internal static class SlnArgumentValidator
{
    public enum CommandType
    {
        Add,
        Remove
    }
    public static void ParseAndValidateArguments(IReadOnlyCollection<string> _arguments, CommandType commandType, bool _inRoot = false, string relativeRoot = null, string subcommand = null)
    {
        if (_arguments.Count == 0)
        {
            string message = commandType == CommandType.Add
                ? CommonLocalizableStrings.SpecifyAtLeastOneProjectToAdd
                : CommonLocalizableStrings.SpecifyAtLeastOneProjectToRemove;
            throw new GracefulException(message);
        }

        bool hasRelativeRoot = !string.IsNullOrEmpty(relativeRoot);

        if (_inRoot && hasRelativeRoot)
        {
            // These two options are mutually exclusive
            throw new GracefulException(LocalizableStrings.SolutionFolderAndInRootMutuallyExclusive);
        }

        var slnFile = _arguments.FirstOrDefault(path => path.EndsWith(".sln"));
        if (slnFile == null)
        {
            return;
        }

        string args = _inRoot
            ? $"{SlnAddParser.InRootOption.Name} "
            : hasRelativeRoot ? $"{SlnAddParser.SolutionFolderOption.Name} {string.Join(" ", relativeRoot)} " : "";
        var nonSolutionArguments = string.Join(" ", _arguments.Where(path => !path.EndsWith(".sln")));
        string command = commandType switch
        {
            CommandType.Add => "add",
            CommandType.Remove => "remove",
            _ => throw new InvalidOperationException($"Unable to handle command type {commandType}"),
        };
        throw new GracefulException(
        [
            string.Format(CommonLocalizableStrings.SolutionArgumentMisplaced, slnFile),
                CommonLocalizableStrings.DidYouMean,
                subcommand == null
                    ? $"  dotnet solution {slnFile} {command} {args}{nonSolutionArguments}"
                    : $"  dotnet solution {slnFile} {command} {subcommand} {args}{nonSolutionArguments}"
        ]);
    }
}
