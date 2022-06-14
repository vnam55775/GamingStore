using System.Linq;
namespace GamingStore.Models
{
    public interface IGamingStoreRepository
    {
        IQueryable<Gaming> Gamings { get; }

        void SaveGaming(Gaming b);
        void CreateGaming(Gaming b);
        void DeleteGaming(Gaming b);
    }
}