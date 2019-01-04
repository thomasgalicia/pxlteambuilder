using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Exceptions
{
    public class ProjectNotFoundException : Exception
    {

        public ProjectNotFoundException(string projectId) : base($"project with id:{projectId} was not found")
        {

        }
    }
}
