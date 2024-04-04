using System.Security.Claims;
using DataStore.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Services;

public class AccountService(UserManager<UserEntity> userManager, DataContext context, IConfiguration configuration)
{

    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly DataContext _context = context;
    private readonly IConfiguration _configuration = configuration;

    public async Task<UserModel> GetUserAsync(ClaimsPrincipal claimsPrincipal)
    {
        var Identifer = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var userEntity = await _context.Users.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == Identifer);
        if (userEntity != null)
        {
            return UserFactory.Create(userEntity!);
        }
        return null!;
    }

    public async Task<bool> UpdateBasicInfoAsync(ClaimsPrincipal claimsPrincipal, BasicInfoViewModel basicInfo)
    {
        try
        {
            var Identifer = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == Identifer);
            if (userEntity != null)
            {
                userEntity.FirstName = basicInfo.FirstName;
                userEntity.LastName = basicInfo.LastName;
                userEntity.PhoneNumber = basicInfo.PhoneNumber;
                userEntity.Biography = basicInfo.Biography;

                _context.Update(userEntity);
                await _context.SaveChangesAsync();

                return true;
            }
        }
        catch { }
        return false;
    }

    public async Task<bool> UpdateAddressAsync(ClaimsPrincipal claimsPrincipal, AddressModel addressInfo)
    {
        try
        {
            var Identifer = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEntity = await _context.Users.Include(a => a.Address).FirstOrDefaultAsync(x => x.Id == Identifer);
            if (userEntity!.Address != null)
            {
                userEntity.Address = AddressFactory.Update(userEntity.Address, addressInfo);
                // AddressFactory ?
                // userEntity.Address!.AddressLine_1 = addressInfo.AddressLine_1;
                // userEntity.Address!.AddressLine_2 = addressInfo.AddressLine_2;
                // userEntity.Address!.PostalCode = addressInfo.PostalCode;
                // userEntity.Address!.City = addressInfo.City;
            }
            else
            {
                userEntity.Address = AddressFactory.Create(addressInfo);
                // userEntity.Address = new AddressEntity
                // {
                //     AddressLine_1 = addressInfo.AddressLine_1,
                //     AddressLine_2 = addressInfo.AddressLine_2,
                //     PostalCode = addressInfo.PostalCode,
                //     City = addressInfo.City,
                // };
            }

            _context.Update(userEntity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch { }
        return false;
    }

    public async Task<bool> UploadUserProfileImageAsync(ClaimsPrincipal userClaims, IFormFile file)
    {
        try
        {
            if (userClaims != null && file != null && file.Length != 0)
            {
                var user = await _userManager.GetUserAsync(userClaims);
                if (user != null)
                {
                    var fileName = $"pImg_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["ProfileUploadPath"]!, fileName);

                    using var fs = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fs);

                    user.ProfileImage = fileName;
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }
        }
        catch { }

        return false;
    }
}
