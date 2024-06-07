namespace CodenamePropono.Server.DTOs.Outgoing;

public class CollectionGetDTO
{
    public int Id { get; set; }
    
    public string CreationDate { get; set; } = null!;
    
    public string? UpdateDate { get; set; }

    public string? Description { get; set; }
    
    public string? Location { get; set; }
    
    public int UserId { get; set; }
    
    public List<PhotoGetDTO>? Photos { get; set; } = new List<PhotoGetDTO>();
}