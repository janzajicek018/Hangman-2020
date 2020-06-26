using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman.Model;
using Hangman.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace Hangman.Pages
{
    public class HangmanModel : PageModel
    {
        readonly GuessLogic _gl;
        readonly SessionStorage _ss;

        public char[] GuessingLetters { get; set; }
        public string Letter { get; set; }
        public Word CurrentWord { get; set; }
        public HangmanModel(GuessLogic gl, SessionStorage ss)
        {
            _gl = gl;
            _ss = ss;
        }
        public void OnGet()
        {
            GuessingLetters = _gl.GuessingLetters;
            CurrentWord = _gl.CurrentWord;
        }
        public void OnGetGuess()
        {
        }
        public void OnPost()
        {
            Console.WriteLine(Letter);
            _gl.GuessWord(Letter);
        }
    }
}