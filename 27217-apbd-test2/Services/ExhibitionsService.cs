using _27217_apbd_test2.Data;
using _27217_apbd_test2.Models.DTOs;
using _27217_apbd_test2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _27217_apbd_test2.Services;

public interface IExhibitionsService
{
    Task<bool> AddExhibitionAsync(AddExhibitionRequest request);
}

public class ExhibitionsService : IExhibitionsService
{
    private readonly AppDbContext _context;

    public ExhibitionsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddExhibitionAsync(AddExhibitionRequest request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var gallery = await _context.Galleries.FirstOrDefaultAsync(g => g.Name == request.Gallery);
            if (gallery == null) return false;

            var exhibition = new Exhibition
            {
                Title = request.Title,
                GalleryId = gallery.GalleryId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                NumberOfArtworks = request.Artworks.Count
            };

            _context.Exhibitions.Add(exhibition);
            await _context.SaveChangesAsync();

            foreach (var art in request.Artworks)
            {
                var artwork = await _context.Artworks.FindAsync(art.ArtworkId);
                if (artwork == null)
                {
                    await transaction.RollbackAsync();
                    return false;
                }

                _context.ExhibitionArtworks.Add(new ExhibitionArtwork
                {
                    ExhibitionId = exhibition.ExhibitionId,
                    ArtworkId = artwork.ArtworkId,
                    InsuranceValue = art.InsuranceValue
                });
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}