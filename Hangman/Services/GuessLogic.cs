using Hangman.Services;
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
        public int Lives { get; set; } = 8;
        public int WordCount { get; set; } = 0;

        public GuessLogic(Random rand, WordLogic wl, SessionStorage ss)
        {
            _rand = rand;
            _wl = wl;
            _ss = ss;
            Words = _wl.Category.Words.OrderBy(x => _rand.Next()).ToList();
            CurrentWord = Words[0];
            GuessingLetters = new char[CurrentWord.Letters.Length];
            GuessingLetters = _ss.GetGuessingLetters();
        }
        public void GuessWord(string letter)
        {
            int i = 0;
            string result = "";
            foreach (var item in CurrentWord.Letters)
            {
                Console.WriteLine(letter);
                if (letter.ToLower() == item.ToString().ToLower())
                {
                    GuessingLetters[i] = CurrentWord.Letters[i];
                    i++;
                    Console.WriteLine("Letter Got");
                }
                else
                {
                    Lives--;
                    if (Lives == 0) 
                    {
                        //Lose
                        Console.WriteLine("You lose");

                    }
                }
                if(GuessingLetters[i] != default)
                {
                    result += GuessingLetters[i];
                }
            }
            if (result == CurrentWord.Name && WordCount == 5)
            {
                //Victory
                Console.WriteLine("You win");

            }
            else if (result == CurrentWord.Name)
            {
                //Next Word
                Console.WriteLine("Next Word");

            }
        }
        public void GetNextWord()
        {
        }
    }
}
