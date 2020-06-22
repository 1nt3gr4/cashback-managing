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
    public class ShopController : Controller
    {
        public ShopController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private ApplicationDbContext DbContext { get; }

        private const decimal CircleRadius = 0.08m;

        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> ListAsync([FromBody] decimal[] position)
        {
            var coordX = position[0];
            var coordY = position[1];
            var result = await DbContext.Shops
                .Where(s => (s.Lattitude - coordX)*(s.Lattitude - coordX) +
                            (s.Longitude - coordY)*(s.Longitude - coordY) < CircleRadius*CircleRadius)
                .Select(s => new ShopModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Position = new [] { s.Lattitude, s.Longitude },
                    MccCode = s.MccCode.Code
                })
                .ToListAsync();

            foreach (var shop in result)
            {
                var casbhacks = await DbContext.CardMccCodeCashbacks
                    .Where(c => c.MccCode.Code == shop.MccCode)
                    .Take(10)
                    .OrderByDescending(c => c.CashbackPercentTo)
                    .Select(c => new CardMccCodeCashbackModel
                    {
                        Id = c.Id,
                        CashbackPercentFrom = c.CashbackPercentFrom,
                        CashbackPercentTo = c.CashbackPercentTo,
                        CardName = c.Card.ShortName
                    })
                    .ToListAsync();

                shop.CardCashbacks = casbhacks;
            }

            return Json(result);
        }

        [HttpPost]
        [Route("list/{id}")]
        public async Task<IActionResult> ListAsync(int id, [FromBody] decimal[] position)
        {
            var card = await DbContext.Cards.FindAsync(id);
            var cashbacks = await DbContext.CardMccCodeCashbacks
                .Where(c => c.Card.Id == card.Id)
                .Select(c => new CardMccCodeCashbackModel
                {
                    Id = c.Id,
                    CashbackPercentFrom = c.CashbackPercentFrom,
                    CashbackPercentTo = c.CashbackPercentTo,
                    CardName = c.Card.ShortName,
                    MccCode = new MccCodeModel
                    {
                        Id = c.MccCode.Id,
                        Code = c.MccCode.Code,
                        Name = c.MccCode.Name
                    }
                })
                .ToListAsync();
            var cashbacksIds = cashbacks.Select(c => c.MccCode.Id);
            var shops = await DbContext.Shops
                .Where(s => cashbacksIds.Contains(s.MccCode.Id))
                .Select(s => new ShopModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Position = new [] { s.Lattitude, s.Longitude },
                    MccCode = s.MccCode.Code
                })
                .ToListAsync();
            shops.ForEach(s => s.CardCashbacks = cashbacks
                .Where(c => c.MccCode.Code == s.MccCode)
                .ToList());

            return Json(shops);
        }
    }
}