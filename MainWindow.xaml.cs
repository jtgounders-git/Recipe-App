using Prog6221PoeRecipeAppP3.Util;
using Prog6221PoeRecipeAppP3.Views;
using System.Windows;

namespace Prog6221PoeRecipeAppP3
{
    public partial class MainWindow : Window
    {
        private readonly RecipeService recipeService;

        public MainWindow()
        {
            InitializeComponent();
            recipeService = new RecipeService();
        }

        private void BtnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipe(recipeService);
            addRecipeWindow.Owner = this;
            addRecipeWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addRecipeWindow.ShowDialog();
        }

        private void BtnRecipeList_Click(object sender, RoutedEventArgs e)
        {
            var recipes = recipeService.GetAllRecipes();
            var recipeListWindow = new RecipeList(recipes);
            recipeListWindow.Owner = this;
            recipeListWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            recipeListWindow.ShowDialog();
        }

        private void BtnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            var searchRecipeWindow = new SearchRecipe(recipeService);
            searchRecipeWindow.Owner = this;
            searchRecipeWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            searchRecipeWindow.ShowDialog();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
