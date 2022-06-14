using Microsoft.AspNetCore.Mvc;
using GamingStore.Models;
using System.Linq;
using GamingStore.Models.ViewModels;

namespace GamingStore.Controllers
{
    public class HomeController : Controller
    {
        private IGamingStoreRepository repository;

        public int PageSize = 3;
        public HomeController(IGamingStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string genre, int gamingPage = 1)
         => View(new GamingListViewModel
         {
             Gamings = repository.Gamings
         .Where(p => genre == null || p.Genre == genre)
         .OrderBy(p => p.GamingID)
         .Skip((gamingPage - 1) * PageSize)
         .Take(PageSize),
             PagingInfo = new PagingInfo
             {
                 CurrentPage = gamingPage,
                 ItemsPerPage = PageSize,
                 TotalItems = genre == null ?
                 repository.Gamings.Count() :repository.Gamings.Where(e =>e.Genre == genre).Count()
             },
             CurrentGenre = genre
         });
    }
}
