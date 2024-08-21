namespace Lesson_10_identity.Entities.Abstracts;

public interface BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; }
}
