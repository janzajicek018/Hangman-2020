using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Hangman.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hangman.Pages
{
    public class EndPageModel : PageModel
    {
        readonly SessionStorage _ss;
        public int VictoryCondition { get; set; }
        public EndPageModel(SessionStorage ss)
        {
            _ss = ss;
        }

        public void OnGet()
        {
            VictoryCondition = _ss.VictoryCondition;
        }
    }
}