using System;
using System.Net.Mail;
using System.Runtime.ConstrainedExecution;

namespace MatthewAllison_ST10269378_PRGO6221_POE.Classes
{
    /// <summary>
    /// This is the UserInterface class. It contains all the methods and data needed
    /// to to make up the user interface of the program. A user can change,
    /// view, create and delete recipes. They can also exit the program.
    /// </summary>
    internal class UserInterface
    {
        private Recipe _recipe = new Recipe();

        public void Start()
        {
            MainMenu();
        }
        /// <summary>
        /// This is the main menu of the program. It handles the user choosing what they would like to do.
        /// </summary>
        private void MainMenu()
        {
            while (true)
            {
                var choice = "0";
                
                PrintMainMenu(); // display the menu options

                var option = InputValidation.ValidateMainMenu(Console.ReadLine());
                if (option.Value == null) {
                    continue;
                }
                choice = option.Value;
                Console.WriteLine();

                ProcessChoice(choice);
            }
        }
        /// <summary>
        /// Switch case to choose what to do with user input
        /// </summary>
        /// <param name="choice"></param>
        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    CreateRecipe();
                    break;
                case "2":
                    ViewRecipe();
                    break;
                case "3":
                    ChangeRecipe();
                    break;
                case "4":
                    DeleteRecipe();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
        }

        /// <summary>
        /// Simple method to print out the menu.
        /// </summary>
        private void PrintMainMenu()
        {
            Console.WriteLine("RECIPE PROCESSING SOFTWARE");
            Console.WriteLine();
            Console.WriteLine("1. Create New Recipe");
            Console.WriteLine("2. View Existing Recipe");
            Console.WriteLine("3. Change Current Recipe");
            Console.WriteLine("4. Delete Existing Recipe");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");
            Console.WriteLine("Enter choice: ");
        }

        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the DeleteRecipe method.
        /// It works by overwriting the existing
        /// recipe and then informing the user.
        /// </summary>
        private void DeleteRecipe()
        {
            _recipe = new Recipe();
            Console.WriteLine("Recipe Deleted Successfully");
            Console.WriteLine();
        }
        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the ChangeRecipe method.
        /// It allows a user to change the scaling factor of the ingredients
        /// in a recipe.
        /// The scale can be changed to whatever is required by the user 
        /// or reset back to the original value.
        /// </summary>
        private void ChangeRecipe()
        {
            Console.WriteLine("Adjusting Recipe Scale");
            Console.WriteLine("");
            Console.WriteLine($"Current scaling factor is: {_recipe.Scaling_factor()}");
            Console.WriteLine();
            PrintChangeRecipeMenu();
            
            var option = InputValidation.ValidateChangeRecipeMenu(Console.ReadLine());
            if (option.Value == null)
            {
                Console.WriteLine("Pleas enter either 1 or 2.");
                Console.WriteLine();
                ChangeRecipe();
            }
            var choice = option.Value;
            
            Console.WriteLine();
            ProcessRecipeChoice(choice);
            Console.WriteLine();
        }

