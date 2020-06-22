using System.Linq;
using System.Threading.Tasks;
using CashbackManaging.Model;
using CashbackManaging.Model.Entities;
using CashbackManaging.Service;
using CashbackManaging.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CashbackManaging.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CardController : Controller
    {
        public CardController(ApplicationDbContext dbContext, UserManagerService userManagerService)
        {
            DbContext = dbContext;
            UserManagerService = userManagerService;
        }

        private ApplicationDbContext DbContext { get; }

        private UserManagerService UserManagerService { get; }

        [HttpGet]
        public async Task<IActionResult> List(bool userOnly)
        {
            var user = await UserManagerService.GetUserAsync(User);
            var currentUserCards = await DbContext.UserCards
                .Where(uc => uc.User == user)
                .Select(uc => uc.Card)
                .ToListAsync();

            if (userOnly)
                return Json(currentUserCards
                    .Select(c => new CardModel
                    {
                        Id = c.Id,
                        FullName = c.FullName,
                        ShortName = c.ShortName,
                        MinCostPerYear = c.MinCostPerYear,
                        MaxCashbackPercent = c.MaxCashbackPercent,
                        CashbackLimitInRubles = c.CashbackLimitInRubles,
                        Base64Image = c.Base64Image,
                        HasCurrentUser = true,
                        DefaultCashbackPercent = c.DefaultCashbackPercent
                    })
                    .ToList());
            
            var result = await DbContext.Cards
                .Select(c => new CardModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    ShortName = c.ShortName,
                    MinCostPerYear = c.MinCostPerYear,
                    MaxCashbackPercent = c.MaxCashbackPercent,
                    CashbackLimitInRubles = c.CashbackLimitInRubles,
                    Base64Image = c.Base64Image,
                    DefaultCashbackPercent = c.DefaultCashbackPercent
                })
                .ToListAsync();

            foreach (var card in result.Where(c => currentUserCards.Select(uc => uc.Id).Contains(c.Id)))
            {
                card.HasCurrentUser = true;
            }

            return Json(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await UserManagerService.GetUserAsync(User);
            var card = await DbContext.Cards.FindAsync(id);
            
            var mapped = new CardModel
            {
                Id = card.Id,
                FullName = card.FullName,
                ShortName = card.ShortName,
                MinCostPerYear = card.MinCostPerYear,
                MaxCashbackPercent = card.MaxCashbackPercent,
                CashbackLimitInRubles = card.CashbackLimitInRubles,
                Base64Image = card.Base64Image,
                HasCurrentUser = await DbContext.UserCards.AnyAsync(uc => uc.User == user && uc.Card == card)
            };

            var cardCodes = await DbContext.CardMccCodeCashbacks
                .Where(cm => cm.Card == card)
                .Select(cm => new CardMccCodeCashbackModel
                {
                    Id = cm.Id,
                    CashbackPercentFrom = cm.CashbackPercentFrom,
                    MccCode = new MccCodeModel
                    {
                        Id = cm.MccCode.Id,
                        Code = cm.MccCode.Code,
                        Name = cm.MccCode.Name
                    }
                })
                .ToListAsync();
            mapped.CardMccCodeCashbacks = cardCodes;

            return Json(mapped);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CardModel model)
        {
            var card = new Card
            {
                ShortName = model.ShortName,
                Base64Image = model.Base64Image,
                MinCostPerYear = model.MinCostPerYear
            };

            await DbContext.Cards.AddAsync(card);
            await DbContext.SaveChangesAsync();

            return Ok();
        }
    }
}