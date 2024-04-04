using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApp.Models;

public class AccountDetailsViewModel
{
    public BasicInfoViewModel BasicInfo { get; set; } = null!;
    public AddressModel AddressInfo { get; set; } = null!;

}
