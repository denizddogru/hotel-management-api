using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Core.Entity;
public class Guest : IdentityUser
{

    //TODO : Im unsure about this part, revise for later.
    public  string Username { get; set; }
    public string Email {  get; set; }
    public string Password { get; set; }
}
