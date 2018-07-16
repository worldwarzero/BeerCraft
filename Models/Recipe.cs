using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerCraft.Models
{
    public class Recipe
    {
        public Guid RecipeID { get; set; }
        public List<int> Ingredients { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
    }
}