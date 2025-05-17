using AutoMapper;
using Collection.Web.Models;
using Collection.Web.Models.Artworks;

namespace Collection.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Artwork, ArtworkReadOnlyVM>();
            CreateMap<ArtworkCreateVM, Artwork>();
            CreateMap<ArtworkEditVM, Artwork>().ReverseMap();
        }
    }
}
