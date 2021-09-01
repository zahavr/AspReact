using API.Dtos;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace API.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly TokenService _tokenService;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
		{
			AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);

			if (user == null) return Unauthorized();

			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

			if (result.Succeeded)
				return CreateUserObject(user);

			return Unauthorized();
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
				return BadRequest("Email taken");

			if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
				return BadRequest("Username taken");

			AppUser user = new AppUser()
			{
				DisplayName = registerDto.DisplayName,
				Email = registerDto.Email,
				UserName = registerDto.Email
			};

			IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);

			if (result.Succeeded)
				return CreateUserObject(user);

			return BadRequest("Problem register user");
		}

		[Authorize]
		[HttpGet]
		public async Task<ActionResult<UserDto>> GetCurrentUser()
		{
			AppUser user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

			return CreateUserObject(user);
		}

		private UserDto CreateUserObject(AppUser user) =>
			new UserDto()
			{
				DisplayName = user.DisplayName,
				Image = null,
				Token = _tokenService.CreateToken(user),
				Username = user.UserName
			};
	}
}
