namespace CodenamePropono.Server.DTOs.Outgoing;

public class UserGetDTO
{
    public int Id { get; set; }
    
    public required string Username { get; set; }
    
    public string? Location { get; set; }
    
    public string? Bio { get; set; }
    
    public string? ProfilePicture { get; set; }

    public string JoinDate { get; set; } = null!;
    
    public string LastLogin { get; set; } = null!;

    public List<CollectionGetDTO>? Collections { get; set; } = new List<CollectionGetDTO>();
}