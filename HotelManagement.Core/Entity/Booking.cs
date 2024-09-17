namespace HotelManagement.Core.Entity;
public class Booking
{
    public int Id { get; set; }
    public string BookingReference { get; set; }
    public int GuestId { get; set; }
    public int RoomId { get; set; }
    public AppUser User { get; set; }
    public Room Room { get; set; }
    public Payment Payment { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; }
    public string SpecialRequests { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string CancellationReason { get; set; }
    public bool IsDeleted { get; set; }
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    CheckedIn,
    CheckedOut,
    Cancelled
}

public enum PaymentStatus
{
    Pending,
    PartiallyPaid,
    Paid,
    Refunded
}