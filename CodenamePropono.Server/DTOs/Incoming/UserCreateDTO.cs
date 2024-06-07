namespace CodenamePropono.Server.DTOs.Incoming;

public class UserCreateDTO
{
    public required string Username { get; set; }
    
    public string? Location { get; set; }
    
    public string? Bio { get; set; }
    
    public string? ProfilePicture { get; set; }
}