using System.Threading.Tasks;
using CashbackManaging.Model;
using CashbackManaging.Model.Entities;
using CashbackManaging.Service;
using CashbackManaging.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CashbackManaging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        public AccountController(ApplicationDbContext dbContext, UserManagerService userManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        private ApplicationDbContext DbContext { get; }

        private UserManagerService UserManager { get; }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = new User
            {
                UserName = model.Login,
                Email = model.Email
            };

            await UserManager.CreateAsync(user, model.Password);
            await DbContext.SaveChangesAsync();
            var encodedJwt = UserManager.GetUserToken(user);

            return Json(new
            {
                access_token = encodedJwt,
                username = user.UserName
            });
        }
    }
}