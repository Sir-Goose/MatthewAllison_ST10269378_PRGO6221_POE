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
    internal static class Program
    {
        /// <summary>
        /// This is the main method. The starting point of the program. A UserInterface object is instantiated and its
        /// start method is called to begin the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var userInterface = new UserInterface();
            userInterface.Start();
        }
    }
}
//------------------------------------------------------END-OF-FILE---------------------------------------------------//