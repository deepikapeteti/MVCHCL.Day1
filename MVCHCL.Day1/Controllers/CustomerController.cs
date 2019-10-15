using System;
using static System.Convert;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHCL.Day1.Models;
using MVCHCL.Day1.ViewModel;
using System.Data.Entity;
namespace MVCHCL.Day1.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
       
        private ApplicationDbContext dbContext = null;
        public CustomerController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
           if(disposing)
            {
                dbContext.Dispose();
            }
        }
        // GET: Customer
        [AllowAnonymous]
        public ActionResult Index()
        {
            var customers = dbContext.Customers.Include(m=>m.MembershipType).ToList();
            return View("IndexCustomer",customers);
        }
        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.Include(m => m.MembershipType).ToList().SingleOrDefault(a => a.id == id);
            return View(customer);
        }
        //public List<Customer>GetCustomers()
        //{
        //    List<Customer> customers = new List<Customer>
        //    {
        //        new Customer{id=1,customername="Deepika",BirthDate=Convert.ToDateTime("23/04/1998"),Gender="Female"},
        //        new Customer{id=2,customername="Sravani",BirthDate=Convert.ToDateTime("03/11/2000"),Gender="Female"},
        //        new Customer{id=3,customername="Ramya",BirthDate=Convert.ToDateTime("16/02/1998"),Gender="Female"}
        //    };
        //    return customers;
        //}
        public ActionResult DisplayCustomer()
        {
            //Customer cs = new Customer { customername = "Deepika" };
            //return View(cs);
            CustomerMovieViewModel viewModel = new CustomerMovieViewModel();
            Customer c = new Customer { customername = "deepika" };
            List<Movie> m = new List<Movie>
            {
                new Movie{name="Bahubali 1"},
                new Movie{name="KGF"},
                new Movie{name="Bahubali 2"}
            };
            viewModel.customer = c;
            viewModel.movie = m;
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var customer = new Customer();
            ViewBag.Gender = ListGender();
            ViewBag.MembershipTypeId = ListMember();
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(Customer customerfromview)
        {
            if(!ModelState.IsValid)
            {
                var customer = new Customer();
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeId = ListMember();
                return View(customerfromview);
            }
            // return View();
            dbContext.Customers.Add(customerfromview);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [HttpGet]
        public ActionResult Editcustomer(int id)
        {
            var customer =dbContext.Customers.SingleOrDefault(c=>c.id==id);
            if(customer!=null)
            { 
            ViewBag.Gender = ListGender();
            ViewBag.MembershipTypeId = ListMember();
            return View(customer);
            }
            else
            {
                return Content("No Results Found");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Editcustomer(Customer customerfromview)
        {
            if(ModelState.IsValid)
            {
                var customerindb = dbContext.Customers.FirstOrDefault(c => c.id == customerfromview.id);
                customerindb.customername = customerfromview.customername;
                customerindb.BirthDate = customerfromview.BirthDate;
                customerindb.City = customerfromview.City;
                customerindb.Gender = customerfromview.Gender;
                customerindb.MembershipTypeId = customerfromview.MembershipTypeId;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipTypeId = ListMember();
                return View(customerfromview);
            }
        }
       // [HttpPost]
      
        public ActionResult Deletecustomer(int id)
        {
            var customerdel = dbContext.Customers.SingleOrDefault(c => c.id == id);
            if (customerdel!=null)
            {
                
                dbContext.Customers.Remove(customerdel);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return Content("NO RESULTS :(");
            }
        }
        public List<SelectListItem> ListGender()
        {
           
            var Gender = new List<SelectListItem>
            {
                new SelectListItem{Text="selectgender",Value="0",Disabled=true,Selected=true},
                new SelectListItem{Text="Female"},
                new SelectListItem{Text="Male"},
                new SelectListItem{Text="Others"},
            };
            return Gender;
        }
        public List<SelectListItem> ListMember()
        {
            //var membership = (from m in dbContext.MembershipTypes.AsEnumerable()
            //                  select new SelectListItem
            //                  {
            //                      Text = m.Type,
            //                      Value = m.Id.ToString()
            //                  }).ToList();
            
            var membership = dbContext.MembershipTypes.Select(m => new SelectListItem { Text = m.Type, Value = m.Id.ToString() }).ToList();
            membership.Insert(0, new SelectListItem { Text = "---select-----", Value = "0",Disabled=true,Selected=true });
            return membership;
        }
    }
}