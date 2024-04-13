namespace MatthewAllison_ST10269378_PRGO6221_POE.Classes
{
    /// <summary>
    /// This is the Recipe class.
    /// It contains all the data and methods required 
    /// to represent and perform actions on the recipes
    /// that the user creates.
    /// </summary>
    public class Recipe
    {
    /// <summary>
        /// Ingredient struct.
        /// Contains three variables
        /// to store the required data
        /// along with a toString for printing 
        /// and multiply quantity for adjusting the scale.
        /// </summary>
        public struct Ingredient
        {
            private string name; 
            private int quantity;
            private CookingMeasurement unit;

            public string Name
            {
                get => name;
                set => name = value;
            }
            public int Quantity
            {
                get => quantity;
                set => quantity = value;
            }
            public CookingMeasurement Unit
            {
                get => unit;
                set => unit = value;
            }

            public void multiplyQuantity(int factor)
            {
                quantity *= factor;
            }
            /// <summary>
            /// Method to format the ingredient information for printing to console.
            /// </summary>
            /// <param name="scaling_factor"></param>
            /// <returns></returns>
            new public string ToString(float scaling_factor)
            {
                string output = "";
                output += quantity * scaling_factor;
                output += " of ";
                output += unit;
                output += " ";
                output += name;
                output += ".";

                return output;
            }
        }
        //------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// A cooking measurement enum to ensure that only real and sensible
        /// measurement units are used.
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
        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// The Step struct.
        /// Data structure to store all the information
        /// required about each step of the recipe.
        /// </summary>
        public struct Step
        {
            private int position; // position of each step in the array
            private string description; // what to do for each step

            public void Position(int pos)
            {
                this.position = pos;
            }
            public int Position()
            {
                return this.position;
            }

            public void Description(string description)
            {
                this.description = description;
            }
            public string Description()
            {
                return description;
            }
        }
        //------------------------------------------------------------------------------------------------------------//
        public Step[] steps; // step array
        public Ingredient[] ingredients; // ingredient array

        /// <summary>
        /// Helper method to make the ingredients array. Takes in a size parameter.
        /// </summary>
        /// <param name="num"></param>
        public void MakeIngriedientsArray(int num)
        {
            Ingredient[] ingredients = new Ingredient[num];
            this.ingredients = ingredients;
        }
        /// <summary>
        /// Helper method to make the steps array. Takes in a size parameter.
        /// </summary>
        /// <param name="num"></param>
        public void MakeStepsArray(int num)
        {
            Step[] steps = new Step[num];
            this.steps = steps;
        }
        //------------------------------------------------------------------------------------------------------------//
        private string name = ""; //recipe name
        private int num_steps = 0; // step count
        private float scaling_factor = 1; // current scaling factor

        public void Name(string name)
        {
            this.name = name;
        }

        public string Name()
        {
            return name;
        }

        public void Num_steps(int num)
        {
            this.num_steps = num;
        }

        public int Num_steps()
        {
            return this.num_steps;
        }
        public void Scaling_factor(float scaling_factor)
        {
            this.scaling_factor = scaling_factor;
        }
        public float Scaling_factor()
        {
            return this.scaling_factor;
        }
    }
}
//----------------------------------------------------------END-OF-FILE-----------------------------------------------//