        private void ProcessRecipeChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter new scaling factor in arabic numerals: ");
                    var option1 = InputValidation.ValidateScalingFactor(Console.ReadLine());
                    if (option1.Value == null)
                    {
                        Console.WriteLine("Please enter an arabic numeral");
                        Console.WriteLine("Scaling factor reset to: 1.");
                        _recipe.Scaling_factor(1);
                    }
                    else
                    {
                        _recipe.Scaling_factor(float.Parse(option1.Value));
                        Console.WriteLine($"Scaling factor adjusted to: {_recipe.Scaling_factor()}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Scaling factor reset to: 1");
                    _recipe.Scaling_factor(1);
                    break;
            }
        }

        private void PrintChangeRecipeMenu()
        {
            Console.WriteLine("1. Adjust scale");
            Console.WriteLine("2. Reset scale");
            Console.WriteLine("Enter choice: ");
        }

        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the ViewRecipe method. It prints out the current recipe in a
        /// neat and easy to read format.
        /// </summary>
        private void ViewRecipe()
        {
            Console.WriteLine($"RECIPE: {_recipe.Name()}");
            Console.WriteLine($"Number of ingredients: {_recipe.Ingredients.Length}");
            Console.WriteLine($"Number of steps: {_recipe.Steps.Length}");
            Console.WriteLine();
            Console.WriteLine("LIST OF INGREDIENTS: ");

            for ( var i = 0; i < _recipe.Ingredients.Length; i++ )
            {
                Console.Write($"{i + 1}. ");
                Console.WriteLine(_recipe.Ingredients[i].ToString(_recipe.Scaling_factor()));
            }
            Console.WriteLine();

            Console.WriteLine("LIST OF STEPS: ");
            for ( var i = 0; i < _recipe.Steps.Length; i++ )
            {
                Console.Write($"{i + 1}. ");
                Console.WriteLine(_recipe.Steps[i].Description());
            }
            
            Console.WriteLine();
            Console.WriteLine("END OF RECIPE.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
        }
        //------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the CreateRecipe and associated set of method. Largest in the class. It is
        /// every step required to capture the details of the recipe.
        /// There is robust input validation and value checking to 
        /// prevent a user from having to start from scratch if they 
        /// make a typo.
        /// </summary>
        private void CreateRecipe()
        {
            Console.WriteLine("Enter recipe name: ");
            var option = InputValidation.ValidateRecipeName(Console.ReadLine());
            if (option.Value == null)
            {
                CreateRecipe();
            }
            else
            {
                _recipe.Name(option.Value);
            }
            Console.WriteLine();
            
            int numIngredients = GetNumberOfIngredients();
            _recipe.MakeIngriedientsArray(numIngredients);
            Console.WriteLine();

            CaptureIngredients();

            Console.WriteLine("Thank you, all ingredients captured");
            Console.WriteLine();

            int numSteps = GetNumberOfSteps();
            Console.WriteLine();
            
            CaptureSteps(numSteps);

            Console.WriteLine("Thank you. Recipe has been captured");
            Console.WriteLine();
        }
        /// <summary>
        /// Fetch a validate the ingredient count from the user.
        /// </summary>
        /// <returns></returns>
        private int GetNumberOfIngredients()
        {
            while (true)
            {
                Console.WriteLine("Enter number of ingredients: ");
                var option = InputValidation.ValidateNumberIngredients(Console.ReadLine());
                if (option.Value == null)
                {
                    continue;
                }
                else
                {
                    return int.Parse(option.Value);
                }
            }
        }
        /// <summary>
        /// Fetch the actual ingrdients from the user
        /// </summary>
        private void CaptureIngredients()
        {
            for (var i = 0; i < _recipe.Ingredients.Length; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                CaptureIngredientName(i);
                Console.WriteLine();

                DisplayMeasurementUnits();
                CaptureIngredientUnit(i);
                Console.WriteLine();

                CaptureIngredientQuantity(i);
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Fetch the ingredient names
        /// </summary>
        /// <param name="index"></param>
        private void CaptureIngredientName(int index)
        {
            while (true)
            {
                Console.WriteLine("Enter ingredient name: ");
                var option = InputValidation.ValidateIngredientName(Console.ReadLine());
                if (option.Value == null)
                {
                    continue;
                }
                _recipe.Ingredients[index].Name = option.Value;
                break;
            }
        }
        /// <summary>
        /// Display the list of measurement units
        /// </summary>
        private void DisplayMeasurementUnits()
        {
            Console.WriteLine("MEASUREMENT UNITS: ");
            Console.WriteLine("-------------------");
            foreach (Recipe.CookingMeasurement measurement in Enum.GetValues(typeof(Recipe.CookingMeasurement)))
            {
                Console.WriteLine(measurement);
            }
            Console.WriteLine("-------------------");
        }
        /// <summary>
        /// Get the unit chosen by the user and validate it
        /// </summary>
        /// <param name="index"></param>
        private void CaptureIngredientUnit(int index)
        {
            while (true)
            {
                Console.WriteLine("Enter one of the above: ");
                var input = Console.ReadLine();
                if (input == null)
                {
                    continue;
                }

                if (Enum.TryParse<Recipe.CookingMeasurement>(input, true, out var unit))
                {
                    _recipe.Ingredients[index].Unit = unit;
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose a valid option");
                    continue;
                }
            }
        }
        /// <summary>
        /// Get the quanity of each ingredient
        /// </summary>
        /// <param name="index"></param>
        private void CaptureIngredientQuantity(int index)
        {
            while (true)
            {
                Console.WriteLine("Enter quantity: ");
                var option = InputValidation.ValidateQuantity(Console.ReadLine());
                if (option.Value == null)
                {
                    Console.WriteLine("Please use arabic numerals only.");
                    continue;
                }
                _recipe.Ingredients[index].Quantity = int.Parse(option.Value);
                break;
            }
        }
        /// <summary>
        /// Get the number of steps from the user
        /// </summary>
        /// <returns></returns>
        private int GetNumberOfSteps()
        {
            while (true)
            {
                Console.WriteLine("Enter number of steps: ");
                var option = InputValidation.ValidateQuantity(Console.ReadLine());
                if (option.Value == null)
                {
                    Console.WriteLine("Please use arabic numerals only.");
                    continue;
                }
                int numSteps = int.Parse(option.Value);
                _recipe.MakeStepsArray(numSteps);
                return numSteps;
            }
        }
        /// <summary>
        /// Get the details of each step and make sure details are actually provided
        /// </summary>
        /// <param name="numSteps"></param>
        private void CaptureSteps(int numSteps)
        {
            for (var i = 0; i < numSteps; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Please enter step {i + 1}");
                    var step = new Recipe.Step();
                    step.Position(i);
                    step.Description(Console.ReadLine());
                    if (step.Description() == null)
                    {
                        continue;
                    }
                    Console.WriteLine();
                    _recipe.Steps[i] = step;
                    break;
                }
            }
        }
    }
}
//----------------------------------------------END-OF-FILE-----------------------------------------------------------//