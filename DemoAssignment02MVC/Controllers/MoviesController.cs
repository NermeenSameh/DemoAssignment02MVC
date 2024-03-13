using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DemoAssignment02MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IConfiguration _configuration;

        public MoviesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Action : Public Non-Static Object Member Function

        // [AcceptVerbs("GET" , "POST")]
        // [HttpPost]
        public IActionResult GetMovie(int id)
        {
            if (id < 10)
                // return new BadRequestResult();
                return BadRequest();
            if (id == 100)
                // return new NotFoundResult();
                return NotFound();
            return new BadRequestResult();
            if (id == 100)
                return new NotFoundResult();

            ///   ContentResult result = new ContentResult();
            ///   result.Content = $"Movie With Id: {id}";
            ///   result.ContentType = "text/html";
            ///   result.StatusCode = 404;
            ///   return result;
            ///  

            //  return Content($"Movie With Id: {id}");
            return Content($"Movie With Id: {id}", "text/html");

        }



        /// public ContentResult GetMovie(int id)
        /// {
        ///     ContentResult result = new ContentResult();
        ///     result.Content = $"Movie With Id: {id}";
        ///     result.ContentType = "text/html";
        ///     // result.ContentType = "object/pdf";
        ///     result.StatusCode = 404;
        ///     return result;
        /// }


        /// [ActionName("Index")]
        /// public string GetAllMovies()
        /// {
        ///     return "All Movies";
        /// }

        public IActionResult Hamda()
        {
            RedirectResult redirectResult = new RedirectResult($"{_configuration["BaseUrl"]}/Movies/GetMovie/11");

            // return Redirect($"{_configuration["BaseUrl"]}/Movies/GetMovie/11");

            RedirectToActionResult redirectToActionResult = new RedirectToActionResult(nameof(GetMovie), nameof(MoviesController), new { id = 11 });

            // return RedirectToAction(nameof(MoviesController.GetMovie), nameof(MoviesController), new { id = 11 });
            RedirectToActionResult redirectToActionResult2 = new RedirectToActionResult(nameof(GetMovie), nameof(MoviesController), new { id = 11 });

            RedirectToRouteResult redirectToRouteResult = new RedirectToRouteResult("Default", new { controller = nameof(MoviesController), action = nameof(GetMovie), id = 11 });

            RedirectToRouteResult redirectToRouteResult01 = new RedirectToRouteResult("Default");


            return redirectToRouteResult;
        }

    }
}
