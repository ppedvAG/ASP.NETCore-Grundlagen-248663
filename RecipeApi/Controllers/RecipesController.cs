using BusinessModel.Contracts;
using BusinessModel.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        // GET: api/<RecipesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recipes = await _recipeService.GetAll();
            return Ok(recipes);
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var recipe = await _recipeService.GetById(id);
            return recipe is null ? NotFound() : Ok(recipe);
        }

        // POST api/<RecipesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Recipe value)
        {
            try
            {
                await _recipeService.Create(value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest("Something went wrong");
            }
            return Ok(value);
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Recipe value)
        {
            try
            {
                var success = await _recipeService.Update(value);
                if (!success)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest("Something went wrong");
            }
            return Ok(value);
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _recipeService.Delete(id);
                if (!success)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest("Something went wrong");
            }
            return NoContent();
        }
    }
}
