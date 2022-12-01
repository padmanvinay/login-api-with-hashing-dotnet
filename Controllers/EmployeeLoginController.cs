using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Data;
using User.Models;
using BC = BCrypt.Net.BCrypt;


namespace User.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeLoginController : Controller
    {
        private readonly EmployeeLoginDbContext dbContext;

        public EmployeeLoginController(EmployeeLoginDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> RegisterUser(Register register)
        {
            var user = new Register()
            {
                id=Guid.NewGuid(),
                email=register.email,
                password=BC.HashPassword(register.password),
                employeeName=register.employeeName,
                city=register.city,              
                department=register.department
            };
            await dbContext.EmployeeLogins.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUser(Login login )
        
        {
            
            var log = dbContext.EmployeeLogins.SingleOrDefault(x => x.email == (login.email));                
            if (log != null && BC.Verify(login.password,log.password))
            {
                return Ok("Login Succesfull");
            }
            else
            {
                return Ok("Login failed");
            }
        }
    }
}
