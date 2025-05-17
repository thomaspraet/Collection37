using AutoMapper;
using Collection.Web.Data;
using Collection.Web.Models;
using Collection.Web.Models.Artworks;
using Microsoft.EntityFrameworkCore;

namespace Collection.Web.Services;

public class ArtworksService(ApplicationDbContext _context, IMapper _mapper) : IArtworksService
{
    public async Task<List<ArtworkReadOnlyVM>> GetAll()
    {
        var data = await _context.Artworks.ToListAsync();

        var viewData = _mapper.Map<List<ArtworkReadOnlyVM>>(data);
        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.Artworks.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return null;
        }
        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.Artworks.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(ArtworkEditVM model)
    {
        var artwork = _mapper.Map<Artwork>(model);
        _context.Update(artwork);
        await _context.SaveChangesAsync();
    }

    public async Task Create(ArtworkCreateVM model)
    {
        var artwork = _mapper.Map<Artwork>(model);
        _context.Add(artwork);
        await _context.SaveChangesAsync();
    }

    public bool ArtworkExists(int id)
    {
        return _context.Artworks.Any(e => e.Id == id);
    }
}
