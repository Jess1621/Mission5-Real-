using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System.Linq;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {

        //Private variable to pass in data from the form
        private MovieApplicationContext _movieContext { get; set; }

        //Constructor

        public HomeController(MovieApplicationContext movieUpdate)
        {
            _movieContext = movieUpdate;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Podcasts Page Controller
        public IActionResult MyPodcasts()
        {
            return View();
        }

        //Movie Form Controller
        [HttpGet]
        public IActionResult MovieApplication()
        {
            ViewBag.Categorys = _movieContext.Categorys.ToList();

            return View();
        }

        //On Form Submission
        [HttpPost]
        public IActionResult MovieApplication(ApplicationResponse ar)
        {
            // Using an if else statement to validate form submission before adding data to SQLite Database
            if (ModelState.IsValid)
            {
                // Make an entry in the database
                _movieContext.Add(ar);
                _movieContext.SaveChanges();
                ViewBag.Categorys = _movieContext.Categorys.ToList();
                //Return Page with a confirmation Message
                ViewBag.success = "Record Inserted Successfully!";
                return View(ar);
            }
            
            else
                //Will pass in an error message
                ViewBag.fail = "There was an error with your form submission. Please Try Again.";
                //Needs to pass back in the Category List if validation fails
                ViewBag.Categorys = _movieContext.Categorys.ToList();
                return View(ar);
        }

        // Movie List Controller
        [HttpGet]
        public IActionResult MovieList()
        {
            // Get the responses from the Responses Table and pass it into the view through a variable.
            var applications = _movieContext.Responses
                // "x" can be anything you want.
                .Include(x => x.Category)
                .OrderBy(x => x.Year)
                .ToList();

            return View(applications);
        }

        //Edit Database Controller
        [HttpGet]
        public IActionResult EditMovie (int applicationid)
        {
            ViewBag.Categorys = _movieContext.Categorys.ToList();
            //Will pass in the Data for the Movie Selected
            var application = _movieContext.Responses.Single(x => x.ApplicationID == applicationid);

            return View("MovieApplication", application);
        }

        [HttpPost]
        public IActionResult EditMovie (ApplicationResponse UpdateResponse)
        {
            _movieContext.Update(UpdateResponse);
            _movieContext.SaveChanges();

            //Once changes are saved it will send them back to the Movie List Page
            return RedirectToAction("MovieList");
        }
        
        //Delete Movie Controller
        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var application = _movieContext.Responses.Single(x => x.ApplicationID == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete (ApplicationResponse DeleteResponse)
        {
            //This will remove the Movie from the database
            _movieContext.Responses.Remove(DeleteResponse);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
