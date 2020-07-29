using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsynchInnLab.Models;
using AsynchInnLab.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsynchInnLab.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //api/account/register
        [HttpPost, Route("register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = register.Email,
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName
            };

            //create user
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                //sign the user in if successful
                await _signInManager.SignInAsync(user, false);
                return Ok();
            }
            return BadRequest("Not a valid Registration");

            //do something to put this into the database
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
                if (result.Succeeded)
            {
                return Ok("logged in");
            }
            return BadRequest("invalid attempt");
        }
    }
}
