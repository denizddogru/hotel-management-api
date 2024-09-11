namespace HotelManagement.Core.Entity;
public class Review
{
    public  int  Id { get; set; }
    public int BookingId { get; set; }
    public Booking Booking { get; set; }
    public string Rating { get; set; }
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }

}
