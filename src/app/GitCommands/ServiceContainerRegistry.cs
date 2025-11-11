using System.ComponentModel.Design;
using GitCommands.Submodules;
using GitExtUtils;

namespace GitCommands;

public static class ServiceContainerRegistry
{
    public static void RegisterServices(ServiceContainer serviceContainer)
    {
        RepositoryCurrentBranchNameProvider repositoryCurrentBranchNameProvider = new();
        serviceContainer.AddService<ISubmoduleStatusProvider>(new SubmoduleStatusProvider(repositoryCurrentBranchNameProvider));
        serviceContainer.AddService<IRepositoryCurrentBranchNameProvider>(repositoryCurrentBranchNameProvider);
    }
}
