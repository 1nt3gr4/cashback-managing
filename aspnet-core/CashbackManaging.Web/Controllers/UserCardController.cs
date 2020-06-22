using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CashbackManaging.Model;
using CashbackManaging.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CashbackManaging.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserCardController : Controller
    {
        public UserCardController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private ApplicationDbContext DbContext { get; }

        [HttpPost("add/{cardId}")]
        public async Task<IActionResult> AddAsync(int cardId)
        {
            var user = await DbContext.Users.FindAsync(Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var card = await DbContext.Cards.FindAsync(cardId);

            var userCard = new UserCard
            {
                User = user,
                Card = card
            };

            await DbContext.UserCards.AddAsync(userCard);
            await DbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("delete/{cardId}")]
        public async Task<IActionResult> DeleteAsync(int cardId)
        {
            var user = await DbContext.Users.FindAsync(Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var userCard = await DbContext.UserCards
                .FirstOrDefaultAsync(uc => uc.Card.Id == cardId &&
                                           uc.User == user);

            DbContext.UserCards.Remove(userCard);
            await DbContext.SaveChangesAsync();

            return Ok();
        }
    }
}