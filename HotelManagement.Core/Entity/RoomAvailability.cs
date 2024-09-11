namespace HotelManagement.Core.Entity;
public class RoomAvailability
{
    public int Id { get; set; }
    public Room Room { get; set; }
    public int RoomId { get; set; }
    public DateTime Date { get; set; }
    public bool IsAvailable { get; set; }

}
