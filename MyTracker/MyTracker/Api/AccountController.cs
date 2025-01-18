using MyTracker.Helper;
using MyTracker.Helper.Constants;
using MyTracker.Models.AppModels;
using MyTracker.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MyTracker.Api
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class AccountController(ILogger<AccountController> logger, IConfiguration config, ILoginService loginService) : ControllerBase
    {

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (!loginService.IsValidUser(model))
                return base.Unauthorized(new { Message = ErrorMessages.WRONG_CREDENTIAL });

            if (loginService.HasAlreadyLogin(model))
                return base.Unauthorized(new { Message = ErrorMessages.ALREADY_LOGGED });

            var token  = TokenUtils.GenerateAccessToken(config, model.UserName, loginService.GetUserRole(model.UserName));
            loginService.SaveRefreshToken(new TokenResponse() { UserName = model.UserName, Token = token });

            return base.Ok(new { Token = token });
        }

        [HttpPost]
        //Authorize and authenticated
        public IActionResult Refresh(TokenResponse tokenResponse)
        {
            var storedRefreshToken = loginService.GetStoredRefreshToken(tokenResponse.UserName);

            // validate against the stored token
            if (storedRefreshToken != tokenResponse.Token)
                return base.Unauthorized(new { Message = ErrorMessages.TOKEN_MISSMATCH }); 

            tokenResponse.Token = TokenUtils.GenerateAccessTokenFromRefreshToken(config, tokenResponse.UserName, loginService.GetUserRole(tokenResponse.UserName));
            loginService.SaveRefreshToken(tokenResponse);
            return Ok(tokenResponse);
        }

    }
}
