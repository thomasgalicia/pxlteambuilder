using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PxlTeambuilderApi.Services.Abstract;
using PxlTeambuilderApi.Services.Interfaces;

namespace PxlTeambuilderApi.Services.Implementations
{
    public class LogService : Logger
    {
        private string _name;

        private Stateable _subject;
        public Stateable Subject
        {
            get => _subject;
            set => _subject = value;
        }

        public LogService(Stateable subject, string name)
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