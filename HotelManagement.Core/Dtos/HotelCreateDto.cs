namespace HotelManagement.Core.Dtos;
public record HotelCreateDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public int StarRating { get; set; }
}