using System;
using MatthewAllison_ST10269378_PRGO6221_POE.Classes;

namespace MatthewAllison_ST10269378_PRGO6221_POE
{
    /// <summary>
    /// Matthew Allison
    /// ST10269378
    /// PROG6221
    /// POE
    /// </summary>

    /// References
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct
    /// https://www.w3schools.com/cs/cs_switch.php
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast
    /// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
    /// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
    /// https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md#
    /// https://github.com/dev-marko/clean-code-book
    /// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
    ///https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements
    internal static class Program
    {
        /// <summary>
        /// This is the main method. The starting point of the program. A UserInterface object is instantiated and its
        /// start method is called to begin the program.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {

            UserInterface userInterface = new UserInterface(); // create new UserInterface object 
            userInterface.CalorieNotification += OnCalorieNotification; // Subscribe to the CalorieNotification event
            userInterface.Start(); // start the UI
        }

        /// <summary>
        /// Event handler for the CalorieNotification even.
        /// Displays a warning to the user when any recipe has more than 300 calories
        /// </summary>
        /// <param name="recipeName"></param>
        /// <param name="totalCalories"></param>
        private static void OnCalorieNotification(string recipeName, int totalCalories)
        {
            Console.WriteLine(
                $"Warning: The recipe '{recipeName}' exceeds 300 calories. Total calories: {totalCalories}");
        }
    }
}
//------------------------------------------------------END-OF-FILE---------------------------------------------------//
