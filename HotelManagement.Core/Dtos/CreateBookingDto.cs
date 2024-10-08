﻿namespace HotelManagement.Core.Dtos;
public class CreateBookingDto
{
    public int RoomId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
}
