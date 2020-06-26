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
        readonly CategoriesContainer _cc;
        public CatChooseModel(SessionStorage ss, CategoriesContainer cc)
        {
            _ss = ss;
            _cc = cc;
            Categories = _cc.Categories;
        }
        [BindProperty]
        public CategoryChoice Choice { get; set; }
        public Dictionary<CategoryChoice, Category> Categories { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            _ss.SaveCatChoice(Choice);
        }
    }
}