using Prog6221PoeRecipeAppP3.Util;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Prog6221PoeRecipeAppP3.Views
{
    public partial class FilterRecipeList : Window
    {
        private List<Recipe> _recipes;
        private RecipeList _recipeListWindow;

        public FilterRecipeList(List<Recipe> recipes, RecipeList recipeListWindow)
        {
            InitializeComponent();
            _recipes = recipes;
            _recipeListWindow = recipeListWindow;

            // Populate food groups in ComboBox
            var foodGroups = _recipes.SelectMany(r => r.Ingredients.Select(i => i.FoodGroup)).Distinct().ToList();
            cbFoodGroups.ItemsSource = foodGroups;
        }

        private void BtnSearchIngredient_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = tbIngredient.Text.Trim();
            if (!string.IsNullOrWhiteSpace(ingredientName))
            {
                var filteredRecipes = _recipes.Where(r => r.Ingredients.Any(i => i.Name.Contains(ingredientName, StringComparison.OrdinalIgnoreCase))).ToList();
                UpdateRecipeList(filteredRecipes);
                Close();
            }
        }

        private void BtnFilterFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            string selectedFoodGroup = cbFoodGroups.SelectedItem as string;
            if (!string.IsNullOrWhiteSpace(selectedFoodGroup))
            {
                var filteredRecipes = _recipes.Where(r => r.Ingredients.Any(i => i.FoodGroup.Equals(selectedFoodGroup, StringComparison.OrdinalIgnoreCase))).ToList();
                UpdateRecipeList(filteredRecipes);
                Close();
            }
        }

        private void BtnApplyCalories_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbMaxCalories.Text, out double maxCalories))
            {
                var filteredRecipes = _recipes.Where(r => r.TotalCalories <= maxCalories).ToList();
                UpdateRecipeList(filteredRecipes);
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid number for Max Calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateRecipeList(List<Recipe> filteredRecipes)
        {
            _recipeListWindow.UpdateRecipeData(filteredRecipes);
        }
    }
}
