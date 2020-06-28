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
        const string RANDOMIZED = "RANDOMIZED";
        const string CURRWORD = "CURRWORD";
        const string WORDLIST = "WORDLIST";
        const string WORDCOUNT = "WORDCOUNT";
        const string LIVES = "LIVES";
        const string COND = "CONDITION";

        public Category Category { get; set; }
        public CategoryChoice Choice { get; set; }
        public List<Word> Words { get; set; }
        public Word CurrentWord { get; set; }
        public char[] GuessingLetters { get; set; }
        public bool Randomized { get; set; }
        public int WordCount { get; set; }
        public int Lives { get; set; }
        public int VictoryCondition { get; set; }
        public SessionStorage(IHttpContextAccessor hce)
        {
            _session = hce.HttpContext.Session;
            Choice = _session.Get<CategoryChoice>(CHOICEKEY);
            Category = _session.Get<Category>(CATKEY);
            GuessingLetters = _session.Get<char[]>(GUESSING);
            Randomized = _session.Get<bool>(RANDOMIZED);
            CurrentWord = _session.Get<Word>(CURRWORD);
            Words = _session.Get<List<Word>>(WORDLIST);
            WordCount = _session.Get<int>(WORDCOUNT);
            Lives = _session.Get<int>(LIVES);
            VictoryCondition = _session.Get<int>(COND);
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
        public void SaveRandomized(bool randomized)
        {
            _session.Set(RANDOMIZED, randomized);
        }
        public void SaveCurrentWord(Word word)
        {
            _session.Set(CURRWORD, word);
        }
        public void SaveWordList(List<Word> list)
        {
            _session.Set(WORDLIST, list);
        }
        public void SaveWordCount(int count)
        {
            _session.Set(WORDCOUNT, count);
        }
        public void SaveLives(int lives)
        {
            _session.Set(LIVES, lives);
        }
        public void SaveCondition(int condition)
        {
            _session.Set(COND, condition);
        }
        public char[] GetGuessingLetters()
        {
            return _session.Get<char[]>(GUESSING);
        }
        public Word GetCurrentWord()
        {
            return _session.Get<Word>(CURRWORD); 
        }
        public int GetWordCount()
        {
            return _session.Get<int>(WORDCOUNT);
        }
        public List<Word> GetWordList()
        {
            return _session.Get<List<Word>>(WORDLIST);
        }
        public int GetCondition()
        {
            return _session.Get<int>(COND);
        }
    }
}
