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
    public class TenantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TenantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TenantViewModel>>> GetTenants()
        {
            var tenants = await _context.Tenants
                .Select(t => new TenantViewModel { Id = t.Id, Name = t.Name })
                .ToListAsync();
            return Ok(tenants);
        }
    }
}
