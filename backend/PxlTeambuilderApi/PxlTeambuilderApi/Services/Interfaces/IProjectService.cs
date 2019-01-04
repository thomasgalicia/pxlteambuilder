using PxlTeambuilderApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Services.Interfaces
{
    public interface IProjectService
    {

        Project GetProjectById(int projectId);
        Project AddProject(Project project);
        Project UpdateProject(int projectId, Project project);

    }
}
