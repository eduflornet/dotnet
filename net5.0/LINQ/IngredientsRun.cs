using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
            {
                "milk,sugar,eggs",
                "flour,BUTTER,eggs",
                "vanilla,ChEEsE,oats"
            };
            return list;
        }

        #region LINQ_to_XML_Manual_Procedural_Creation

        public static void Get_LINQ_to_XML_Manual_Procedural_Creation()
        {
            var ingredients = new XElement("ingredients");
            var sugar = new XElement("ingredient", "Sugar");
            var milk = new XElement("ingredient", "Milk");
            var butter = new XElement("ingredient", "Butter");

            ingredients.Add(sugar);
            ingredients.Add(milk);
            ingredients.Add(butter);

            Console.WriteLine(ingredients);
        }

        #endregion

        #region LINQ_to_XML_Functional_Construction

        public static void Get_LINQ_to_XML_Functional_Construction()
        {
            XElement ingredients =
                new XElement("ingredients",
                    new XElement("ingredient", "Sugar"),
                    new XElement("ingredient", "Milk"),
                    new XElement("ingredient", "Butter")
                );
            Console.WriteLine(ingredients);
        }

        #endregion

        #region LINQ_to_XML_Creation_by_Projection

        public static void Get_LINQ_to_XML_Creation_by_Projection()
        {
            Ingredient[] ingredients =
            {
                new Ingredient {Name = "Sugar", Calories = 500},
                new Ingredient {Name = "Milk", Calories = 150},
                new Ingredient {Name = "Butter", Calories = 200}
            };

            XElement ingredientsXML =
                new XElement("ingredients",
                    from i in ingredients
                    select new XElement("ingredient", i.Name,
                        new XAttribute("calories", i.Calories))
                );
            Console.WriteLine(ingredientsXML);
        }


        #endregion


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
            foreach (var ingredientName in Fluent_style_highCalorieIngredientNamesQuery())
                Console.WriteLine(ingredientName);
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
            foreach (var ingredientName in Query_expression_style_highCalorieIngredientNames())
                Console.WriteLine(ingredientName);
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
            foreach (var ingredient in Range_Variables_style_highCalorieIngredientNames())
                Console.WriteLine(ingredient.Name);
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
                where uppercaseIngredient == "MILK" || uppercaseIngredient == "BUTTER" ||
                      uppercaseIngredient == "CHEESE"
                select uppercaseIngredient;

            return dairyQuery;
        }

        public static void Get_Dairy_Query()
        {
            foreach (var dairyIngredient in DairyQuery()) Console.WriteLine("{0} is dairy", dairyIngredient);
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
                Console.WriteLine("{0} - {1} ", ingredient.Name, ingredient.Calories);
        }

        #endregion

        #region LINQ_to_XML

        private static readonly string _xmlString = @"<ingredients>
                               <ingredient>Sugar</ingredient>
                                <ingredient>Milk</ingredient>
                                <ingredient>Butter</ingredient>
                                </ingredients>";

        private static readonly XElement xdom = XElement.Parse(_xmlString);

        public static void Get_LINQ_to_XML()
        {
            Console.WriteLine(xdom);
        }

        #endregion
    }

    internal class Ingredient
    {
        public string Name { get; set; }
        public int Calories { get; set; }
    }
}