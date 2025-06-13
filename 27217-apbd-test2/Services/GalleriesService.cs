using _27217_apbd_test2.Data;
using _27217_apbd_test2.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace _27217_apbd_test2.Services;

public interface IGalleriesService
{
    Task<GalleryExhibitionDto?> GetGalleryExhibitionsAsync(int galleryId);
}

public class GalleriesService : IGalleriesService
{
    private readonly AppDbContext _context;

    public GalleriesService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GalleryExhibitionDto?> GetGalleryExhibitionsAsync(int galleryId)
    {
        var gallery = await _context.Galleries
            .Include(g => g.Exhibitions)
            .ThenInclude(e => e.ExhibitionArtworks)
            .ThenInclude(ea => ea.Artwork)
            .ThenInclude(a => a.Artist)
            .FirstOrDefaultAsync(g => g.GalleryId == galleryId);

        if (gallery == null) return null;

        return new GalleryExhibitionDto
        {
            GalleryId = gallery.GalleryId,
            Name = gallery.Name,
            EstablishedDate = gallery.EstablishedDate,
            Exhibitions = gallery.Exhibitions.Select(e => new ExhibitionDto
            {
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                NumberOfArtworks = e.NumberOfArtworks,
                Artworks = e.ExhibitionArtworks.Select(ea => new ArtworkDto
                {
                    Title = ea.Artwork.Title,
                    YearCreated = ea.Artwork.YearCreated,
                    InsuranceValue = ea.InsuranceValue,
                    Artist = new ArtistDto
                    {
                        FirstName = ea.Artwork.Artist.FirstName,
                        LastName = ea.Artwork.Artist.LastName,
                        BirthDate = ea.Artwork.Artist.BirthDate
                    }
                }).ToList()
            }).ToList()
        };
    }
}