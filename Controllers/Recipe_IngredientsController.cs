﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recitopia.Data;
using Recitopia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recitopia.Controllers
{
    public class Recipe_IngredientsController : AuthorizeController
    {
        private readonly RecitopiaDBContext _recitopiaDbContext;

        public Recipe_IngredientsController(RecitopiaDBContext recitopiaDbContext)
        {
            _recitopiaDbContext = recitopiaDbContext ?? throw new ArgumentNullException(nameof(recitopiaDbContext));
        }

        [Authorize]
        public async Task<ActionResult> Index(int recipeId)
        {
            var customerId = GetUserCustomerId(HttpContext.Session.GetString("CurrentUserCustomerId"));

            if (customerId == 0)
            {
                return RedirectToAction("CustomerLogin", "Customers");
            }
            var recipe = await _recitopiaDbContext.Recipe.FindAsync(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            var recipeIngredients = await _recitopiaDbContext.Recipe_Ingredients
                .Include(ri => ri.Ingredient)
                .Where(ri => ri.Customer_Id == customerId && ri.Recipe_Id == recipeId)
                .OrderBy(ri => ri.Ingredient.Ingred_name)
                .ToListAsync();

            ViewBag.RecipeName = recipe.Recipe_Name;
            ViewBag.RecipeNameID = recipeId;
            ViewBag.GramWieght = recipeIngredients.Sum(ri => ri.Amount_g);

            return View(recipeIngredients);
        }

        [HttpGet]
        public async Task<JsonResult> GetData(int recipeId)
        {
            var customerId = GetUserCustomerId(HttpContext.Session.GetString("CurrentUserCustomerId"));

            var recipeIngredientDetails = await _recitopiaDbContext.Recipe_Ingredients
                .Include(ri => ri.Ingredient)
                .Include(ri => ri.Recipe)
                .Where(ri => ri.Customer_Id == customerId && ri.Recipe_Id == recipeId)
                .Select(ri => new View_Angular_Recipe_Ingredients_Details()
                {
                    Id = ri.Id,
                    Customer_Id = ri.Customer_Id,
                    Ingredient_Id = ri.Ingredient_Id,
                    Ingred_name =  ri.Ingredient.Ingred_name,
                    Recipe_Id = ri.Recipe_Id,
                    Recipe_Name = ri.Recipe.Recipe_Name,
                    Amount_g = ri.Amount_g
                })
                .ToListAsync();

            return recipeIngredientDetails != null 
                ? Json(recipeIngredientDetails) 
                : Json(new { Status = "Failure" });
        }

        public async Task<ActionResult> Details(int id)
        {
            var recipeIngredients = await _recitopiaDbContext.Recipe_Ingredients.FindAsync(id);

            if (recipeIngredients == null)
            {
                return NotFound();
            }

            return View(recipeIngredients);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateFromAngularController([FromBody]List<View_Angular_Recipe_Ingredients_Details> recipeIngredientsDetails)
        {
            var recipeId = recipeIngredientsDetails.First().Recipe_Id;

            foreach (View_Angular_Recipe_Ingredients_Details detail in recipeIngredientsDetails)
            {
                // Dave: why only update if the weight is greater than zero?
                // Mat: I think I was working through some null or empty value issues. updated

                var recipeIngredient = await _recitopiaDbContext.Recipe_Ingredients
                        .SingleAsync(i => i.Id == detail.Id);                

                if (detail.Amount_g >= 0)
                {
                    recipeIngredient.Amount_g = detail.Amount_g;
                    
                }
                else
                {
                    recipeIngredient.Amount_g = 0;
                    
                }
                await _recitopiaDbContext.SaveChangesAsync();
            }

            var recipe = await _recitopiaDbContext.Recipe.SingleAsync(i => i.Recipe_Id == recipeId);
            recipe.LastModified = DateTime.UtcNow;

            await _recitopiaDbContext.SaveChangesAsync();

            return Json(recipeIngredientsDetails);
        }

        // GET: Recipe_Ingredients/Create
       public async Task<ActionResult> Create(int recipeID)
        {
            //get recipe name from db and pass in viewbag
            Recipe recipe = await _recitopiaDbContext.Recipe.FindAsync(recipeID);

            int CustomerId = GetUserCustomerId(HttpContext.Session.GetString("CurrentUserCustomerId"));
            if (CustomerId == 0)
            {
                return RedirectToAction("CustomerLogin", "Customers");
            }

            //Assign to temp local to put on view
            ViewBag.RecipeName = recipe.Recipe_Name;
            ViewBag.Rec_Id = recipeID;

            ViewBag.Ingredient_Id = new SelectList(_recitopiaDbContext.Ingredient.Where(m => m.Customer_Id == CustomerId).OrderBy(m => m.Ingred_name), "Ingredient_Id", "Ingred_name");
            ViewBag.Recipe_Id = new SelectList(_recitopiaDbContext.Recipe.Where(m => m.Customer_Id == CustomerId).OrderBy(m => m.Recipe_Name), "Recipe_Id", "Recipe_Name");

            //CREATE LIST OF PREVIOUS ADDED INGREDIENTS
            var recipeIngredients = await _recitopiaDbContext.Recipe_Ingredients
                            .Include(ri => ri.Recipe)
                            .Include(ri => ri.Ingredient)
                            .Where(ri => ri.Customer_Id == CustomerId && ri.Recipe_Id == recipeID)
                            .OrderBy(ri => ri.Ingredient.Ingred_name)
                            .Select(ri => new View_All_Recipe_Ingredients()
                            {
                                Id = ri.Id,
                                Customer_Id = ri.Customer_Id,
                                Recipe_Id = ri.Recipe_Id,
                                Ingredient_Id = ri.Ingredient_Id,
                                Amount_g = ri.Amount_g,
                                Ingred_name = ri.Ingredient.Ingred_name,
                                Ingred_Comp_name = ri.Ingredient.Ingred_Comp_name,
                                Cost_per_lb = ri.Ingredient.Cost_per_lb,
                                Cost = ri.Ingredient.Cost,
                                Package = ri.Ingredient.Package,
                                Recipe_Name = ri.Recipe.Recipe_Name
                            })
                            .ToListAsync();

            //build list to populate previously added items
            List<string> ingList = new List<string>();

            foreach (View_All_Recipe_Ingredients ingred in recipeIngredients)
            {
                if (ingred.Amount_g.ToString() != null)
                {
                    ingList.Add(ingred.Ingred_name + "/" + ingred.Amount_g.ToString() + "g");
                }
                else
                {
                    ingList.Add(ingred.Ingred_name + "/" + 0.ToString() + "g");
                }
            }

            ViewBag.Ingredients = ingList;

            return View();
        }

        // POST: Recipe_Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<ActionResult> Create([FromForm] Recipe_Ingredients recipe_Ingredients, int RID)
        {

            int CustomerId = GetUserCustomerId(HttpContext.Session.GetString("CurrentUserCustomerId"));
            if (CustomerId == 0)
            {
                return RedirectToAction("CustomerLogin", "Customers");
            }
            if (RID > 0)
            {

                recipe_Ingredients.Recipe_Id = RID;
                recipe_Ingredients.Customer_Id = CustomerId;
                await _recitopiaDbContext.Recipe_Ingredients.AddAsync(recipe_Ingredients);
                await _recitopiaDbContext.SaveChangesAsync();

                //DIRECT LINQ TO DB REPLACING STORED PROCEDURE
                Recipe recipeFind = await _recitopiaDbContext.Recipe.Where(i => i.Recipe_Id == recipe_Ingredients.Recipe_Id).SingleAsync();

                recipeFind.LastModified = DateTime.UtcNow;

                await _recitopiaDbContext.SaveChangesAsync();

                //CREATE LIST OF PREVIOUS ADDED INGREDIENTS
                var recipeIngredients = await _recitopiaDbContext.Recipe_Ingredients
                            .Include(ri => ri.Recipe)
                            .Include(ri => ri.Ingredient)
                            .Where(ri => ri.Customer_Id == CustomerId && ri.Recipe_Id == RID)
                            .OrderBy(ri => ri.Ingredient.Ingred_name)
                            .Select(ri => new View_All_Recipe_Ingredients()
                            {
                                Id = ri.Id,
                                Customer_Id = ri.Customer_Id,
                                Recipe_Id = ri.Recipe_Id,
                                Ingredient_Id = ri.Ingredient_Id,
                                Amount_g = ri.Amount_g,
                                Ingred_name = ri.Ingredient.Ingred_name,
                                Ingred_Comp_name = ri.Ingredient.Ingred_Comp_name,
                                Cost_per_lb = ri.Ingredient.Cost_per_lb,
                                Cost = ri.Ingredient.Cost,
                                Package = ri.Ingredient.Package,
                                Recipe_Name = ri.Recipe.Recipe_Name
                            })
                            .ToListAsync();


                //build list to populate previously added items
                List<string> ingList = new List<string>();

                foreach (View_All_Recipe_Ingredients ingred in recipeIngredients)
                {
                    if (ingred.Amount_g.ToString() != null)
                    {
                        ingList.Add(ingred.Ingred_name + "/" + ingred.Amount_g.ToString() + "g");
                    }
                    else
                    {
                        ingList.Add(ingred.Ingred_name + "/" + 0.ToString() + "g");
                    }

                }

                ViewBag.Ingredients = ingList;



                return RedirectToAction("Index", new { recipeID = recipe_Ingredients.Recipe_Id });
            }

            ViewBag.Ingredient_Id = new SelectList(_recitopiaDbContext.Ingredient.Where(m => m.Customer_Id == CustomerId).OrderBy(m => m.Ingred_name), "Ingredient_Id", "Ingred_name", recipe_Ingredients.Ingredient_Id);
            ViewBag.Recipe_Id = new SelectList(_recitopiaDbContext.Recipe.Where(m => m.Customer_Id == CustomerId).OrderBy(m => m.Recipe_Name), "Recipe_Id", "Recipe_Name", recipe_Ingredients.Recipe_Id);




            return View(recipe_Ingredients);
        }

        // GET: Recipe_Ingredients/Edit/5
       public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(0);
            }

            int CustomerId = GetUserCustomerId(HttpContext.Session.GetString("CurrentUserCustomerId"));
            if (CustomerId == 0)
            {
                return RedirectToAction("CustomerLogin", "Customers");
            }

            Recipe_Ingredients recipe_Ingredients = await _recitopiaDbContext.Recipe_Ingredients.FindAsync(id);
            if (recipe_Ingredients == null)
            {
                return NotFound();
            }

            //get recipe name from db and pass in viewbag
            Recipe recipe = await _recitopiaDbContext.Recipe.FindAsync(recipe_Ingredients.Recipe_Id);

            //Assign to temp local to put on view
            ViewBag.RecipeName = recipe.Recipe_Name;
            ViewBag.Rec_Id = recipe_Ingredients.Recipe_Id;


            ViewBag.Ingredient_Id = new SelectList(_recitopiaDbContext.Ingredient.Where(m => m.Customer_Id == CustomerId).OrderBy(m => m.Ingred_name), "Ingredient_Id", "Ingred_name", recipe_Ingredients.Ingredient_Id);
            ViewBag.Recipe_Id = new SelectList(_recitopiaDbContext.Recipe.Where(m => m.Customer_Id == CustomerId).OrderBy(m => m.Recipe_Name), "Recipe_Id", "Recipe_Name", recipe_Ingredients.Recipe_Id);
            return View(recipe_Ingredients);
        }

        // POST: Recipe_Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<ActionResult> Edit([FromForm] Recipe_Ingredients recipe_Ingredients)
        {

            int CustomerId = GetUserCustomerId(HttpContext.Session.GetString("CurrentUserCustomerId"));
            if (ModelState.IsValid)
            {
                recipe_Ingredients.Customer_Id = CustomerId;
                _recitopiaDbContext.Entry(recipe_Ingredients).State = EntityState.Modified;
                await _recitopiaDbContext.SaveChangesAsync();

                //DIRECT LINQ TO DB REPLACING STORED PROCEDURE
                Recipe recipeFind = await _recitopiaDbContext.Recipe.Where(i => i.Recipe_Id == recipe_Ingredients.Recipe_Id).SingleAsync();

                recipeFind.LastModified = DateTime.UtcNow;

                await _recitopiaDbContext.SaveChangesAsync();


                return RedirectToAction("Index", new { recipeID = recipe_Ingredients.Recipe_Id });
            }
            ViewBag.Ingredient_Id = new SelectList(_recitopiaDbContext.Ingredient.Where(m => m.Customer_Id == CustomerId).OrderBy(m => m.Ingred_name), "Ingredient_Id", "Ingred_name", recipe_Ingredients.Ingredient_Id);
            ViewBag.Recipe_Id = new SelectList(_recitopiaDbContext.Recipe.Where(m => m.Customer_Id == CustomerId).OrderBy(m => m.Recipe_Name), "Recipe_Id", "Recipe_Name", recipe_Ingredients.Recipe_Id);
            return View(recipe_Ingredients);
        }

        // GET: Recipe_Ingredients/Delete/5
       public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(0);
            }
            int CustomerId = GetUserCustomerId(HttpContext.Session.GetString("CurrentUserCustomerId"));
            if (CustomerId == 0)
            {
                return RedirectToAction("CustomerLogin", "Customers");
            }
            var recipe_Ingredients = await _recitopiaDbContext.Recipe_Ingredients.Where(m => m.Id == id).Include(r => r.Ingredient).Where(m => m.Customer_Id == CustomerId).Include(r => r.Recipe).Where(m => m.Customer_Id == CustomerId).ToListAsync();

          
            if (recipe_Ingredients == null)
            {
                return NotFound();
            }
            //GOT TO BE A BETTER WAY THAN BUILD THE MODEL BY HAND:/
            Recipe_Ingredients rIngreds = new Recipe_Ingredients();
            Ingredient tIngred = new Ingredient();
            Recipe tRec = new Recipe();

            foreach (Recipe_Ingredients thing in recipe_Ingredients)
            {
                tIngred = thing.Ingredient;
                tRec = thing.Recipe;
                
                rIngreds.Id = thing.Id;
                rIngreds.Ingredient_Id = thing.Ingredient_Id;
                rIngreds.Ingredient = tIngred;
                rIngreds.Recipe_Id = thing.Recipe_Id;
                rIngreds.Recipe = tRec;
                rIngreds.Customer_Id = thing.Customer_Id;
            }
            


            return View(rIngreds);
        }

        // POST: Recipe_Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Recipe_Ingredients recipe_Ingredients = await _recitopiaDbContext.Recipe_Ingredients.FindAsync(id);

            try
            {
                _recitopiaDbContext.Recipe_Ingredients.Remove(recipe_Ingredients);
                await _recitopiaDbContext.SaveChangesAsync();
                return RedirectToAction("Index", new { recipeID = recipe_Ingredients.Recipe_Id });
            }
            
            catch (InvalidOperationException) // This will catch SqlConnection Exception
            {
                ViewBag.ErrorMessage = "Uh Oh, There is a problem 2";
                return View(recipe_Ingredients);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "This was a problem deleting this Ingredient from this Recipe.";
                return View(recipe_Ingredients);
            }
        }
    }
}
