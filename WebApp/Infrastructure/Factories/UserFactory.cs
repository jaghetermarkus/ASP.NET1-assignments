using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Models.ViewModels;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity Create(SignUpViewModel model)
    {
        try
        {
            return new UserEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
        }
        catch { }
        return null!;

    }

    public static UserModel Create(UserEntity userEntity)
    {
        try
        {
            return new UserModel
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email!,
                PhoneNumber = userEntity.PhoneNumber,
                Biography = userEntity.Biography,
                AddressLine_1 = userEntity.Address?.AddressLine_1,
                AddressLine_2 = userEntity.Address?.AddressLine_2,
                PostalCode = userEntity.Address?.PostalCode,
                City = userEntity.Address?.City
            };
        }
        catch { }
        return null!;
    }

}
