using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class MessageFactory
{
    public static ContactMessageEntity Create(ContactFormModel model)
    {
        try
        {
            if (model.ServiceId != 0)
            {
                return new ContactMessageEntity
                {
                    Message = model.Message,
                    ServiceId = model.ServiceId,
                    Created = DateTime.Now
                };
            }
            else
            {
                return new ContactMessageEntity
                {
                    Message = model.Message,
                    Created = DateTime.Now
                };
            }
        }
        catch { }
        return null!;
    }

    public static ContactMessageEntity Create(ContactEntity existingContact, string Message, int ServiceId)
    {
        try
        {
            if (ServiceId != 0)
            {

                return new ContactMessageEntity
                {
                    ContactId = existingContact.Id,
                    Contact = existingContact,
                    Message = Message,
                    ServiceId = ServiceId,
                    Created = DateTime.Now
                };
            }
            else
            {
                return new ContactMessageEntity
                {
                    ContactId = existingContact.Id,
                    Contact = existingContact,
                    Message = Message,
                    Created = DateTime.Now
                };
            }
        }
        catch { }
        return null!;
    }
}
