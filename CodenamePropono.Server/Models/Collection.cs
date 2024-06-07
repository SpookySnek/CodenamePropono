using System.ComponentModel.DataAnnotations;

namespace CodenamePropono.Server.Models;

public class Collection
{
    public int Id { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public DateTime? UpdateDate { get; set; }

    [MaxLength(2048)]
    public string? Description { get; set; }
    
    [MaxLength(256)]
    public string? Location { get; set; }
    
    public int UserId { get; set; }
    
    public virtual required User User { get; set; }
    
    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
}
