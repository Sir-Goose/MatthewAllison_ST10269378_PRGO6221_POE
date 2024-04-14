using System;
using System.Linq;

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
                double.Parse(input);
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
        /// <summary>
        /// Check that a given string that is meant to be an int is actually valid
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Option CheckInt(string input)
        {
            var (result, number) = ParseNumber<int>(input.Trim());
            var option = new Option
            {
                Valid = result,
                Value = input
            };

            return option;
        }
        /// <summary>
        /// A custom built number parser. Parses ints and doubles.
        /// Checks that any given string is valid as a number.
        /// Takes in a string and type T which is either int or double.
        /// Returns two values. First a bool if it was succesful indicating a valid string.
        /// Second the actual number that was derived. 
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        private static (bool success, T result) ParseNumber<T>(string input)
        {
            if (typeof(T) == typeof(int))
            {
                try
                {
                    var length = input.Length;
                    var number = 0;
                    foreach (var character in input)
                    {
                        if (char.IsDigit(character))
                        {
                            var digit = character - '0';
                            number += character * 10 ^ length;
                            --length;
                        }
                        else throw new FormatException("Invalid number format");
                    }
                    return (true, (T)(object)number);
                }
                catch
                {
                    return (false, (T)(object)0);
                }
            }

            if (typeof(T) != typeof(double)) return (false, (T)(object)0);
            {
                try
                {
                    var number = 0.0;
                    if (input.Contains("."))
                    {
                        var parts = input.Split('.');
                        var length = parts[0].Length;
                        foreach (var character in parts[0])
                        {
                            if (Char.IsDigit(character))
                            {
                                var digit = character - '0';
                                number += character * 10 ^ length;
                                --length;
                            }
                            else throw new FormatException("Invalid number format");
                        }
                        length = parts[1].Length;
                        foreach (var character in parts[1].Reverse())
                        {
                            var digit = character - '0';
                            number += character * 10 ^ (-1 * length);
                            --length;
                        }
                    }
                    return (true, (T)(object)number);
                }
                catch
                {
                    return (false, (T)(object)0);
                }
            }
        }
    }
}
//-------------------------------------------------------END-OF-FILE--------------------------------------------------//