using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multi_Tenant_SaaS_API.Data;
using Multi_Tenant_SaaS_API.Models;
using Multi_Tenant_SaaS_API.ViewModels;
using Multi_Tenant_SaaS_API.Services;

namespace Multi_Tenant_SaaS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITenantProvider _tenantProvider;
        public UsersController(ApplicationDbContext context, ITenantProvider tenantProvider)
        {
            _context = context;
            _tenantProvider = tenantProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            int tenantId = _tenantProvider.GetTenantId();
            var users = await _context.Users
                .Where(u => u.TenantId == tenantId)
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email
                })
                .ToListAsync();
            return Ok(users);
        }
    }
}
