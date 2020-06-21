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
    public class CatChooseModel : PageModel
    {
        readonly SessionStorage _ss;
        public CatChooseModel(SessionStorage ss)
        {
            _ss = ss;
        }
        public Category Category { get; set; }
        public void OnGet()
        {
            Category = new Category();
        }
        public void OnPost()
        {
            _ss.SaveTest(Category);
        }
    }
}