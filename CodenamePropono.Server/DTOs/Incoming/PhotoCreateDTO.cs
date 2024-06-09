namespace CodenamePropono.Server.DTOs.Incoming;

public class PhotoCreateDTO
{
    public required string PhotoUrl { get; set; }
    
    public string? Description { get; set; }
    
    public string? PhotoDate { get; set; }
    
    public string? Location { get; set; }
    
    public int CollectionId { get; set; }
}