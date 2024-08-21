using Lesson_10_identity.Entities.Abstracts;

namespace Lesson_10_identity.Entities.Concretes;

public class Product : BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public DateTime? CreatedDate { get; set; }

    // Foreign Key
    public int UserId { get; set; }
    public int CategoryId { get; set; }

    // Navigation Property
    public AppUser? User { get; set; }
    public Category? Category { get; set; }
}
