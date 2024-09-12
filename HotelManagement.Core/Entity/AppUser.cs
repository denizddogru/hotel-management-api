using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Core.Entity;
public class AppUser : IdentityUser
{
    public string? City { get; set; }
}
