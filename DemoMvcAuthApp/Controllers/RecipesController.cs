using BusinessModel.Contracts;
using BusinessModel.Data;
using DemoMvcApp.Mappers;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    [Authorize] // Fuer gesamten Controller sperren
    public class RecipesController : Controller
    {
        private const string SummaryErrorKey = "";
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        // GET: RecipesController
        [AllowAnonymous] // Explizit freigeben
        public async Task<ActionResult<IEnumerable<RecipeViewModel>>> IndexAsync()
        {
            var recipes = await _recipeService.GetAll();
            return View(recipes.Select(x => x.ToViewModel()));
        }

        // GET: RecipesController/Details/5
        [AllowAnonymous] // Explizit freigeben
        public async Task<ActionResult<RecipeViewModel>> DetailsAsync(int id)
        {
            var recipe = await _recipeService.GetById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe.ToViewModel());
        }

        // GET: RecipesController/Create
        [Authorize(Roles = Seed.ADMIN_ROLE)] // Wichtig, um den Aufruf via Url zu verhindern
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipesController/Create
        [HttpPost, Authorize(Roles = Seed.ADMIN_ROLE)] // Verhindern, dass das mittels Tools wie Postman umgangen werden kann
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRecipeViewModel model)
        {
            // ModelState kommt von der Controller Basisklasse und
            // enthält alle Informationen über den Status der Validierungen
            if (ModelState.IsValid)
            {
                try
                {
                    _recipeService.Create(model.ToDomainModel());

                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Fehler beim Erstellen des Rezepts");
                    ModelState.AddModelError(SummaryErrorKey, ex.Message);
                }

            } 
            else
            {
                // Fehler sammeln und ausgeben
                var errors = ModelState.Values.SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage);
                ModelState.AddModelError(SummaryErrorKey, string.Join(Environment.NewLine, errors));
            }

            // Bereits eingegebene Daten zurückgeben, 
            // da sonst eingebene Daten verloren gehen
            return View(model);
        }

        // GET: RecipesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
