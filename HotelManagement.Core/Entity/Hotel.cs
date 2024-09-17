namespace HotelManagement.Core.Entity;
public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string StarRating { get; set; }
    public List<Room> Rooms { get; set; }


}
