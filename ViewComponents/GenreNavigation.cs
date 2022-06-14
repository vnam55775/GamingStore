using GamingStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IGamingStoreRepository repository;
        public GenreNavigation(IGamingStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Gamings
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
