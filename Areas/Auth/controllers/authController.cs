using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Auth.Dto;
using WebApplication1.Areas.Auth.services;

namespace WebApplication1.Areas.Auth.controllers
{
    public class authController
    {

        private readonly AuthService _authService;


        public authController(AuthService authService)
        {

            _authService = authService;

        }


        [HttpPost("login")]

        public async Task<ActionResult<object>> login([FromBody] userDto userDto)
        {

            var response = await _authService.run(userDto);

            if(response.Result is BadRequestObjectResult)
            {
                return response.Result;
            }


            return response;

        }

    }
}
