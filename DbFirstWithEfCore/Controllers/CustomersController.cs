using DbFirstWithEfCore.Data;
using DbFirstWithEfCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstWithEfCore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly NikitaContext _context;

        public CustomersController()
        {
            _context = new NikitaContext();
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            List<Customer> customers = _context.Customers.ToList();
            return View(customers);
        }
        public ActionResult CreateOrEdit( int customerId)
        {
             Customer customer =  GetDeatils(customerId);
            return View(customer);
        }

        // GET: CustomersController/Details/5
        public Customer GetDeatils(int customerId)
        {
            Customer customer = _context.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
            return customer;

        }

        public ActionResult Details(int customerId)
        {
            Customer customer = GetDeatils(customerId);

            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Save(Customer customer)
        {
            if(customer == null)
                return BadRequest();
            if(customer.CustomerId == 0)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            else
            {
                Edit(customer);
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: CustomersController/Edit/5
        public ActionResult Edit(Customer customer)
        {
            Customer customerInDb = GetDeatils(customer.CustomerId);
            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName;
            customerInDb.Email = customer.Email;
            customerInDb.Phone = customer.Phone;
            customerInDb.Gender = customer.Gender;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteDetails(int customerId)
        {
            Customer customer = GetDeatils(customerId);

            return View(customer);
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = GetDeatils(id);
            _context.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
