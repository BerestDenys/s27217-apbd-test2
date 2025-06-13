using _27217_apbd_test2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _27217_apbd_test2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Artist>().HasData(
            new Artist { ArtistId = 1, FirstName = "Pablo", LastName = "Picasso", BirthDate = new DateTime(1881, 10, 25) },
            new Artist { ArtistId = 2, FirstName = "Frida", LastName = "Kahlo", BirthDate = new DateTime(1907, 7, 6) }
        );
        
        modelBuilder.Entity<Artwork>().HasData(
            new Artwork { ArtworkId = 1, ArtistId = 1, Title = "Guernica", YearCreated = 1937 },
            new Artwork { ArtworkId = 2, ArtistId = 2, Title = "The Two Fridas", YearCreated = 1939 }
        );
        
        modelBuilder.Entity<Gallery>().HasData(
            new Gallery { GalleryId = 1, Name = "Modern Art Space", EstablishedDate = new DateTime(2001, 9, 12) }
        );
        
        modelBuilder.Entity<Exhibition>().HasData(
            new Exhibition
            {
                ExhibitionId = 1,
                GalleryId = 1,
                Title = "20th Century Giants",
                StartDate = new DateTime(2024, 5, 1),
                EndDate = new DateTime(2024, 9, 1),
                NumberOfArtworks = 2
            }
        );
        
        modelBuilder.Entity<ExhibitionArtwork>().HasData(
            new ExhibitionArtwork
            {
                ExhibitionId = 1,
                ArtworkId = 1,
                InsuranceValue = 1_000_000m
            },
            new ExhibitionArtwork
            {
                ExhibitionId = 1,
                ArtworkId = 2,
                InsuranceValue = 800_000m
            }
        );
    }
}