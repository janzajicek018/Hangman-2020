using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman.Model;
using Hangman.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hangman.Pages
{
    public class GamePageModel : PageModel
    {
        private readonly WordLogic _wl;

        public GamePageModel(WordLogic wl)
        {
            _wl = wl;
        }
        public Category Category { get; set; }
        public void OnGet()
        {
            Category = _wl.Category;
        }
    }
}