using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Model
{
    public class Word
    {
        public Word(string name)
        {
            Name = name;
            Letters = Name.Split();
        }

        public string Name { get; set; }
        public string[] Letters { get; set; }

    }
}
