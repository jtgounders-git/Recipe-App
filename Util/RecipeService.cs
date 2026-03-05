using Prog6221PoeRecipeAppP3.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prog6221PoeRecipeAppP3.Util
{
    public class RecipeService
    {
        private readonly List<Recipe> recipes = new List<Recipe>();

        // Method to add a new recipe
        public void AddNewRecipe(string recipeName, List<Ingredient> ingredients, List<string> steps)
        {
            var newRecipe = new Recipe(recipeName, ingredients, steps);
            recipes.Add(newRecipe);
        }

        // Method to update an existing recipe
        public void UpdateRecipe(Recipe updatedRecipe)
        {
            var existingRecipe = FindRecipe(updatedRecipe.Name);
            if (existingRecipe != null)
            {
                existingRecipe.Ingredients = updatedRecipe.Ingredients;
                existingRecipe.Steps = updatedRecipe.Steps;
            }
        }

        // Method to get all recipes
        public List<Recipe> GetAllRecipes()
        {
            return recipes.ToList(); // Return a copy to prevent direct modification
        }

        // Method to find a recipe by name (case-sensitive)
        public Recipe FindRecipe(string recipeName)
        {
            return recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.Ordinal));
        }

        // Method to scale a recipe
        public void ScaleRecipe(Recipe recipe, ScalingFactor factor)
        {
            if (recipe != null)
            {
                double scaleBy = GetScalingFactorValue(factor);
                recipe.ScaleRecipe(scaleBy);
            }
        }

        // Helper method to get scaling factor value
        private double GetScalingFactorValue(ScalingFactor factor)
        {
            switch (factor)
            {
                case ScalingFactor.None:
                    return 1.0;
                case ScalingFactor.Half:
                    return 0.5;
                case ScalingFactor.Double:
                    return 2.0;
                case ScalingFactor.Triple:
                    return 3.0;
                default:
                    throw new ArgumentException("Invalid scaling factor.");
            }
        }
    }
}
