using Multi_Tenant_SaaS_API.Data;
using System.Security.Claims;

namespace Multi_Tenant_SaaS_API.Services
{
    public interface ITenantProvider
    {
        int GetTenantId();
    }

    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int GetTenantId()
        {
            // Example: get tenant id from claims or header
            var claim = _httpContextAccessor.HttpContext?.User?.FindFirst("tenant_id");
            if (claim != null && int.TryParse(claim.Value, out int tenantId))
                return tenantId;
            throw new Exception("Tenant not found");
        }
    }
}
