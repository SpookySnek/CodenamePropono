namespace CodenamePropono.Server.DTOs.Incoming;

public class CollectionCreateDTO
{
    public string? Description { get; set; }
    
    public string? Location { get; set; }
    
    public int UserId { get; set; }
}