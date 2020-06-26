using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Model
{
    public class Category
    {
        public string Name { get; set; }
        public CategoryChoice CatName { get; set; }
        public List<Word> Words { get; set; }
    }
}
