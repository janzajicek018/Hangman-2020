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

        [BindProperty]
        public string Letter { get; set; }
        [BindProperty]
        public int Lives { get; set; }
        public char[] GuessingLetters { get; set; }
        public string Word { get; set; }
        public int VictoryCondition { get; set; }
        public HangmanModel(GuessLogic gl, SessionStorage ss)
        {
            _gl = gl;
            _ss = ss;
            if (Word == default) { Word = new string(_ss.GuessingLetters); }
            if(Lives == default) { Lives = _ss.Lives; }
            VictoryCondition = _ss.GetCondition();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _gl.GuessWord(Letter);
            Lives = _gl.Lives;
            GuessingLetters = _ss.GetGuessingLetters();
            Word = new string(GuessingLetters);
            VictoryCondition = _ss.GetCondition();
            if(VictoryCondition != 0)
            {
                return Redirect("EndPage");
            }
            return default;
        }
    }
}