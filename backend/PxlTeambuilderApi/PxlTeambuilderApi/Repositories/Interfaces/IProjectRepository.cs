using PxlTeambuilderApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Repositories.Implementations
{
    public interface IProjectRepository
    {
        Project GetProjectById(string projectId);
        Project AddProject(Project project);
        Project UpdateProject(string projectId, Project project);
    }
}
