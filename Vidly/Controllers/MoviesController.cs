using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;
using System . Web . Mvc;
using Vidly . Models;
using Vidly . ViewModels;

namespace Vidly . Controllers
{
    [RoutePrefix ( "movies" )]
    public class MoviesController : Controller
    {
        [Route]
        // GET: Movies
        public ActionResult Random ( )
        {
            var randomMoviewVM = new RandomMovieVM()
            {
                 Movie = new Movie() { Name = "Shrek"  },
                 Customers = new List<Customer>()
                 {
                     new Customer() { Name="Cust 1" },
                     new Customer() { Name="Cust 2" },
                 }
            };
            return View ( randomMoviewVM );
        }

        [Route ( "released/{year:int:regex(\\d{4})}/{month:int:regex(\\d{2}):range(1,12)}" )]
        public ActionResult ByReleaseDate ( int month , int year )
        {
            return Content ( month + "/" + year );
        }
    }
}