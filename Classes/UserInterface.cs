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

        private void MainMenu()
        {
            while (true)
            {
                var choice = "0";
                
                Console.WriteLine("RECIPE PROCESSING SOFTWARE");
                Console.WriteLine();
                Console.WriteLine("1. Create New Recipe");
                Console.WriteLine("2. View Existing Recipe");
                Console.WriteLine("3. Change Current Recipe");
                Console.WriteLine("4. Delete Existing Recipe");
                Console.WriteLine("5. Exit");
                Console.WriteLine("");
                Console.WriteLine("Enter choice: ");
                
                var option = InputValidation.ValidateMainMenu(Console.ReadLine());
                if (option.Value == null) {
                    continue;
                }
                choice = option.Value;
                Console.WriteLine();

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
            Console.WriteLine("1. Adjust scale");
            Console.WriteLine("2. Reset scale");
            Console.WriteLine("Enter choice: ");
            var option = InputValidation.ValidateChangeRecipeMenu(Console.ReadLine());
            if (option.Value == null)
            {
                Console.WriteLine("Pleas enter either 1 or 2.");
                Console.WriteLine();
                ChangeRecipe();
            }
            var choice = option.Value;
            
            Console.WriteLine();
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
            Console.WriteLine();
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
        /// This is the CreateRecipe method. Largest in the class. It is
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
            
            
            int numIngredients;
            while (true)
            {
                Console.WriteLine("Enter number of ingredients: ");
                var option1 = InputValidation.ValidateNumberIngredients(Console.ReadLine());
                if (option1.Value == null)
                {
                    continue;
                }
                else
                {
                    numIngredients = int.Parse(option1.Value);
                    break;
                }
            }
            _recipe.MakeIngriedientsArray(numIngredients);
            Console.WriteLine();
            // collect ingredient names
            for (var i = 0; i < _recipe.Ingredients.Length; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                while (true)
                {
                    
                    Console.WriteLine("Enter ingriedient name: ");
                    var option1 = InputValidation.ValidateIngredientName(Console.ReadLine());
                    if (option1.Value == null)
                    {
                        continue ;
                    }
                    _recipe.Ingredients[i].Name = option1.Value;
                    Console.WriteLine();
                    break;
                }

                Console.WriteLine("MEASUREMENT UNITS: ");
                Console.WriteLine("-------------------");
                // print out the various measurement options available
                foreach (
                    Recipe.CookingMeasurement measurement in Enum.GetValues(
                        typeof(Recipe.CookingMeasurement)
                    )
                )
                {
                    Console.WriteLine(measurement);
                }
                Console.WriteLine("-------------------");
                while (true)
                {

                    Console.WriteLine("Enter one of the above: ");
                    var input = Console.ReadLine();
                    if ( input == null)
                    {
                        continue;
                    }

                    if (
                        Enum.TryParse<Recipe.CookingMeasurement>( // enusre inputted inut is valid
                            input,
                            true,
                            out var unit
                        )
                    )
                    {
                        _recipe.Ingredients[i].Unit = unit;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please choose a valid option");
                        continue;
                    }
                }
                Console.WriteLine();
                // infinite loop that exists when the user enters a valid number
                while (true)
                {
                    Console.WriteLine("Enter quantity: ");
                    var option1 = InputValidation.ValidateQuantity(Console.ReadLine());
                    if (option1.Value == null)
                    {
                        Console.WriteLine("Please use arabic numerals only.");
                        continue;

                    }
                    _recipe.Ingredients[i].Quantity = int.Parse(option1.Value);
                    break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Thank you, all ingredients captured");
            Console.WriteLine();

            int numSteps;
            while (true)
            {
                Console.WriteLine("Enter number of steps: ");
                var option1 = InputValidation.ValidateQuantity(Console.ReadLine());
                if (option1.Value == null)
                {
                    Console.WriteLine("Please use arabic numerals only.");
                    continue;
                }
                numSteps = int.Parse(option1.Value);
                _recipe.MakeStepsArray(numSteps);
                break;
            }
            Console.WriteLine();
            
            // Collect the various steps from the users. Loop that runs according to how many steps were entered in 
            // earlier
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
            Console.WriteLine("Thank you. Recipe has been captured");
            Console.WriteLine();
        }
    }
}
//----------------------------------------------END-OF-FILE-----------------------------------------------------------//