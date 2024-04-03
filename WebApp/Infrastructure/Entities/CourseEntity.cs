using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class CourseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int CourseNumber { get; set; }
    public string Title { get; set; } = null!;
    public bool IsBestSeller { get; set; }
    public bool IsDigital { get; set; }
    public string Author { get; set; } = null!;
    public string OriginalPrice { get; set; } = null!;
    public string? DiscountPrice { get; set; }
    public int Hours { get; set; }
    public decimal? LikesInProcent { get; set; }
    public string? LikesInNumbers { get; set; }
    public string? CourseImageUrl { get; set; }

    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
}
