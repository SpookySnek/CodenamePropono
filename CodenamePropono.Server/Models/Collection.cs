namespace CodenamePropono.Server.Models;

public class Collection
{
    public int Id { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public DateTime? UpdateDate { get; set; }

    public string? Description { get; set; }
    
    public string? Location { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
}
