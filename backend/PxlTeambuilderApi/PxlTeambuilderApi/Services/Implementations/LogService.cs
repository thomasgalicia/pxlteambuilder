using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PxlTeambuilderApi.Services.Abstract;

namespace PxlTeambuilderApi.Services.Implementations
{
    public class LogService : Logger
    {
        private string _name;

        private ProjectService _subject;
        public ProjectService Subject
        {
            get => _subject;
            set => _subject = value;
        }

        public LogService(ProjectService subject, string name)
        {
            _subject = subject;
            _name = name;
        }

        public override void Log()
        {
            Debug.WriteLine($"{_name} : {this._subject.State}");
        }
    }
}