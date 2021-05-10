using System;
using System.Linq;

namespace NET5.LINQ
{
    public static class RecipesRun
    {
        private static Recipe[] Recipes()
        {
            Recipe[] recipes =
            {
                new Recipe {Id = 1, Name = "Mashed Potato"},
                new Recipe {Id = 2, Name = "Crispy Duck"},
                new Recipe {Id = 3, Name = "Sachertorte"}
            };

            return recipes;
        }

        private static Review[] Reviews()
        {
            Review[] reviews =
            {
                new Review {RecipeId = 1, ReviewText = "Tasty!"},
                new Review {RecipeId = 1, ReviewText = "Not nice :("},
                new Review {RecipeId = 1, ReviewText = "Pretty good"},
                new Review {RecipeId = 2, ReviewText = "Too hard"},
                new Review {RecipeId = 2, ReviewText = "Loved it"}
            };

            return reviews;
        }

        #region Recipe_Review_Join_Query

        public static void Get_Recipe_Review_Join_Query()
        {
            var query = from recipe in Recipes()
                join review in Reviews() on recipe.Id equals review.RecipeId
                select new { RecipeName = recipe.Name, RecipeReview = review.ReviewText };

            foreach (var item in query)
            {
                Console.WriteLine("{0} - '{1}'", item.RecipeName, item.RecipeReview);
            }

        }

        #endregion

        #region Reviews_For_RecipeName

        public static void Get_Reviews_For_RecipeName_Query()
        {
            var query = from recipe in Recipes()
                join review in Reviews() on recipe.Id equals review.RecipeId into reviewGroup
                select new { 
                    RecipeName = recipe.Name, 
                    Reviews = reviewGroup
                };

            foreach (var item in query)
            {
                Console.WriteLine("Reviews for {0}", item.RecipeName);
                if (item.Reviews.Any())
                {
                    foreach (var review in item.Reviews)
                    {
                        Console.WriteLine(" - {0}", review.ReviewText);
                    }
                }
                else
                {
                    Console.WriteLine(" Anything");
                }

            }

        }


        #endregion






        private class Recipe
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private class Review
        {
            public int RecipeId { get; set; }
            public string ReviewText { get; set; }
        }
    }
}