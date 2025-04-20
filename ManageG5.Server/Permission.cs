namespace ManageG5.Server
{
    public class Permission
    {
        public Guid Id { get; set; }
        // public string IDB { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<Role> Roles { get; set; } = new();
    }
}