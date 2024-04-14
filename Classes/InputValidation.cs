namespace MatthewAllison_ST10269378_PRGO6221_POE.Classes
{
    public static class InputValidation
    {
        /// <summary>
        /// This is the option struct. It contains two values and is the type always returned from
        /// the input validation methods. It will sometimes have a string value to be used by
        /// the original calling method if the parsed input was valid.
        /// </summary>
        public struct Option
        {
            public string Value; // valid values
            public bool Valid; // is valid yes no
        }

        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the ValidateMainMenu method.
        /// It makes sure something other than null has been provided.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Option ValidateMainMenu(string input)
        {
            return ValidateInput(input);
        }

        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the ValidateChangeRecipeMenu method.
        /// It trims any leading and trailing whitespace
        /// and makes sure null was not provided.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Option ValidateChangeRecipeMenu(string input)
        {
            return ValidateInput(input);
        }

        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the ValidateScalingFactor method.
        /// It ensures that the provided input is not null.
        /// It trims any leading and trailing whitespace and
        /// ensures the value can be used as a float.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Option ValidateScalingFactor(string input)
        {
            var option = new Option();
            if (input == null) return option;
            input = input.Trim();
            try
            {
                float.Parse(input);
                option.Valid = true;
                option.Value = input;
            }
            catch
            {
                option.Valid = false;
                return option;
            }
            return option;
        }

        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the ValidateRecipeName method.
        /// It just checks that a null value was not provided 
        /// and then removes any leading or trailing whitespace.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Option ValidateRecipeName(string input)
        {
            return ValidateInput(input);
        }

        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the ValidateNumberIngredients method.
        /// It checks that the provided value is not null.
        /// It trims any leading and trailing whitespace and 
        /// ensures that the value can be parsed as an int.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Option ValidateNumberIngredients(string input)
        {
            var option = new Option();
            if (input == null) return option;
            input = input.Trim();
            try
            {
                int.Parse(input);
                option.Valid = true;
                option.Value = input;
            }
            catch
            {
                option.Valid = false;
                return option;
            }
            return option;
        }

        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the ValidateIngredientName method.
        /// It checks for null values.
        /// Trims leading and trailing whitespace
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Option ValidateIngredientName(string input)
        {
            return ValidateInput(input);
        }

        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the ValidateQuantity method.
        /// It checks for null values.
        /// Trims any leading and trailing whitespace 
        /// and ensures the value can be parsed as an int.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Option ValidateQuantity(string input)
        {
            var option = new Option();
            if (input == null) return option;
            input = input.Trim();
            try
            {
                int.Parse(input);
                option.Valid = true;
                option.Value = input;
            }
            catch
            {
                option.Valid = false;
                return option;
            }
            return option;
        }
        /// <summary>
        /// Validates the input by ensuring it is not null and trimming any leading and trailing whitespace.
        /// </summary>
        /// <param name="input">The input to validate.</param>
        /// <returns>An Option struct containing the validation result.</returns>
        private static Option ValidateInput(string input)
        {
            var option = new Option();
            if (input != null)
            {
                option.Value = input.Trim();
                option.Valid = true;
            }
            else
            {
                option.Valid = false;
            }
            return option;
        }
    }
    
}
//-------------------------------------------------------END-OF-FILE--------------------------------------------------//