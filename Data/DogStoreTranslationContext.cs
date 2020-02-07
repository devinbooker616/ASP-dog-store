using Microsoft.EntityFrameworkCore;

namespace DogStoreTranslation.Data
{
    public class DogStoreTranslationContext : DbContext
    {
        public DogStoreTranslationContext(
           DbContextOptions<DogStoreTranslationContext> options)
           : base(options)
        {
        }
        public DbSet<DogStoreTranslation.Models.DogProduct> DogProduct { get; set; }
    }
}