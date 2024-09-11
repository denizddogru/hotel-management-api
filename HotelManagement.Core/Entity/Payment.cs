namespace HotelManagement.Core.Entity;
public class Payment
{
    public int Id { get; set; }
    public Booking Booking { get; set; }
    public int BookingId { get; set; }
    public string Amount { get; set; }
    public string PaymentDate { get; set; }
    public string PaymentMethod { get; set; }

}
