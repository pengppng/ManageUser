using ManageG5.Server.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --- Relationship: User -> Role ---
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
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
        var readPermissionId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var writePermissionId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var deletePermissionId = Guid.Parse("33333333-3333-3333-3333-333333333333");

        
        modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = readPermissionId, Name = "read",  },
            new Permission { Id = writePermissionId, Name = "write", },
            new Permission { Id = deletePermissionId, Name = "delete", }
        );

        // --- Seed Roles ---
        var superAdminRoleId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var adminRoleId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var hrAdminRoleId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        var employeeRoleId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = superAdminRoleId, Name = "Super Admin", Description = "Has full access" },
            new Role { Id = adminRoleId, Name = "Admin", Description = "Admin privileges" },
            new Role { Id = hrAdminRoleId, Name = "HR Admin", Description = "HR admin privileges" },
            new Role { Id = employeeRoleId, Name = "Employee", Description = "Standard employee" }
        );

        // --- Seed RolePermissions ---
        modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission { RoleId = superAdminRoleId, PermissionId = readPermissionId },
            new RolePermission { RoleId = superAdminRoleId, PermissionId = writePermissionId },
            new RolePermission { RoleId = superAdminRoleId, PermissionId = deletePermissionId },
            new RolePermission { RoleId = adminRoleId, PermissionId = readPermissionId },
            new RolePermission { RoleId = adminRoleId, PermissionId = writePermissionId },
            new RolePermission { RoleId = adminRoleId, PermissionId = deletePermissionId },
            new RolePermission { RoleId = hrAdminRoleId, PermissionId = readPermissionId },
            new RolePermission { RoleId = employeeRoleId, PermissionId = readPermissionId }
        );


        // --- Seed Users ---
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000001",
                Name = "David Wagner",
                Username = "davidWagnerGG",
                Email = "david_wagner@example.com",
                PhoneNumber = "0999999999",
                RoleId = superAdminRoleId,
                // Role = new Role { Id = Guid.NewGuid(), Name = "Super Admin", Description = "Has full access" },
                CreatedAt = DateTime.Parse("2015-10-24"),
                UpdatedAt = DateTime.Parse("2015-10-24")
            },
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000002",
                Name = "Ina Hogan",
                Username = "inaHogan007",
                Email = "ina_hogan@example.com",
                PhoneNumber = "0888888888",
                RoleId = adminRoleId,
                // Role = new Role { Id = Guid.NewGuid(), Name = "Super Admin", Description = "Has full access" },
                CreatedAt = DateTime.Parse("2015-10-24"),
                UpdatedAt = DateTime.Parse("2015-10-24")
            },
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000003",
                Name = "John Smith",
                Username = "johnnyS",
                Email = "john@example.com",
                PhoneNumber = "0911111111",
                RoleId = adminRoleId,
                CreatedAt = DateTime.Parse("2020-09-20"),
                UpdatedAt = DateTime.Parse("2020-09-20")
            },
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000004",
                Name = "Sara Lee",
                Username = "saraLee",
                Email = "sara@example.com",
                PhoneNumber = "0922222222",
                RoleId = hrAdminRoleId,
                CreatedAt = DateTime.Parse("2021-03-15"),
                UpdatedAt = DateTime.Parse("2021-03-15")
            },
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000005",
                Name = "Bruce Wayne",
                Username = "batman",
                Email = "bruce@example.com",
                PhoneNumber = "0933333333",
                RoleId = hrAdminRoleId,
                CreatedAt = DateTime.Parse("2022-01-01"),
                UpdatedAt = DateTime.Parse("2022-01-01")
            },
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000006",
                Name = "Clark Kent",
                Username = "superman",
                Email = "clark@example.com",
                PhoneNumber = "0944444444",
                RoleId = adminRoleId,
                CreatedAt = DateTime.Parse("2022-02-01"),
                UpdatedAt = DateTime.Parse("2022-02-01")
            },
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000007",
                Name = "Peter Parker",
                Username = "spidey",
                Email = "peter@example.com",
                PhoneNumber = "0955555555",
                RoleId = employeeRoleId,
                CreatedAt = DateTime.Parse("2022-03-01"),
                UpdatedAt = DateTime.Parse("2022-03-01")
            },
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000008",
                Name = "Tony Stark",
                Username = "ironman",
                Email = "tony@example.com",
                PhoneNumber = "0966666666",
                RoleId = superAdminRoleId,
                CreatedAt = DateTime.Parse("2022-04-01"),
                UpdatedAt = DateTime.Parse("2022-04-01")
            },
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000009",
                Name = "Diana Prince",
                Username = "wonderwoman",
                Email = "diana@example.com",
                PhoneNumber = "0977777777",
                RoleId = adminRoleId,
                CreatedAt = DateTime.Parse("2022-05-01"),
                UpdatedAt = DateTime.Parse("2022-05-01")
            },
            new User
            {
                Id = "u00000000-0000-0000-0000-000000000010",
                Name = "Steve Rogers",
                Username = "cap",
                Email = "steve@example.com",
                PhoneNumber = "0988888888",
                RoleId = hrAdminRoleId,
                CreatedAt = DateTime.Parse("2022-06-01"),
                UpdatedAt = DateTime.Parse("2022-06-01")
            }
        );


        // --- Seed Documents ---
        modelBuilder.Entity<Document>().HasData(
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000001",// Id = Guid.NewGuid().ToString(),
                Name = "Annual Report 2024",
                Description = "Company performance 2024",
                CreatedAt = DateTime.Parse("2024-01-15")
            },
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000002", //Id = Guid.NewGuid().ToString(),
                Name = "Employee Handbook",
                Description = "Company policies",
                CreatedAt = DateTime.Parse("2024-02-10")
            },
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000003",
                Name = "Marketing Strategy",
                Description = "2024 Q1 goals",
                CreatedAt = DateTime.Parse("2024-03-01")
            },
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000004",
                Name = "Budget Forecast",
                Description = "Next year's projections",
                CreatedAt = DateTime.Parse("2024-04-12")
            },
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000005",
                Name = "IT Guidelines",
                Description = "Infrastructure rules",
                CreatedAt = DateTime.Parse("2024-05-20")
            },
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000006",
                Name = "Security Policy",
                Description = "Company-wide security practices",
                CreatedAt = DateTime.Parse("2024-06-25")
            },
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000007",
                Name = "Hiring Plan",
                Description = "Recruitment targets",
                CreatedAt = DateTime.Parse("2024-07-15")
            },
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000008",
                Name = "Meeting Minutes",
                Description = "Board meetings notes",
                CreatedAt = DateTime.Parse("2024-08-05")
            },
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000009",
                Name = "Training Manual",
                Description = "New hire onboarding",
                CreatedAt = DateTime.Parse("2024-09-18")
            },
            new Document
            {
                Id = "10000000-0000-0000-0000-000000000010",
                Name = "CSR Report",
                Description = "Corporate Social Responsibility update",
                CreatedAt = DateTime.Parse("2024-10-10")
            }
        );
    }
}
