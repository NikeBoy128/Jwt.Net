using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Auth.Dto;
using WebApplication1.Areas.Users.services;
using WebApplication1.context;

namespace WebApplication1.Areas.Auth.services
{
    public class AuthService
    {

        private readonly PasswordService _passwordService;
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;


        public AuthService (PasswordService passwordService,AppDbContext context,JwtService jwtService)
        {

            _passwordService = passwordService;
            _context = context;
            _jwtService = jwtService;

        }



        async public Task<ActionResult<object>> run(userDto userDto)
        {

            var findUserByEmail= await _context.users.FirstOrDefaultAsync(u=>u.email==userDto.email);

            if (findUserByEmail == null) {


                return new BadRequestObjectResult(new {
                    status = StatusCodes.Status400BadRequest,
                    messageStatus = "Usuario no encontrado"
                });
            
            }


            var verifyPassword = _passwordService.compare(userDto.password, findUserByEmail.password);


            if (!verifyPassword) {

                return new BadRequestObjectResult(new {

                    status = StatusCodes.Status400BadRequest,
                    messageStatus = "Contraseña incorrecta"
                });
            
            }

            var response = new
            {
                accesToken = _jwtService.generateTokens(findUserByEmail.id, findUserByEmail.email),
            };


            return response;


            

        }
    }
}
