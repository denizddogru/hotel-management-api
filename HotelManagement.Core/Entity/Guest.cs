using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Core.Entity;
public class Guest : IdentityUser
{
    //TODO : Im unsure about this part, revise for later.
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}
