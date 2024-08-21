using Lesson_10_identity.Entities.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace Lesson_10_identity.Entities.Concretes;

public class AppUser : IdentityUser<int>, BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? City { get; set; }
    public string? Picture { get; set; }
    public DateTime? CreatedDate { get; set; }

    // Navigation Property
    public ICollection<Product>? Products { get; set; }
}
