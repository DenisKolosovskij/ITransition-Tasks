using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_4.Models;

namespace WebTask.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect("~/Account/Login");
            }

            return View(_userManager.Users.ToList());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Block(List<string> selectedUsers)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            foreach (var userId in selectedUsers)
            {
                var user = await _userManager.FindByIdAsync(userId);
                user.Status = 1;
                user.LockoutEnabled = true;
                user.LockoutEnd = System.DateTimeOffset.Now.AddDays(36_135.0);
                await _userManager.UpdateAsync(user);
                if (user.Id == currentUser.Id)
                {
                    await _signInManager.SignOutAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Unblock(List<string> selectedUsers)
        {
            foreach (var userId in selectedUsers)
            {
                var user = await _userManager.FindByIdAsync(userId);
                user.Status = 0;
                user.LockoutEnabled = false;
                user.LockoutEnd = null;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(List<string> selectedUsers)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            bool signOut = false;
            foreach (var userId in selectedUsers)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user.Id == currentUser.Id) signOut = true;
                await _userManager.DeleteAsync(user);
            }
            if (signOut)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}