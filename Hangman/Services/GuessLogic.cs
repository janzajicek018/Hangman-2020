using Hangman.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Hangman.Model
{
    public class GuessLogic
    {
        readonly Random _rand;
        readonly WordLogic _wl;
        readonly SessionStorage _ss;


        public List<Word> Words { get; set; }
        public Word CurrentWord { get; set; }
        public char[] GuessingLetters { get; set; }
        public int Lives { get; set; }
        public int WordCount { get; set; } = 0;
        public int VictoryCondition { get; set; } = 0;
        public bool Randomized { get; set; }
        public GuessLogic(Random rand, WordLogic wl, SessionStorage ss)
        {
            _rand = rand;
            _wl = wl;
            _ss = ss;
            Randomized = _ss.Randomized;
            RandomizeList();
            Words = _ss.GetWordList();
            GetFirstWord();
            CurrentWord = _ss.GetCurrentWord();
            GuessingLetters = _ss.GetGuessingLetters();
            WordCount = _ss.GetWordCount();
            Lives = _ss.Lives;
        }
        public void GuessWord(string guess)
        {
            if(guess == null) { guess = ""; }
            int i = 0;
            bool appears = false;
            if(guess.ToLower() == CurrentWord.Name.ToLower()) {
                GuessingLetters = CurrentWord.Letters;
                appears = true;
                DecideNext(appears, true);
            }
            foreach (var item in CurrentWord.Letters)
            {
                var temp = item.ToString().ToLower();
                if(guess.ToLower() == temp) 
                {
                    appears = true;
                    GuessingLetters[i] = CurrentWord.Letters[i];
                }
                i++;    
            }
            _ss.SaveGuessingLetters(GuessingLetters);
            DecideNext(appears);
        }
        public void DecideNext(bool appears, bool fullword = false)
        {
            if(fullword == true && Words.Count > WordCount + 1)
            {
                GetNextWord();
            }
            else if(appears == true && fullword == false)
            {
                int i = 0;
                foreach (var item in GuessingLetters)
                {
                    if(item == '_') { GuessingLetters[i] = ' '; }
                    i++;
                }
                string result = new string(GuessingLetters);
                if (result == CurrentWord.Name)
                {
                    if(Words.Count > WordCount + 1)
                    {
                        GetNextWord();
                    }
                    else
                    {
                        VictoryCondition = 1;
                        _ss.SaveCondition(VictoryCondition);
                    }
                }
            }
            else if (appears == false)
            {
                Lives--;
                _ss.SaveLives(Lives);
                if (Lives < 0)
                {
                    VictoryCondition = -1;
                    _ss.SaveCondition(VictoryCondition);

                }
            }
            else
            {
                VictoryCondition = 1;
                _ss.SaveCondition(VictoryCondition);

            }
        }
        public void GetFirstWord()
        {
            if(Randomized == false)
            {
                Lives = 6;
                Randomized = true;
                CurrentWord = Words[WordCount];
                GuessingLetters = new char[CurrentWord.Letters.Length];
                GuessingLettersPrepare();
                _ss.SaveRandomized(Randomized);
                _ss.SaveCurrentWord(CurrentWord);
                _ss.SaveGuessingLetters(GuessingLetters);
                _ss.SaveWordCount(WordCount);
                _ss.SaveLives(Lives);
            }
        }
        public void GetNextWord()
        {
            CurrentWord = Words[++WordCount];
            GuessingLetters = new char[CurrentWord.Letters.Length];

            GuessingLettersPrepare();
            _ss.SaveCurrentWord(CurrentWord);
            _ss.SaveGuessingLetters(GuessingLetters);
            _ss.SaveWordCount(WordCount);
        }
        public void GuessingLettersPrepare()
        {
            int i = 0;
            foreach (var item in CurrentWord.Letters)
            {
                if (item.ToString() == " ") { GuessingLetters[i] = '_'; }
                else { GuessingLetters[i] = '-'; }
                i++;
            }
        }
        public void RandomizeList()
        {
            if(Randomized == false)
            {
                Words = _wl.Category.Words;
                Words = _wl.Category.Words.OrderBy(x => _rand.Next()).ToList();
                _ss.SaveWordList(Words);
            }
        }
    }
}
