using Prog6221PoeRecipeAppP3.Util;
using System.Windows;

namespace Prog6221PoeRecipeAppP3.Views
{
    public partial class SearchRecipe : Window
    {
        private readonly RecipeService _recipeService;

        public SearchRecipe(RecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = txtSearchRecipeName.Text;
            var foundRecipe = _recipeService.FindRecipe(recipeName);

            if (foundRecipe != null)
            {
                var displayRecipeWindow = new DisplayRecipe(foundRecipe);
                displayRecipeWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Recipe not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
