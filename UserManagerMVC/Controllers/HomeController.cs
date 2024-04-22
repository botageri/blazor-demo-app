using BlazorDemo.Application.Users.Get;
using BlazorDemo.Application.Users.GetAll;
using BlazorDemo.Application.Users.SignIn;
using BlazorDemo.Domain.Users;
using JwtForDotNetCore6;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UserManagerMVC.Models.SignIn;


namespace UserManagerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IJwtProvider _jwtProvider;

        public HomeController(IMediator mediator, IJwtProvider jwtProvider)
        {
            _mediator = mediator;
            _jwtProvider = jwtProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInUser signInUser)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            var email = signInUser.Email;
            var password = signInUser.Password;

            var userSignInSucceeded = await _mediator
                .Send(new SignInUserCommand(email, password));

            if (userSignInSucceeded)
            {
                var user = await _mediator
                    .Send(new GetUserByEmailAndPasswordQuery(email, password));

                var token = _jwtProvider.Generate(new Member()
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                });

                HttpContext.Session.SetString("Token", token);

                return RedirectToAction("Index", "Users");
            }

            return RedirectToAction("Index", "Home");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!string.IsNullOrEmpty(context.HttpContext.Request.Query["culture"]))
            {
                CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(context.HttpContext.Request.Query["culture"]);
            }
            base.OnActionExecuting(context);
        }
    }
}
