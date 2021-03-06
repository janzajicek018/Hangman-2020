﻿using System;
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
    public class IndexModel : PageModel
    {
        readonly SessionStorage _ss;

        public IndexModel(SessionStorage ss)
        {
            _ss = ss;
        }

        public void OnGet()
        {
            _ss.SaveCondition(0);
            _ss.SaveRandomized(false);
            _ss.SaveWordCount(0);
        }
        public void OnGetClick()
        {
        }
        public void OnPost()
        {
        }
    }
}
