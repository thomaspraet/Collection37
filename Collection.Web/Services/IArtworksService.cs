using Collection.Web.Models.Artworks;

namespace Collection.Web.Services
{
    public interface IArtworksService
    {
        bool ArtworkExists(int id);
        Task Create(ArtworkCreateVM model);
        Task Edit(ArtworkEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<ArtworkReadOnlyVM>> GetAll();
        Task Remove(int id);
    }
}