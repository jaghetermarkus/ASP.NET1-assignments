using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.ViewModels;

public class NewsletterViewModel
{
    [EmailAddress]
    [Required(ErrorMessage = "An valid email is required")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Display(Name = "Daily Newsletter")]
    public bool DailyNewsletter { get; set; }

    [Display(Name = "Advertising Updates")]
    public bool AdvertisingUpdates { get; set; }

    [Display(Name = "Week in Review")]
    public bool WeekinReview { get; set; }

    [Display(Name = "Event Updates")]
    public bool EventUpdates { get; set; }

    [Display(Name = "Startups Weekly")]
    public bool StartupsWeekly { get; set; }

    [Display(Name = "Podcasts")]
    public bool Podcasts { get; set; }

}
