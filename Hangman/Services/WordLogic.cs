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
        readonly CategoriesContainer _cc;
        public Category Category { get; set; }

        public WordLogic(SessionStorage ss, CategoriesContainer cc)
        {
            _session = ss;
            _cc = cc;
            Category = _cc.Categories[_session.Choice];

        }
    }
}
