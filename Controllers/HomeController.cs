using BeerCraft.ViewModels;
using BeerCraft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerCraft.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RecipeViewModel viewModel = new RecipeViewModel();
            ViewBag.Message = "Create your own beer recipe.";
            ViewBag.Title = "Beer Your Way";
            return View(viewModel);
        }

        public JsonResult SaveRecipe(string Name, string Description, string Instructions, List<int> Ingredients)
        {
            try
            {
                string returnMessage = "Recipe " + Name + " with description: \"" + Description + "\" and instructions: \"" + Instructions + "\" and ingredients: ";
                RecipeViewModel model = new RecipeViewModel();
                foreach(var ingredientID in Ingredients)
                {
                    //Get the actual ingredient so it's name can be displayed
                    var ingredient = model.Ingredients.Where(x => x.IngredientID == ingredientID).SingleOrDefault();
                    returnMessage += ingredient.Name;
                    returnMessage += ", ";
                }
                returnMessage = returnMessage.Substring(returnMessage.Length - 2);
                returnMessage += " made it to the server, there is no database set up so it doesn't actually save anything.";
                return Json(new { success = 0, message = returnMessage });
            } catch (Exception ex)
            {
                return Json(new { success = 0, message = ex.Message });
            }
        }
        public JsonResult SearchRecipes(string Name)
        {
            try
            {
                RecipeViewModel model = new RecipeViewModel();
                Recipe recipe = model.Recipes.Where(x => x.Name == Name).FirstOrDefault();
                if(recipe == null)
                {
                    //Didn't find it, tell the user
                    return Json(new { success = 0, message = "No recipe found by that name." });
                }
                //Get the ingredient names
                List<string> ingredients = model.Ingredients.Where(x => recipe.Ingredients.Contains(x.IngredientID)).Select(x => x.Name).ToList();
                //Found it, return the recipe to the user
                return Json(new { success = 1, recipe = recipe, ingredients = ingredients });
            }
            catch(Exception ex)
            {
                return Json(new { success = 0, message = ex.Message });
            }
        }
    }
}