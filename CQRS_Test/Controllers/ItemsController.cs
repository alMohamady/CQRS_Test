using CQRS_lib.Data.Models;
using CQRS_lib.Reos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsController(IItemsRepo repo)
        {
            _repo = repo;
        }

        private readonly IItemsRepo _repo;


        [HttpGet]
        public async Task<IActionResult> GetItems()
        { 
           return Ok(_repo.GetItems());
        }

        [HttpPost]
        public async Task<IActionResult> InsertItem(Items  item)
        {
            _repo.InsertItem(item);
            return Ok(item);
        }

    }
}
