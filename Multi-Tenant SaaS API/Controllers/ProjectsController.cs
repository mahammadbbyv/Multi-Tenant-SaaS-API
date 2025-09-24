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
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITenantProvider _tenantProvider;
        public ProjectsController(ApplicationDbContext context, ITenantProvider tenantProvider)
        {
            _context = context;
            _tenantProvider = tenantProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectViewModel>>> GetProjects()
        {
            int tenantId = _tenantProvider.GetTenantId();
            var projects = await _context.Projects
                .Where(p => p.TenantId == tenantId)
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
                })
                .ToListAsync();
            return Ok(projects);
        }
    }
}
