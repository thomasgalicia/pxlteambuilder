using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PxlTeambuilderApi.Data.Interfaces;

namespace PxlTeambuilderApi.Bootstrap
{
    public abstract class Factory
    {
        private readonly List<IJoinable> _joinables = new List<IJoinable>();

        public List<IJoinable> Joinables => _joinables;

        public Factory()
        {
            this.CreateJoinables();
        }

        //Factory method
        public abstract void CreateJoinables();
    }
}
