using Core.Constants;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Serilog;
using Services.BL.Interfaces;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    


    public class CustomerController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public CustomerController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("Onboarding/User/CreateUser")]

        public async Task<IActionResult> CreateUser(UserRegisterModel model)
        {
            var response = await _authService.CreateUser(model);
            Log.Warning("UserIntegrationResponse : {@Response}", response);
            return Ok(response);
        }

        
        
        [HttpPost("Onboarding/User/CreateAdmin")]

        public async Task<IActionResult> CreateAdmin(UserRegisterModel model)
        {
            var response = await _authService.CreateAdmin(model);
            Log.Warning("UserIntegrationResponse : {@Response}", response);
            return Ok(response);
        }

       
        [HttpPost("Onboarding/User/CreateStaff")]
        public async Task<IActionResult> CreateStaff(UserRegisterModel model)
        {
            var response = await _authService.CreateStaff(model);
            Log.Warning("UserIntegrationResponse : {@Response}", response);
            return Ok(response);
        }



        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var respone = await _authService.Login(model);
            return Ok(
                new
                {
                    token = respone.Message,
                    user = respone.data
                });
        }

    }
}
