using System.Linq;
using System.Threading.Tasks;
using CashbackManaging.Model;
using CashbackManaging.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CashbackManaging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MccCodeController : Controller
    {
        public MccCodeController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private ApplicationDbContext DbContext { get; }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var result = await DbContext.MccCodes
                .Select(c => new MccCodeModel
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name
                })
                .ToListAsync();

            return Json(result);
        }
    }
}