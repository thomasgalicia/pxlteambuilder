using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PxlTeambuilderApi.Data.Domain;

namespace PxlTeambuilderApi.Bootstrap
{
    public class ProjectFactory: Factory
    {
        public override void CreateJoinables()
        {
            Joinables.Add(new Project());
            Joinables.Add(new Project());
            Joinables.Add(new Project());
            Joinables.Add(new Project());
        }
    }
}
