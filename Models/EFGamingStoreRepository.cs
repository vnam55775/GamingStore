using System.Linq;
namespace GamingStore.Models
{
    public class EFGamingStoreRepository : IGamingStoreRepository
    {
        private GamingStoreDbContext context;
        public EFGamingStoreRepository(GamingStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Gaming> Gamings => context.Gamings;

        public void CreateGaming(Gaming b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteGaming(Gaming b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
        public void SaveGaming(Gaming b)
        {
            context.SaveChanges();
        }

    }
}
