namespace HotelManagement.Core.Entity;
public class Room
{
    public int Id { get; set; }

    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }

    public string RoomNumber { get; set; }

    public int Capacity { get; set; }

    public RoomType RoomType { get; set; }

    public decimal PricePerNight { get; set; }

    public List<Booking> Bookings { get; set; }
    public string Description { get; set; }

 
}

public enum RoomType
{
    Single,
    Double,
    Suite,
    Deluxe
    // Add other types as needed
}