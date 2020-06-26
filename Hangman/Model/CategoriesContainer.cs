using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Model
{
    public class CategoriesContainer
    {
        public Dictionary<CategoryChoice, Category> Categories { get; set; } = new Dictionary<CategoryChoice, Category>();

        public CategoriesContainer()
        {
            Categories.Add(CategoryChoice.Sport, new Category() {
                Name = "Sport",
                CatName = CategoryChoice.Sport,
                Words = new List<Word> { new Word("Football"), new Word("Baseball"), new Word("Golf") }
            });
            Categories.Add(CategoryChoice.Culture, new Category() {
                Name = "Sport",
                CatName = CategoryChoice.Culture,
                Words = new List<Word> { new Word("Eiffel Tower") }
            });
            Categories.Add(CategoryChoice.Music, new Category() {
                Name = "Sport",
                CatName = CategoryChoice.Music,
                Words = new List<Word> { new Word("No") }
            });
            Categories.Add(CategoryChoice.Movies, new Category() {
                Name = "Sport",
                CatName = CategoryChoice.Movies,
                Words = new List<Word> { new Word("James Pond") }
            });
        }
    }
}
