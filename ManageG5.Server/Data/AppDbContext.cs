using ManageG5.Server.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --- Role-Permission many-to-many setup ---
        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);

        // --- Seed Permissions ---
        var readPermissionId = Guid.NewGuid();
        var writePermissionId = Guid.NewGuid();
        var deletePermissionId = Guid.NewGuid();

        modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = readPermissionId, Name = "read" },
            new Permission { Id = writePermissionId, Name = "write" },
            new Permission { Id = deletePermissionId, Name = "delete" }
        );

        // --- Seed Roles ---
        var superAdminRoleId = Guid.NewGuid();
        var adminRoleId = Guid.NewGuid();
        var hrAdminRoleId = Guid.NewGuid();
        var employeeRoleId = Guid.NewGuid();

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = superAdminRoleId, Name = "Super Admin", Description = "Has full access" },
            new Role { Id = adminRoleId, Name = "Admin", Description = "Admin privileges" },
            new Role { Id = hrAdminRoleId, Name = "HR Admin", Description = "HR admin privileges" },
            new Role { Id = employeeRoleId, Name = "Employee", Description = "Standard employee" }
        );

        // --- Seed RolePermissions ---
        modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission { RoleId = 1, PermissionId = readPermissionId },
            new RolePermission { RoleId = 1, PermissionId = writePermissionId },
            new RolePermission { RoleId = 1, PermissionId = deletePermissionId },
            new RolePermission { RoleId = 2, PermissionId = readPermissionId },
            new RolePermission { RoleId = 2, PermissionId = writePermissionId },
            new RolePermission { RoleId = 2, PermissionId = deletePermissionId },
            new RolePermission { RoleId = 3, PermissionId = readPermissionId },
            new RolePermission { RoleId = 4, PermissionId = readPermissionId }
        );


        // --- Seed Users ---
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = "David Wagner",
                Username = "davidWagnerGG",
                Email = "david_wagner@example.com",
                PhoneNumber = "0999999999",
                RoleId = Guid.NewGuid().ToString(),
                Role = new Role { Id = Guid.NewGuid(), Name = "Super Admin", Description = "Has full access" },
                CreatedAt = DateTime.Parse("2015-10-24"),
                UpdatedAt = DateTime.Parse("2015-10-24")
            }
        );

        // --- Seed Documents ---
        modelBuilder.Entity<Document>().HasData(
            new Document
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Annual Report 2024",
                Description = "Company performance 2024",
                CreatedAt = DateTime.Parse("2024-01-15")
            },
            new Document
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Employee Handbook",
                Description = "Company policies",
                CreatedAt = DateTime.Parse("2024-02-10")
            }
        );
    }
}
