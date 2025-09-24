namespace Multi_Tenant_SaaS_API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
