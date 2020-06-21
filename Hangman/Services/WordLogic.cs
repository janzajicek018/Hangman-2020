using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Services
{
    public class WordLogic
    {
        readonly SessionStorage _session;
        public Category Category { get; set; }

        public WordLogic(SessionStorage ss)
        {
            _session = ss;
            Category = _session.Category;
        }
    }
}
