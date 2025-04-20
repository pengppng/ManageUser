namespace ManageG5.Server.Models
{
    public class Permission
    {
        public Guid Id { get; set; }
        // public string IDB { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ICollection<RolePermission> RolePermissions { get; set; }
        public object Roles { get; internal set; }
    }
}