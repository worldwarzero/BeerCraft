using BeerCraft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerCraft.ViewModels
{
    public class RecipeViewModel
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Recipe> Recipes { get; set; }

        public RecipeViewModel()
        {
            this.Ingredients = GetListOIngredients();
            this.Recipes = GetListORecipes();
        }

        public List<Ingredient> GetListOIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(new Ingredient
            {
                IngredientID = 8,
                Name = "Apple",
                Description = "What made Johnny Appleseed famous"
            });
            ingredients.Add(new Ingredient
            {
                IngredientID = 7,
                Name = "Corn",
                Description = "A vegetable that is frequently uneaten by children"
            });
            ingredients.Add(new Ingredient
            {
                IngredientID = 6,
                Name = "Corn Syrup",
                Description = "Food Syrup which is made form the starch of corn"
            });
            ingredients.Add(new Ingredient
            {
                IngredientID = 1,
                Name = "Grain",
                Description = "A small, hard, dry seed, with or without an attached hull or fruit layer"
            });
            ingredients.Add(new Ingredient {
                IngredientID = 0,
                Name = "Hops",
                Description = "The flowers of the hop plant Humulus Iupulus. Used primarily as a flavouring and stability agent to beer"
            });
            ingredients.Add(new Ingredient
            {
                IngredientID = 5,
                Name = "Malt",
                Description = "Germinated cereal grains that have been dried"
            });
            ingredients.Add(new Ingredient
            {
                IngredientID = 4,
                Name = "Orange",
                Description = "A citrus fruit that adds flavor"
            });
            ingredients.Add(new Ingredient
            {
                IngredientID = 2,
                Name = "Water",
                Description = "A tastless, flavorless, liquid"
            });
            ingredients.Add(new Ingredient
            {
                IngredientID = 3,
                Name = "Yeast",
                Description = "Eukaryotic, single-celled microorganisms classified as memebers of the fungus kingdom"
            });

            return ingredients;
        }

        public List<Recipe> GetListORecipes()
        {
            List<Recipe> recipes = new List<Recipe>();
            List<Ingredient> ingredients = GetListOIngredients();

            recipes.Add(new Recipe
            {
                Name = "Blue Moon",
                Description = "Belgian White owned by MillerCoors.",
                Ingredients = new List<int>()
                {
                    ingredients.Where(x => x.Name == "Water").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Malt").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Corn Syrup").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Hops").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Yeast").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Orange").Select(x => x.IngredientID).SingleOrDefault()
                },
                Instructions = "Boil the water, add the yeast along with the malt. Add orange to taste, hops and corn syrup come at the very end."
            });
            recipes.Add(new Recipe
            {
                Name = "Coors Light",
                Description = "Light beer from Coors",
                Ingredients = new List<int>()
                {
                    ingredients.Where(x => x.Name == "Water").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Yeast").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Hops").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Malt").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Corn").Select(x => x.IngredientID).SingleOrDefault()
                },
                Instructions = "Boil water, throw all of the ingredients in, let sit for a week"
            });
            recipes.Add(new Recipe
            {
                Name = "Angry Orchard",
                Description = "Delicious apple cider",
                Ingredients = new List<int>()
                {
                    ingredients.Where(x => x.Name == "Water").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Apple").Select(x => x.IngredientID).SingleOrDefault(),
                    ingredients.Where(x => x.Name == "Yeast").Select(x => x.IngredientID).SingleOrDefault(),
                },
                Instructions = "Take apple sauce and add alcohol"
            });

            return recipes;
        }
    }
}