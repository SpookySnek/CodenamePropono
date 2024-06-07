using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace CodenamePropono.Server.Models;

public class Photo
{
    public int Id { get; set; }
    
    [MaxLength(256)]
    //TODO: Implement validation attribute to ensure that the URL is a valid URL
    public required string PhotoUrl { get; set; }

    public DateTime UploadDate { get; set; }
    
    public DateTime? PhotoDate { get; set; }

    [MaxLength(2048)]
    public string? Description { get; set; }
    
    [MaxLength(256)]
    public string? Location { get; set; }
    
    public int CollectionId { get; set; }
    
    public virtual Collection Collection { get; set; } = null!;
}

