using Hangman.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman.Helpers;

namespace Hangman.Services
{
    public class SessionStorage
    {
        public ISession _session;
        const string test = "TEST";

        public Category Category { get; set; }

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
            Category = _session.Get<Category>(test);
        }

        public void SaveTest(Category cat)
        {
            _session.Set(test, cat);
        }

    }
}
