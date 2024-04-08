using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class AddressFactory
{
    public static AddressEntity Create(AddressModel model)
    {
        try
        {
            return new AddressEntity
            {
                AddressLine_1 = model.AddressLine_1!,
                AddressLine_2 = model.AddressLine_2!,
                PostalCode = model.PostalCode!,
                City = model.City!
            };
        }
        catch { }
        return null!;
    }


    public static AddressEntity Update(AddressEntity existingEntity, AddressModel model)
    {
        try
        {
            existingEntity.AddressLine_1 = model.AddressLine_1!;
            existingEntity.AddressLine_2 = model.AddressLine_2;
            existingEntity.PostalCode = model.PostalCode!;
            existingEntity.City = model.City!;

            return existingEntity;
        }
        catch { }
        return null!;
    }
}
