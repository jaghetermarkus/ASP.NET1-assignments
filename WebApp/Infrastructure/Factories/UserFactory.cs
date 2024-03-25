using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure;

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
}
