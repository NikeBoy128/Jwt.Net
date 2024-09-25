using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using WebApplication1.Areas.Users.services;
using WebApplication1.models;

namespace WebApplication1.Areas.Users.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {

        private readonly CrudUserService _crudUserService;



        public userController(CrudUserService crudUserService)
        {
            _crudUserService = crudUserService;
        }



        [HttpPost]
        public async Task<ActionResult<Object>> create(User user) {
            

            var result= await _crudUserService.Create(user);

            if(result.Result is BadRequestObjectResult)
            {
                return result.Result;
            }

            var userId = result.Value;
            var response = new 
            {
                Id = userId,
                Message = "Información almacenada con éxito"
            };


            return Ok(response);

        }

    }
}
