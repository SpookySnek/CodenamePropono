namespace CodenamePropono.Server.DTOs.Outgoing;

public class PhotoGetDTO
{
    public int Id { get; set; }
    
    public string PhotoUrl { get; set; } = null!;

    public string UploadDate { get; set; } = null!;
    
    public string? PhotoDate { get; set; }

    public string? Description { get; set; }
    
    public string? Location { get; set; }

    public int CollectionId { get; set; }
}