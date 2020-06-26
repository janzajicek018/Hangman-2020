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
        const string GUESSING = "GUESSINGLETTERS";

        public Category Category { get; set; }
        public CategoryChoice Choice { get; set; }
        public char[] GuessingLetters { get; set; }
        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
            Choice = _session.Get<CategoryChoice>(CHOICEKEY);
            Category = _session.Get<Category>(CATKEY);
            GuessingLetters = _session.Get<char[]>(GUESSING);
        }

        public void SaveCategory(Category cat)
        {
            _session.Set(CATKEY, cat);
        }
        public void SaveCatChoice(CategoryChoice choice)
        {
            _session.Set(CHOICEKEY, choice);
        }
        public void SaveGuessingLetters(char[] letters)
        {
            _session.Set(GUESSING, letters);
        }
        public char[] GetGuessingLetters()
        {
            return _session.Get<char[]>(GUESSING);
        }
    }
}
