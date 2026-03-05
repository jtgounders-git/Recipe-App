using Prog6221PoeRecipeAppP3.Util;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Prog6221PoeRecipeAppP3.Views
{
    public partial class ScaleRecipe : Window
    {
        private List<Ingredient> _ingredients;
        private AddRecipe _addRecipeWindow;

        public ScaleRecipe(List<Ingredient> ingredients, AddRecipe addRecipeWindow)
        {
            InitializeComponent();
            _ingredients = ingredients;
            _addRecipeWindow = addRecipeWindow;
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (cbScaleFactor.SelectedItem == null)
            {
                MessageBox.Show("Please select a scaling factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double scaleFactor = 1.0;

            if (cbScaleFactor.SelectedItem is ComboBoxItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Half":
                        scaleFactor = 0.5;
                        break;
                    case "Double":
                        scaleFactor = 2.0;
                        break;
                    case "Triple":
                        scaleFactor = 3.0;
                        break;
                }
            }

            foreach (var ingredient in _ingredients)
            {
                ingredient.Quantity *= scaleFactor;
                ingredient.Calories *= scaleFactor;
            }

            _addRecipeWindow.UpdateIngredientsDataGrid();
            Close();
        }
    }
}
