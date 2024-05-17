using System.Collections.Generic;

namespace MatthewAllison_ST10269378_PRGO6221_POE.Classes
{
    /// <summary>
    /// A very simple class that will most certainly be expanded on
    /// for part 3. Current contains a list of all the recipes to be globally accessed
    /// without having to pass data between functions. This greatly simplifies things.
    /// </summary>
    public class State
    {
        public static List<Recipe> Recipes = new List<Recipe>();
    }
}