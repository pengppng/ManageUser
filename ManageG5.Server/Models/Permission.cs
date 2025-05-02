using System.ComponentModel.DataAnnotations.Schema;

namespace ManageG5.Server.Models
{
    public class Permission
    {
        public Guid Id { get; set; }
        // public string IDB { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        
        [NotMapped]
        public ICollection<RolePermission> RolePermissions { get; set; }= new List<RolePermission>();
        public Role? Role { get; internal set; }
        public List<string> Roles { get; set; } = new();


        
    }
}