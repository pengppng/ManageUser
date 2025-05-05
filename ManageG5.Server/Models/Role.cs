using System.Security;

namespace ManageG5.Server.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }  = new List<RolePermission>();

        public ICollection<User> Users { get; set; } = new List<User>();

    }
}