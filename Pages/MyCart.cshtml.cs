using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GamingStore.MyTagHelper;
using GamingStore.Models;
using System.Linq;
namespace GamingStore.Pages
{
    public class MyCartModel : PageModel
    {
        private IGamingStoreRepository repository;
        public MyCartModel(IGamingStoreRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long gamingId, string returnUrl)
        {
            Gaming gaming = repository.Gamings
            .FirstOrDefault(b => b.GamingID == gamingId);
            myCart.AddItem(gaming, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long gamingId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.Gaming.GamingID == gamingId).Gaming);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}