using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        //[Route("home-page", Name = "homeRoute")]
        public ViewResult Index()
        {
            Title = "Home | BookStore";
            return View();
        }

        [Route("about-us", Name = "aboutUsRoute")]
        public ViewResult AboutUs() 
        {
            Title = "AboutUs | BookStore";
            return View();
        }

        [Route("contact-us", Name = "contactUsRoute")]
        public ViewResult ContactUs()
        {
            Title = "ContactUs | BookStore";
            return View();
        }
        
    }
}
