using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Services.Abstract
{
    public abstract class LogComponent
    {
        private readonly List<Logger> _loggers = new List<Logger>();

        public string State { get; set; }


        public void Attach(Logger logger)
        {
            _loggers.Add(logger);
        }

        public void Detach(Logger logger)
        {
            _loggers.Remove(logger);
        }

        public void Notify()
        {
            foreach (Logger o in _loggers)
            {
                o.Log();
            }
        }


    }
}
