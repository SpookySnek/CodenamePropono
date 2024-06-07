namespace CodenamePropono.Server.Models;

public class User
{
    public int Id { get; set; }
    
    public required string Username { get; set; }
    
    public string? Location { get; set; }
    
    public string? Bio { get; set; }
    
    public string? ProfilePicture { get; set; }
    
    public DateTime JoinDate { get; set; }
    
    public DateTime LastLogin { get; set; }

    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();
}