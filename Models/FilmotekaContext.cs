using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class FilmotekaContext:DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Iznajmljivanje> Iznajmljivanja { get; set; }
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Iznajmljivanje> FilmoviKorisnici { get; set; }
        public DbSet<Zanr> Zanrovi { get; set; }
        public DbSet<Mesec> Meseci { get; set; }
        public DbSet<Filmoteka> Filmoteke { get; set; }
        public FilmotekaContext(DbContextOptions options):base(options)
        {
            
        }

    }
}