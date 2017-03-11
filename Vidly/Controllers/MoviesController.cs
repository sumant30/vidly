using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;
using System . Web . Mvc;
using Vidly . Models;
using Vidly . ViewModels;

namespace Vidly . Controllers
{
    [RoutePrefix ( "Movie" )]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController ( )
        {
            _context = new ApplicationDbContext ( );
        }

        protected override void Dispose ( bool disposing )
        {
            _context . Dispose ( );
        }


        [Route]
        // GET: Movies
        public ActionResult Index ( )
        {
            List<MovieViewModel> lstMovies  =
            _context.Movies.Select(x=> new MovieViewModel()
            {
                Id = x.Id,
                Name=x.Name,
                Genre=x.Genre.ToString()
            } ).ToList();

            return View ( lstMovies );
        }

        [Route ( "details/{Id:int}" )]
        [HttpGet]
        public ActionResult Details ( int id )
        {
            var movie  = _context.Movies.Where(x=> x.Id == id).Select(y=> new MovieViewModel()
            {
                Id = y.Id,
                Genre=y.Genre.ToString(),
                DateAdded = y.DateAdded,
                ReleaseDate=y.ReleaseDate,
                Name = y.Name,
                InStock=y.InStock
            } ).FirstOrDefault();

            if ( movie == null )
                return HttpNotFound ( );
            else
                return View ( movie );

        }

        [Route ( "released/{year:int:regex(\\d{4})}/{month:int:regex(\\d{2}):range(1,12)}" )]
        public ActionResult ByReleaseDate ( int month , int year )
        {
            return Content ( month + "/" + year );
        }
    }
}