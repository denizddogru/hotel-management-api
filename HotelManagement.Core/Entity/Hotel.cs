namespace HotelManagement.Core.Entity;
public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public int StarRating { get; set; }
    public List<string> Amenities { get; set; }


}
