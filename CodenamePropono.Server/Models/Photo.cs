using Microsoft.Build.Framework;

namespace CodenamePropono.Server.Models;

public class Photo
{
    public int Id { get; set; }
    
    public required string PhotoUrl { get; set; }

    public DateTime UploadDate { get; set; }
    
    public DateTime? PhotoDate { get; set; }

    public string? Description { get; set; }
    
    public string? Location { get; set; }
    
    public int CollectionId { get; set; }
    
    public Collection Collection { get; set; } = null!;
}

