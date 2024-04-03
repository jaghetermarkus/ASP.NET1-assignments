using System.Security.Claims;
using DataStore.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Services;

public class AccountService(UserManager<UserEntity> userManager, DataContext context, IConfiguration configuration)
{

    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly DataContext _context = context;
    private readonly IConfiguration _configuration = configuration;

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
