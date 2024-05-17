using System.Collections.Generic;
using System.Linq;

namespace MatthewAllison_ST10269378_PRGO6221_POE.Classes
{
    /// <summary>
    /// This is the recipe class. It contains all the data that needs to be kept track of for recipes.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// This is the ingredient struct. It consists of Name, Quantity, Unit, Calories and Foodgroup.
        /// It is just a structed way to store ingredient information.
        /// </summary>
        public struct Ingredient
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public CookingMeasurement Unit { get; set; }
            public int Calories { get; set; }
            public string FoodGroup { get; set; }
        }
        /// <summary>
        /// Step struct. Contains position and description information that makes up each step in
        /// a recipe.
        /// </summary>
        public struct Step
        {
            public int Position { get; set; }
            public string Description { get; set; }
        }
        /// <summary>
        /// Cooking measurement enums to ensure only sensible real measurement units
        /// are used by the user.
        /// </summary>
        public enum CookingMeasurement
        {
            Teaspoon,
            Tablespoon,
            Cup,
            Pint,
            Quart,
            Gallon,
            Milliliter,
            Liter,
            Gram,
            Kilogram,
            Ounce,
            Pound
        }

        public List<Ingredient> Ingredients = new List<Ingredient>(); // List to store the ingredients
        public List<Step> Steps = new List<Step>(); // List to store the steps

        private string name; // name of the recipe

        public string Name()
        {
            return name;
        }

        public void Name(string value)
        {
            name = value;
        }
        /// <summary>
        /// Calculate and return the total number of calories in the recipe
        /// </summary>
        /// <returns></returns>
        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }


    }
}
//----------------------------------------------END-OF-FILE-----------------------------------------------------------//