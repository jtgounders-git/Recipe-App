using Prog6221PoeRecipeAppP3.Util;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Prog6221PoeRecipeAppP3.Views
{
    public partial class AddRecipe : Window
    {
        private readonly RecipeService _recipeService;
        private List<Ingredient> _ingredients;

        public AddRecipe(RecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
            _ingredients = new List<Ingredient>();
            dgIngredients.ItemsSource = _ingredients;
        }

        private void BtnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = tbIngredientName.Text;
            string unitOfMeasurement = tbIngredientUnit.Text;
            string foodGroup = tbIngredientFoodGroup.Text;

            if (double.TryParse(tbIngredientCalories.Text, out double calories) &&
                double.TryParse(tbIngredientQuantity.Text, out double quantity))
            {
                var ingredient = new Ingredient(name, quantity, unitOfMeasurement, calories, foodGroup);
                _ingredients.Add(ingredient);
                dgIngredients.Items.Refresh();

                // Clear input fields
                tbIngredientName.Text = "";
                tbIngredientUnit.Text = "";
                tbIngredientFoodGroup.Text = "";
                tbIngredientCalories.Text = "";
                tbIngredientQuantity.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter valid values for quantity and calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = tbRecipeName.Text;
            var steps = tbRecipeInstructions.Text.Split('\n').ToList();

            var totalCalories = _ingredients.Sum(i => i.Calories);
            if (totalCalories > 300)
            {
                MessageBox.Show($"Warning: The recipe '{recipeName}' exceeds 300 calories.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            _recipeService.AddNewRecipe(recipeName, _ingredients, steps);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipe scaleRecipeWindow = new ScaleRecipe(_ingredients, this);
            scaleRecipeWindow.ShowDialog();
        }

        public void UpdateIngredientsDataGrid()
        {
            dgIngredients.Items.Refresh();
        }
    }
}
