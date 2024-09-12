using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Core.Entity;
public class Guest : IdentityUser
{
    public string City { get; set; }
}
