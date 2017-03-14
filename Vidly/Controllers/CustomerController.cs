using System . Collections . Generic;
using System . Linq;
using System . Web . Mvc;
using Vidly . Models;
using Vidly . ViewModels;

namespace Vidly . Controllers
{
    [RoutePrefix ( "customer" )]
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
        [HttpGet]
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

        [Route ( "edit/{Id:int}" )]
        [HttpGet]
        public ActionResult Details ( int id )
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var customer  = _context.Customers.Where(x=> x.Id == id).Select(y=> new CustomerViewModel()
            {
                Id = y.Id,
                IsSubscribedToNewsLetter = y.IsSubscribedToNewsLetter,
                MembershipTypeId=y.MembershipTypeId,
                Name = y.Name,
                BirthDate = y.BirthDate
            } ).FirstOrDefault();

            customer . MembershipTypes = membershipTypes;

            if ( customer == null )
                return HttpNotFound ( );
            else
                return View ("Create",customer );

        }

        [HttpGet]
        [Route ( "create" )]
        public ActionResult Create ( )
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customerVM = new CustomerViewModel { MembershipTypes = membershipTypes };
            return View ( customerVM );
        }

        [HttpPost]
        [Route ( "create" )]
        public ActionResult Save ( CustomerViewModel customerVM )
        {
            if ( ModelState . IsValid )
            {
                Customer customerEntity = null;
               

                if ( customerVM . Id != 0 )
                {
                    var customer  = _context.Customers.FirstOrDefault(x=> x.Id == customerVM.Id);
                    customer . Name = customerVM . Name;
                    customer . MembershipTypeId = customerVM . MembershipTypeId;
                    customer . BirthDate = customerVM . BirthDate;
                    customer . IsSubscribedToNewsLetter = customerVM . IsSubscribedToNewsLetter;
                }
                else
                {
                    customerEntity = new Customer ( )
                    {
                        Name = customerVM . Name ,
                        BirthDate = customerVM . BirthDate ,
                        MembershipTypeId = customerVM . MembershipTypeId ,
                        IsSubscribedToNewsLetter = customerVM . IsSubscribedToNewsLetter
                    };
                    _context . Customers . Add ( customerEntity );
                }

                
                _context . SaveChanges ( );

               
            }
            return RedirectToAction ( "Index" );
        }
    }
}