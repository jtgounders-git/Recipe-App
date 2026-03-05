using Prog6221PoeRecipeAppP3.Util;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Prog6221PoeRecipeAppP3.ViewModels
{
    public class RecipeViewModel : INotifyPropertyChanged
    {
        private readonly Recipe _recipe;

        public RecipeViewModel(Recipe recipe)
        {
            _recipe = recipe;
            RecipeName = _recipe.Name;
            Ingredients = new ObservableCollection<Ingredient>(_recipe.Ingredients); // Ensure using Ingredient here
            TotalCalories = _recipe.TotalCalories;
            RecipeInstructions = string.Join("\n", _recipe.Steps);
        }

        public string RecipeName
        {
            get => _recipe.Name;
            set
            {
                _recipe.Name = value;
                RaisePropertyChanged(nameof(RecipeName));
            }
        }

        public ObservableCollection<Ingredient> Ingredients { get; set; } // Use Ingredient here

        private double _totalCalories;
        public double TotalCalories
        {
            get => _totalCalories;
            set
            {
                _totalCalories = value;
                RaisePropertyChanged(nameof(TotalCalories));
            }
        }

        public string RecipeInstructions
        {
            get => string.Join("\n", _recipe.Steps);
            set
            {
                _recipe.Steps = new List<string>(value.Split(separator, StringSplitOptions.RemoveEmptyEntries));
                RaisePropertyChanged(nameof(RecipeInstructions));
            }
        }

        private static readonly string[] separator = { "\n" };

        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
