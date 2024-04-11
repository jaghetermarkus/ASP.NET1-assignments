using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class SubscribeFactory
{
    public static SubscriberEntity Create(SubscriberFormModel model)
    {
        try
        {
            return new SubscriberEntity
            {
                Email = model.Email,
                DailyNewsletter = model.DailyNewsletter,
                AdvertisingUpdates = model.AdvertisingUpdates,
                WeekinReview = model.WeekinReview,
                EventUpdates = model.EventUpdates,
                StartupsWeekly = model.StartupsWeekly,
                Podcasts = model.Podcasts
            };
        }
        catch { }
        return null!;
    }
}
