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
        const string CATKEY = "CATEGORY";
        const string CHOICEKEY = "CHOICE";

        public Category Category { get; set; }
        public CategoryChoice Choice { get; set; }

        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
            Choice = _session.Get<CategoryChoice>(CHOICEKEY);
            Category = _session.Get<Category>(CATKEY);
        }

        public void SaveCategory(Category cat)
        {
            _session.Set(CATKEY, cat);
        }
        public void SaveCatChoice(CategoryChoice choice)
        {
            _session.Set(CHOICEKEY, choice);
        }
    }
}
