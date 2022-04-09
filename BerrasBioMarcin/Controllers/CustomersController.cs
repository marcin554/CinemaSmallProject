#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BerrasBioMarcin.Data;
using BerrasBioMarcin.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;


namespace BerrasBioMarcin.Controllers
{
    public class CustomersController : Controller
    {
        private readonly BerrasBioMarcinContext _context;

        public CustomersController(BerrasBioMarcinContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("CustomerId,FirstName,LastName,DateOfBirth,Email,PhoneNumber,Password,ConfirmPassword")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (_context)
                {
                    var get_user = _context.Customer.FirstOrDefault(p => p.FirstName == customer.FirstName);
                    if (get_user == null)
                    {
                        customer.Password = AESCryptography.Encrypt(customer.Password);
                        customer.ConfirmPassword = AESCryptography.Encrypt(customer.ConfirmPassword);
                        _context.Customer.Add(customer);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewBag.Message = "This Username already exist" + customer.FirstName;
                        return View();
                    }
                }
                ViewBag.Message = "Successfully registered " + customer.FirstName + " " + customer.LastName;



                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer customer)
        {
            using (_context)
            {

                var get_customer = _context.Customer.Single(p => p.FirstName == customer.FirstName
                && p.Password == customer.Password);
                if (get_customer != null)
                {
                    HttpContext.Session.SetString("CustomerId", get_customer.CustomerId.ToString());
                    HttpContext.Session.SetString("CustomerName", get_customer.FirstName.ToString());
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password does not match.");
                }
                return View();
            }
        }

        public ActionResult LoggedIn()
        {
            object obj = HttpContext.Session.Get("CustomerId");
            if (obj != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,DateOfBirth,Email,PhoneNumber,Password,ConfirmPassword")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }
    }
}
