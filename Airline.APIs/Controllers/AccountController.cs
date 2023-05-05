using AirLine.APIs.Dtos;
using AirLine.APIs.Erorrs;
using AirLine.Core.Entities.Identity;
using AirLine.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirLine.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManger;
		private readonly ITokenService _tokenService;

		public AccountController(UserManager<AppUser> userManager,
			SignInManager<AppUser> signInManger,
			ITokenService tokenService)
		{
			_userManager = userManager;
			_signInManger = signInManger;
			_tokenService = tokenService;
		}
		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
		{
			var user = await _userManager.FindByEmailAsync(loginDto.Email);
			if (user == null) return Unauthorized(new ApiResponse(401));
			var result = await _signInManger.CheckPasswordSignInAsync(user, loginDto.Password, false);
			if (!result.Succeeded) return Unauthorized(new ApiResponse(401));


			return Ok(new UserDto()
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = await _tokenService.CreateToken(user, _userManager)
			});
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			if (CheckEmailExistAsync(registerDto.Email).Result.Value)
			{
				return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = new[] { "Email address is in use" } });
			}
			var user = new AppUser()
			{
				DisplayName = registerDto.DisplayName,
				Email = registerDto.Email,
				UserName = registerDto.Email.Split('@')[0],
				PhoneNumber = registerDto.PhoneNumber,

			};

			var result = await _userManager.CreateAsync(user, registerDto.Password);

			if (!result.Succeeded) return BadRequest(new ApiResponse(400));

			return Ok(new UserDto()
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Token = await _tokenService.CreateToken(user, _userManager)
			});
		}
		[HttpGet("emailexists")]
		public async Task<ActionResult<bool>> CheckEmailExistAsync(string email)
		{
			return await _userManager.FindByEmailAsync(email) != null;
		}
	}
}
