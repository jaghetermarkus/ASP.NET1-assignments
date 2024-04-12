using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ContactFactory
{
    public static ContactEntity Create(ContactFormModel model)
    {
        try
        {
            return new ContactEntity
            {
                Email = model.Email,
                FullName = model.FullName,
                Messages = new List<ContactMessageEntity>
                {
                    MessageFactory.Create(model)
                }
            };
        }
        catch { }
        return null!;
    }
}
