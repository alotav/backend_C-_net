using Microsoft.EntityFrameworkCore;

// contexto de la BD

namespace Backend.Models
{
    // heredamos de dbcontext
    public class StoreContext : DbContext
    {
        // constructor
        public StoreContext(DbContextOptions<StoreContext> options) : base (options) { }
        
        // representamos entidades:
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}
