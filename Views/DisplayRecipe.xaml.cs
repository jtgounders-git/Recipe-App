using Prog6221PoeRecipeAppP3.Util;
using System.Windows;

namespace Prog6221PoeRecipeAppP3.Views
{
    public partial class DisplayRecipe : Window
    {
        private Recipe _recipe;

        public DisplayRecipe(Recipe recipe)
        {
            InitializeComponent();
            _recipe = recipe;
            DataContext = _recipe; // Set the data context to the recipe
            LoadRecipeData();
        }

        private void LoadRecipeData()
        {
            tbRecipeName.Text = _recipe.Name;
            dgIngredients.ItemsSource = _recipe.Ingredients; // Bind ingredients to the data grid
            tbTotalCalories.Text = _recipe.TotalCalories.ToString();
            tbRecipeInstructions.Text = string.Join("\n", _recipe.Steps);

            // Show calorie warning if total calories exceed 300
            tbCalorieWarning.Visibility = _recipe.TotalCalories > 300 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
