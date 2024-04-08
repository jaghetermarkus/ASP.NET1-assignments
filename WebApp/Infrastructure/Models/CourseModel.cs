using Infrastructure.Entities;

namespace Infrastructure.Models;

public class CourseModel
{
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
    public string Reviews { get; set; } = null!;
    public int Articles { get; set; }
    public int Downloads { get; set; }
    public int Subscribers { get; set; }
    public int Followers { get; set; }
    public string Description { get; set; } = null!;
    public List<string> Learn { get; set; } = null!;
    public List<CourseDetailsEntity> Details { get; set; } = null!;
    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
}
