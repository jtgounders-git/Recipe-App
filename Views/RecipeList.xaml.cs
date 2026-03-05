using Prog6221PoeRecipeAppP3.Util;
using System.Collections.Generic;
using System.Windows;

namespace Prog6221PoeRecipeAppP3.Views
{
    public partial class RecipeList : Window
    {
        private List<Recipe> _recipes;

        public RecipeList(List<Recipe> recipes)
        {
            InitializeComponent();
            _recipes = recipes;
            dgRecipes.ItemsSource = _recipes;
        }

        public void UpdateRecipeData(List<Recipe> filteredRecipes)
        {
            dgRecipes.ItemsSource = filteredRecipes;
        }

        private void dgRecipes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            // Handle filter button click
            FilterRecipeList filterWindow = new FilterRecipeList(_recipes, this);
            filterWindow.ShowDialog();
        }
    }
}
