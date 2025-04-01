using AutoMapper;
using BackEnd.Class;  // Si Personne se trouve dans le namespace BackEnd.Class
using BackEnd.Models; // Si PersonneModel se trouve dans le namespace BackEnd.Models

public class MappingProfile : Profile
{
    public MappingProfile()
   {
        CreateMap<Personne, PersonneModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Prenom, opt => opt.MapFrom(src => src.Prenom))
            .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.Nom))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.Telephone))
            .ForMember(dest => dest.Adresse, opt => opt.MapFrom(src => src.Adresse))
            .ForMember(dest => dest.Ville, opt => opt.MapFrom(src => src.Ville))
            .ForMember(dest => dest.CodePostal, opt => opt.MapFrom(src => src.CodePostal))
            .ForMember(dest => dest.Pays, opt => opt.MapFrom(src => src.Pays))
            .ForMember(dest => dest.IsConnected, opt => opt.MapFrom(src => src.IsConnected))
            .ForMember(dest => dest.LastConnexion, opt => opt.MapFrom(src => src.IsConnected ? DateTime.Now : src.LastConnexion));
    }
}
