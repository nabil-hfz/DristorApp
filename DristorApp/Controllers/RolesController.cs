using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using Microsoft.AspNetCore.Mvc;

namespace DristorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRepository<Role, int> _ingredientsRepository;

        public RolesController(IRepository<Role, int> ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetIngredients()
        {
            return await _ingredientsRepository.GetAllAsync();
        }

    }
}
