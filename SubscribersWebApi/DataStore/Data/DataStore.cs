using Infrastructure.Models;

namespace DataStore.Data;

public class DataBase
{
    public static List<SubscriberModel> Subscribers { get; set; } =
    [
        new SubscriberModel { Id = 1, Name = "Pelle"},
        new SubscriberModel { Id = 2, Name = "Lasse"},
        new SubscriberModel { Id = 3, Name = "Bosse"}
    ];
}
