using System;
using System.Collections.Generic;
using Prog6221PoeRecipeAppP3.Views;

namespace Prog6221PoeRecipeAppP3.Util
{
    // Represents an ingredient in a recipe
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, double quantity, string unitOfMeasurement, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}
