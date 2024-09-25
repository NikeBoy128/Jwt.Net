using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.context;
using WebApplication1.models;

namespace WebApplication1.Areas.Users.services
{
    public class CrudUserService
    {
        private readonly AppDbContext _context;
        private readonly PasswordService _passwordService;
        public CrudUserService(AppDbContext context, PasswordService passwordService)
        {

            _context = context;
            _passwordService = passwordService;
        }




        public async Task<ActionResult<long>> Create(User user)
        {
            var finUserByEmail = await _context.users.FirstOrDefaultAsync(u => u.email == user.email);
            if (finUserByEmail != null)
            {
                return new BadRequestObjectResult(new
                {
                   
                    status = StatusCodes.Status400BadRequest,
                    messageStatus = "El correo ya se encuentra registrado"
                });
            }
            user.password = _passwordService.hash(user.password);
            var userCreated = await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            Console.WriteLine(userCreated.Entity.id);
            return (userCreated.Entity.id);
        }
    }
}
