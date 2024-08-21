using Lesson_10_identity.Entities.Abstracts;

namespace Lesson_10_identity.Entities.Concretes;

public class Category: BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedDate { get; set; }

    // NAvigation Property
    public ICollection<Product>? Products { get; set; }
}
