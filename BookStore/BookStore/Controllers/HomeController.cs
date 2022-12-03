using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        public ViewResult Index()
        {
            Title = "Home | BookStore";
            return View();
        }

        public ViewResult AboutUs() 
        {
            Title = "AboutUs | BookStore";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "ContactUs | BookStore";
            return View();
        }
        
    }
}
