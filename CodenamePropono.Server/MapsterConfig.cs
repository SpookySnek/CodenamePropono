using Mapster;

namespace CodenamePropono.Server;

public static class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<DTOs.Incoming.PhotoCreateDTO, Models.Photo>.NewConfig()
            .Map(dest => dest.PhotoUrl, src => src.PhotoUrl)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.CollectionId, src => src.CollectionId);
        
        TypeAdapterConfig<DTOs.Incoming.CollectionCreateDTO, Models.Collection>.NewConfig()
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.UserId, src => src.UserId);
        
        TypeAdapterConfig<DTOs.Incoming.PhotoCreateDTO, Models.Photo>.NewConfig()
            .Map(dest => dest.PhotoUrl, src => src.PhotoUrl)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.CollectionId, src => src.CollectionId);
        
        TypeAdapterConfig<Models.Photo, DTOs.Outgoing.PhotoGetDTO>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.PhotoUrl, src => src.PhotoUrl)
            .Map(dest => dest.UploadDate, src => src.UploadDate.ToString("yyyy-MM-dd"))
            .Map(dest => dest.PhotoDate, src => src.PhotoDate.Value.ToString("yyyy-MM-dd"))
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.CollectionId, src => src.CollectionId);
        
        TypeAdapterConfig<Models.Collection, DTOs.Outgoing.CollectionGetDTO>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CreationDate, src => src.CreationDate.ToString("yyyy-MM-dd"))
            .Map(dest => dest.UpdateDate, src => src.UpdateDate.Value.ToString("yyyy-MM-dd"))
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Photos, src => src.Photos.Adapt<List<DTOs.Outgoing.PhotoGetDTO>>());

        TypeAdapterConfig<Models.User, DTOs.Outgoing.UserGetDTO>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Username, src => src.Username)
            .Map(dest => dest.Location, src => src.Location)
            .Map(dest => dest.Bio, src => src.Bio)
            .Map(dest => dest.ProfilePicture, src => src.ProfilePicture)
            .Map(dest => dest.JoinDate, src => src.JoinDate.ToString("yyyy-MM-dd"))
            .Map(dest => dest.LastLogin, src => src.LastLogin.ToString("yyyy-MM-dd"))
            .Map(dest => dest.Collections, src => src.Collections.Adapt<List<DTOs.Outgoing.CollectionGetDTO>>());

    }
}