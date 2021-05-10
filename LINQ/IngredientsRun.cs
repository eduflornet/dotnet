using System;
using System.Collections.Generic;
using System.Linq;

namespace NET5.LINQ
{
    public static class IngredientsRun
    {
        private static Ingredient[] Ingredients()
        {
            Ingredient[] list =
            {
                new Ingredient {Name = "Sugar", Calories = 500},
                new Ingredient {Name = "Egg", Calories = 100},
                new Ingredient {Name = "Milk", Calories = 150},
                new Ingredient {Name = "Flour", Calories = 50},
                new Ingredient {Name = "Butter", Calories = 200}
            };

            return list;
        }

        private static string[] CsvRecipes()
        {
            string[] list =
                { "milk,sugar,eggs",
                    "flour,BUTTER,eggs",
                    "vanilla,ChEEsE,oats"
                };
            return list;
        }


        // Case 1
        #region Fluent_style

        private static IEnumerable<string> Fluent_style_highCalorieIngredientNamesQuery()
        {
            var list =
                Ingredients()
                    .Where(x => x.Calories >= 150)
                    .OrderBy(x => x.Name)
                    .Select(x => x.Name);

            return list;
        }

        public static void Get_Fluent_style_HighCalorieIngredientNames()
        {
            foreach (var ingredientName in Fluent_style_highCalorieIngredientNamesQuery()) Console.WriteLine(ingredientName);
        }



        #endregion

        // Case 2
        #region Query_expression_style
        private static IEnumerable<string> Query_expression_style_highCalorieIngredientNames()
        {
            var list =
                from i in Ingredients()
                where i.Calories >= 150
                orderby i.Name
                select i.Name;

            return list;
        }

        public static void Get_Query_expression_style_HighCalorieIngredientNames()
        {
            foreach (var ingredientName in Query_expression_style_highCalorieIngredientNames()) Console.WriteLine(ingredientName);
        }

        #endregion

        // Case 3
        #region Range_Variables_style
        private static IEnumerable<Ingredient> Range_Variables_style_highCalorieIngredientNames()
        {
            var list =
                from i in Ingredients()
                let isDairy = i.Name == "Milk" || i.Name == "Butter"
                where i.Calories >= 150 && isDairy
                select i;

            return list;
        }

        public static void Get_Range_Variables_style_HighCalorieIngredientNames()
        {
            foreach (var ingredient in Range_Variables_style_highCalorieIngredientNames()) Console.WriteLine(ingredient.Name);
        }

        #endregion

        // Case 4
        #region DairyQuery

        private static IEnumerable<string> DairyQuery()
        {
            var dairyQuery =
                from csvRecipe in CsvRecipes()
                let ingredients = csvRecipe.Split(',')
                from ingredient in ingredients
                let uppercaseIngredient = ingredient.ToUpper()
                where uppercaseIngredient == "MILK" || uppercaseIngredient == "BUTTER" || uppercaseIngredient == "CHEESE"
                select uppercaseIngredient;

            return dairyQuery;
        }

        public static void Get_Dairy_Query()
        {
            foreach (var dairyIngredient in DairyQuery())
            {
                Console.WriteLine("{0} is dairy", dairyIngredient);
            }
        }


        #endregion

        #region HighCalDairyQuery

        private static IEnumerable<Ingredient> HighCalDairyQuery()
        {
            var highCalDairyQuery =
                from i in Ingredients()
                    // anonymous type
                select new
                {
                    OriginalIngredient = i,
                    IsDairy = i.Name == "Milk" || i.Name == "Butter",
                    IsHighCalorie = i.Calories >= 150
                }
                into temp
                where temp.IsDairy && temp.IsHighCalorie
                select temp.OriginalIngredient;
            // cannot write "select i;" as into hides the previous range variable i select temp.OriginalIngredient;

            return highCalDairyQuery;
        }

        public static void Get_High_Cal_Dairy_Query()
        {
            foreach (var ingredient in HighCalDairyQuery())
            {
                Console.WriteLine("{0} - {1} ", ingredient.Name, ingredient.Calories);
            }
        }

        #endregion



    }

    internal class Ingredient
    {
        public string Name { get; set; }
        public int Calories { get; set; }
    }
}