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
        public Step[] Steps; // step array
        public Ingredient[] Ingredients; // ingredient array
        
        private string _name = ""; //recipe name
        private int _numSteps = 0; // step count
                
        private float _scalingFactor = 1; // current scaling factor
        
        public void Name(string name)
        {
            this._name = name;
        }
        
        public string Name()
        {
            return _name;
        }
        
        public void Scaling_factor(float scalingFactor)
        {
            this._scalingFactor = scalingFactor;
        } 
        public float Scaling_factor()
        {
            return this._scalingFactor;
        }
    /// <summary>
        /// Ingredient struct.
        /// Contains three variables
        /// to store the required data
        /// along with a toString for printing 
        /// and multiply quantity for adjusting the scale.
        /// </summary>
        public struct Ingredient
        {
            public string Name { get; set; }

            public int Quantity { get; set; }

            public CookingMeasurement Unit { get; set; }

            public void MultiplyQuantity(int factor)
            {
                Quantity *= factor;
            }
            /// <summary>
            /// Method to format the ingredient information for printing to console.
            /// </summary>
            /// <param name="scalingFactor"></param>
            /// <returns></returns>
            public string ToString(float scalingFactor)
            {
                var output = "";
                output += Quantity * scalingFactor;
                output += " ";
                output += Unit;
                output += "of ";
                output += " ";
                output += Name;
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
            private int _position; // position of each step in the array
            private string _description; // what to do for each step

            public void Position(int pos)
            {
                this._position = pos;
            }
            public int Position()
            {
                return this._position;
            }

            public void Description(string description)
            {
                this._description = description;
            }
            public string Description()
            {
                return _description;
            }
        }
        //------------------------------------------------------------------------------------------------------------//
        

        /// <summary>
        /// Helper method to make the ingredients array. Takes in a size parameter.
        /// </summary>
        /// <param name="num"></param>
        public void MakeIngriedientsArray(int num)
        {
            var ingredients = new Ingredient[num];
            this.Ingredients = ingredients;
        }
        /// <summary>
        /// Helper method to make the steps array. Takes in a size parameter.
        /// </summary>
        /// <param name="num"></param>
        public void MakeStepsArray(int num)
        {
            var steps = new Step[num];
            this.Steps = steps;
        }
        //------------------------------------------------------------------------------------------------------------//
        
    }
}
//----------------------------------------------END-OF-FILE-----------------------------------------------------------//