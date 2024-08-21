
using Lesson_10_identity.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lesson_10_identity.Datas;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
        builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole<int> { Id = 2, Name = "Buyer", NormalizedName = "BUYER" },
            new IdentityRole<int> { Id = 3, Name = "Seller", NormalizedName = "SELLER" }
        );

        var hasher = new PasswordHasher<AppUser>();

        builder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = 1,
                UserName = "adminUser",
                NormalizedUserName = "ADMINUSER",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                PasswordHash = hasher.HashPassword(null, "AdminPassword123"),
                Name = "Admin",
            },
            new AppUser
            {
                Id = 2,
                UserName = "buyerUser",
                NormalizedUserName = "BUYERUSER",
                Email = "buyer@example.com",
                NormalizedEmail = "BUYER@EXAMPLE.COM",
                PasswordHash = hasher.HashPassword(null, "BuyerPassword123"),
                Name = "Buyer",
            },
            new AppUser
            {
                Id = 3,
                UserName = "sellerUser",
                NormalizedUserName = "SELLERUSER",
                Email = "seller@example.com",
                NormalizedEmail = "SELLER@EXAMPLE.COM",
                PasswordHash = hasher.HashPassword(null, "SellerPassword123"),
                Name = "Seller",
            }
        );

        builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, 
            new IdentityUserRole<int> { UserId = 2, RoleId = 2 }, 
            new IdentityUserRole<int> { UserId = 3, RoleId = 3 }  
        );
    }




    // Tables
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }
}