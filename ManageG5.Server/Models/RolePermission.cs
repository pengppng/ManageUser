namespace ManageG5.Server.Models
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }

}
