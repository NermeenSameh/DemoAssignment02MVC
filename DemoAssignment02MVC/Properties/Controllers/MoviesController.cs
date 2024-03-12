using Microsoft.AspNetCore.Mvc;

namespace DemoAssignment02MVC.Properties.Controllers
{
    public class MoviesController : Controller
    {
        // Action : Public Non-Static Object Member Function
        public string GetMovie(int id)
        {
            return $"Movie With Id: {id}";
        }

        public string Index()
        {
            return "All Movies";
        }

    }
}
