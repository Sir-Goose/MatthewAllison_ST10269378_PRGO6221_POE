using System;
using System.Linq;
using System.Net.Mail;
using System.Runtime.ConstrainedExecution;

namespace MatthewAllison_ST10269378_PRGO6221_POE.Classes
{
    /// <summary>
    /// Delegate for the CalorieNotfication event
    /// </summary>
    public delegate void CalorieNotificationHandler(string recipeName, int totalCalories);
    
    
    
    /// <summary>
    /// This is the UserInterace class. It contains all the methods related to 
    /// user actions. Anything that prints to the console or takes in input
    /// can be found here.
    /// A user can create, view, change, recipes and
    /// exit the program.
    /// </summary>
    internal class UserInterface
    {
        
        public event CalorieNotificationHandler CalorieNotification; // event for calorie notification
        
        public void Start()
        {
            MainMenu(); //start the main menu
        }

        //------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the MainMenu method. It contains an infinite loop
        /// with various options presented to the user.
        /// The program always returns back here after an option is 
        /// chosen and completed.
        /// </summary>
        public void MainMenu()
        {
            while (true) // infinite loop
            {
                Console.WriteLine("RECIPE PROCESSING SOFTWARE");
                Console.WriteLine();
                Console.WriteLine("1. Create New Recipe");
                Console.WriteLine("2. View Existing Recipe");
                Console.WriteLine("3. Change Current Recipe");
                Console.WriteLine("4. Exit");
                Console.WriteLine("");
                Console.WriteLine("Enter choice: ");

                string choice = Console.ReadLine(); // read user input
                Console.WriteLine();

                switch (choice) // switch stament to control the program
                {
                    case "1":
                        CreateRecipe();
                        break;
                    case "2":
                        DisplayRecipeList();
                        break;
                    case "3":
                        SelectRecipe();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the DisplayRecipeList() method. It displays a list of all the stored recipes. It is only called
        /// by the SelectRecipeList() method.
        /// </summary>
        private void DisplayRecipeList()
        {
            Console.WriteLine("Recipe List:");
            State.Recipes.OrderBy(recipe => recipe.Name()).ToList().ForEach(recipe =>
            {
                Console.WriteLine(recipe.Name());
            });
        }
        /// <summary>
        /// This is the SelectRecipe() method. It is for the user to be able to see all the recipes
        /// and choose one to display
        /// </summary>
        private void SelectRecipe()
        {
            DisplayRecipeList();
            Console.WriteLine("Enter the name of the recipe to display: ");
            string recipeName = Console.ReadLine(); // read the user choice
            Recipe selectedRecipe = State.Recipes.FirstOrDefault(recipe => recipe.Name() == recipeName);
            if (selectedRecipe != null)
            {
                ViewRecipe(selectedRecipe); //view the chosen recipe
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
        /// <summary>
        /// This is the ViewRecipe() method. It displays all the details of the recipe chose
        /// by the user.
        /// </summary>
        /// <param name="recipe"></param>
        private void ViewRecipe(Recipe recipe)
        {
            Console.WriteLine($"RECIPE: {recipe.Name()}");
            Console.WriteLine($"Number of ingredients: {recipe.Ingredients.Count}");
            Console.WriteLine($"Number of steps: {recipe.Steps.Count}");
            Console.WriteLine();
            
            Console.WriteLine("LIST OF INGREDIENTS: ");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit} - {ingredient.Calories} calories - {ingredient.FoodGroup}");
            }
            Console.WriteLine();
            
            Console.WriteLine("LIST OF STEPS:");
            foreach (var step in recipe.Steps)
            {
                Console.WriteLine($"{step.Position}. {step.Description}");
            }
            Console.WriteLine();

            int totalCalories = recipe.CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");
            Console.WriteLine();
            
            Console.WriteLine("END OF RECIPE.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
        }
        //--------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the CreateRecipe method. The meat of the class.
        /// It goes through every step required to capture the details of the recipe
        /// and checks whether a newly created recipe has exceeded 300 calories.
        /// </summary>
        private void CreateRecipe()
        {
            Recipe recipe = new Recipe(); // create new recipe object
            
            Console.WriteLine("Enter recipe name: ");
            recipe.Name(Console.ReadLine()); // get the name from the user
            Console.WriteLine();
            
            Console.WriteLine("Enter number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine()); // read the number of ingredients from the user
            Console.WriteLine();

            for (int i = 0; i < numIngredients; ++i)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                
                Console.WriteLine("Enter ingredient name: ");
                string name = Console.ReadLine(); // read the ingredient name
                Console.WriteLine();
                
                Console.WriteLine("MEASUREMENT UNITS: ");
                Console.WriteLine("-------------------");
                // display each cooking measurement unit for the user to choose from
                foreach (Recipe.CookingMeasurement measurement in Enum.GetValues(typeof(Recipe.CookingMeasurement)))
                {
                    Console.WriteLine(measurement);
                }
                Console.WriteLine("-------------------");
                
                Console.WriteLine("Enter one of the above: ");
                Recipe.CookingMeasurement unit = (Recipe.CookingMeasurement)Enum.Parse(typeof(Recipe.CookingMeasurement), Console.ReadLine(), true);
                Console.WriteLine();
                
                Console.WriteLine("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine()); // read the ingredient quantity
                Console.WriteLine();
                
                Console.WriteLine("Enter calories: ");
                int calories = int.Parse(Console.ReadLine()); // read the amount of calories
                Console.WriteLine();
                
                Console.WriteLine("Enter food group: ");
                string foodGroup = Console.ReadLine(); // read the food group
                Console.WriteLine();
                
                // Create the ingredient struct using all the provided information
                Recipe.Ingredient ingredient = new Recipe.Ingredient()
                {
                    Name = name,
                    Unit = unit,
                    Quantity = quantity,
                    Calories = calories,
                    FoodGroup = foodGroup
                };
                
                recipe.Ingredients.Add(ingredient); // finally add the ingredient to the recipe 
            }
            Console.WriteLine("Enter number of steps: ");
            int numSteps = int.Parse(Console.ReadLine()); // read the number of steps
            Console.WriteLine();

            for (int i = 0; i  < numSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}:");
                string description = Console.ReadLine(); // read the actual instructions for the step
                Console.WriteLine();
                
                // create the step object with the provided information
                Recipe.Step step = new Recipe.Step
                {
                    Position = i + 1,
                    Description = description
                };
                
                recipe.Steps.Add(step); // finally add the step to the recipe
                
            }

            int totalCalories = recipe.CalculateTotalCalories();
            if (totalCalories > 300)
            {
                CalorieNotification?.Invoke(recipe.Name(), totalCalories); // raise the CalorieNotification event
                                                                            // if the calorie count exceeds 300
            }
            
            State.Recipes.Add(recipe); // Add the recipe to the list of recipes
            Console.WriteLine("Recipe created successfully!");
        }
    }
}
//----------------------------------------------END-OF-FILE-----------------------------------------------------------//