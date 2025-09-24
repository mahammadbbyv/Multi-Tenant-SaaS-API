using System.Collections.Generic;

namespace Multi_Tenant_SaaS_API.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
