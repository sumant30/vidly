using System;
using System . Collections . Generic;
using System . Linq;
using System . Web;
using System . Web . Mvc;
using System . Web . Mvc;
using Vidly . Models;
using Vidly . ViewModels;

namespace Vidly . Controllers
{
    [RoutePrefix ( "Customer" )]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController ( )
        {
            _context = new ApplicationDbContext ( );
        }

        protected override void Dispose ( bool disposing )
        {
            _context . Dispose ( );
        }

        [Route]
        // GET: Customer
        public ActionResult Index ( )
        {
            List<CustomerViewModel> lstCustomers  =
            _context.Customers.Select(x=> new CustomerViewModel()
            {
                Id = x.Id,
                IsSubscribedToNewsLetter = x.IsSubscribedToNewsLetter,
                MembershipType = x.MembershipType,
                Name = x.Name
            } ).ToList();
            return View ( lstCustomers );
        }

        [Route ( "details/{Id:int}" )]
        public ActionResult Details ( int id )
        {
            var customer  = _context.Customers.Where(x=> x.Id == id).Select(y=> new CustomerViewModel()
            {
                Id = y.Id,
                IsSubscribedToNewsLetter = y.IsSubscribedToNewsLetter,
                MembershipType = y.MembershipType,
                Name = y.Name
            } );

            if ( customer == null )
                return HttpNotFound ( );
            else
                return View ( customer );

        }
    }
}