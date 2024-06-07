using System.ComponentModel.DataAnnotations;

namespace CodenamePropono.Server.Models;

public class User
{
    public int Id { get; set; }
    
    [MaxLength(32)]
    public required string Username { get; set; }
    
    [MaxLength(256)]
    public string? Location { get; set; }
    
    [MaxLength(2048)]
    public string? Bio { get; set; }
    
    [MaxLength(256)]
    //TODO: Implement validation attribute to ensure that the URL is a valid URL, change name to ProfilePictureUrl
    public string? ProfilePicture { get; set; }
    
    public DateTime JoinDate { get; set; }
    
    public DateTime LastLogin { get; set; }

    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();
}