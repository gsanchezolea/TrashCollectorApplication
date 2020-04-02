using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorApp.Data;
using TrashCollectorApp.Models;

namespace TrashCollectorApp.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var pickUp = await _context.PickUps
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync();

            var customer = await _context.Customers
                .Include(c => c.Address)
                .Where(c => c.Id == pickUp.CustomerId)
                .SingleOrDefaultAsync();
            
            return View(customer);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Address)
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            
            if (customer.AccountIsActive == false)
            {
                return RedirectToAction("Dashboard", "Customers");
            }
            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {            
            Customer customer = new Customer();
            customer = _context.Customers.Include(c => c.Address).FirstOrDefault();

            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                customer.AccountIsActive = true;
                customer.StartDate = DateTime.Now;               
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Dashboard));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "City", customer.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .Include(c => c.Address)
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();
            if (customer == null)
            {
                return NotFound();
            }
            if (customer.AccountIsActive == false)
            {
                return RedirectToAction("Dashboard", "Customers");
            }
            
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Customer customer)
        {
            if (id != customer.Id)
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
                    if (!CustomerExists(customer.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "City", customer.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var customer = await _context.Customers
                .Include(c => c.Address)
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Dashboard()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            var listOfPickUps = _context.PickUps
                .Include(c => c.Customer)
                .Include(c => c.Choice)
                .Where(c => c.CustomerId == customer.Id);

            var listOfCustomers = await _context.Customers
                .Include(c => c.IdentityUser)
                .Include(c => c.Address)
                .Where(c => c.IdentityUserId == userId)
                .ToListAsync();

            ViewBag.Customers = listOfCustomers; 
            return View(await listOfPickUps.ToListAsync());
        }

        public async Task<IActionResult> Suspend(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            if(customer.AccountIsActive == false)
            {
                return RedirectToAction("Dashboard", "Customers");
            }
            else
            {
                if(customer.Balance != 0)
                {
                    return RedirectToAction("Dashboard", "Customers");
                }
                else
                {
                    customer.AccountIsActive = false;                
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Dashboard", "Customers");
                }
            }
        }

        public async Task<IActionResult> Resume(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            if (customer.AccountIsActive == true)
            {
                return RedirectToAction("Dashboard", "Customers");
            }
            else
            {
                if (customer.Balance != 0)
                {
                    return RedirectToAction("Dashboard", "Customers");
                }
                else
                {
                    customer.AccountIsActive = true;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Dashboard", "Customers");
                }
            }
        }



    }
}
