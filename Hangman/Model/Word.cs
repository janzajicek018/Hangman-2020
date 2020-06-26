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
            Letters = Name.ToCharArray();
        }

        public string Name { get; set; }
        public char[] Letters { get; set; }

    }
}
