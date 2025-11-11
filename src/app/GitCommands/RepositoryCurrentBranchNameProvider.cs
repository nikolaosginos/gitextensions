using GitCommands.Git;
using GitExtensions.Extensibility.Git;

namespace GitCommands;

/// <summary>
///  Provides the name of the currently checked out branch in a repository.
/// </summary>
public interface IRepositoryCurrentBranchNameProvider
{
    /// <summary>
    ///  Gets the name of the currently checked out branch for the specified repository.
    /// </summary>
    /// <param name="repositoryPath">The path to the repository.</param>
    /// <returns>The current branch name.</returns>
    string GetCurrentBranchName(string repositoryPath);
}

public sealed class RepositoryCurrentBranchNameProvider : IRepositoryCurrentBranchNameProvider
{
    public string GetCurrentBranchName(string repositoryPath)
    {
        if (!AppSettings.ShowRepoCurrentBranch)
        {
            return string.Empty;
        }

        string branchName = GitModule.GetSelectedBranchFast(repositoryPath);

        if (!string.IsNullOrEmpty(branchName) && branchName != ".invalid")
        {
            return branchName;
        }

        return new GitModule(repositoryPath).GetSelectedBranch(false, false);
    }
}
