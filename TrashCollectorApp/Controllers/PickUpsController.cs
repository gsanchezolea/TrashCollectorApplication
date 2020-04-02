using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorApp.Data;
using TrashCollectorApp.Models;

namespace TrashCollectorApp.Controllers
{
    public class PickUpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PickUpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PickUps
        public async Task<IActionResult> Index()
        {
        
            var applicationDbContext = _context.PickUps.Include(p => p.Choice).Include(p => p.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PickUps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickUp = await _context.PickUps
                .Include(p => p.Choice)
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickUp == null)
            {
                return NotFound();
            }
            var customer = _context.Customers.Where(c => c.Id == pickUp.CustomerId).SingleOrDefault();
            if (customer.AccountIsActive == false)
            {
                return RedirectToAction("Dashboard", "Customers");
            }
            return View(pickUp);
        }

        // GET: PickUps/Create
        public IActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
             if (customer.AccountIsActive == false)
            {
                return RedirectToAction("Dashboard", "Customers");
            }
            var pickUp = new PickUp();
            var choices = _context.Choices.ToList();
            ViewBag.Choices = new SelectList(choices, "Id", "Type");
            return View(pickUp);
        }

        // POST: PickUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PickUp pickUp)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                pickUp.CustomerId = customer.Id;

                if (pickUp.ChoiceId == 1)
                {

                    var endDate = customer.EndDate; //Last pickup day
                    var scheduledDate = pickUp.Date;

                    //Temporary List to keep track of dates locally
                    List<PickUp> pickUps = new List<PickUp>();

                    for (var i = scheduledDate; i < endDate; i = i.AddDays(7))
                    {
                        PickUp newPickUp = new PickUp()
                        {
                            CustomerId = pickUp.CustomerId,
                            ChoiceId = pickUp.ChoiceId,
                            Date = i
                        };
                        await _context.AddAsync(newPickUp);
                        pickUps.Add(pickUp);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Dashboard", "Customers");
                }
                else if (pickUp.ChoiceId == 2)
                {
                    _context.Add(pickUp);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Dashboard", "Customers");
                }

            }
            ViewData["ChoiceId"] = new SelectList(_context.Choices, "Id", "Type", pickUp.ChoiceId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", pickUp.CustomerId);
            return View(pickUp);
        }

        // GET: PickUps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickUp = await _context.PickUps.FindAsync(id);
            if (pickUp == null)
            {
                return NotFound();
            }
            var customer = _context.Customers.Where(c => c.Id == pickUp.CustomerId).SingleOrDefault();
            if (customer.AccountIsActive == false)
            {
                return RedirectToAction("Dashboard", "Customers");
            }
            ViewData["ChoiceId"] = new SelectList(_context.Choices, "Id", "Type", pickUp.ChoiceId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", pickUp.CustomerId);
            return View(pickUp);
        }

        // POST: PickUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,ChoiceId,Date,Confirmed")] PickUp pickUp)
        {
            if (id != pickUp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pickUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PickUpExists(pickUp.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Dashboard", "Customers");
            }
            ViewData["ChoiceId"] = new SelectList(_context.Choices, "Id", "Type", pickUp.ChoiceId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", pickUp.CustomerId);
            return View(pickUp);
        }

        // GET: PickUps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickUp = await _context.PickUps
                .Include(p => p.Choice)
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickUp == null)
            {
                return NotFound();
            }
            var customer = _context.Customers.Where(c => c.Id == pickUp.CustomerId).SingleOrDefault();
            if (customer.AccountIsActive == false)
            {
                return RedirectToAction("Dashboard", "Customers");
            }

            return View(pickUp);
        }

        // POST: PickUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pickUp = await _context.PickUps.FindAsync(id);
            _context.PickUps.Remove(pickUp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Customers");
        }

        private bool PickUpExists(int id)
        {
            return _context.PickUps.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Confirm(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var pickUp = _context.PickUps
                .Include(p => p.Choice)
                .Include(p => p.Customer)
                .ThenInclude(p => p.Address)
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if(pickUp.Confirmed == true)
            {
                return RedirectToAction("Dashboard", "Employees");
            }

            var customer = _context.Customers
                .Where(c => c.Id == pickUp.CustomerId)
                .SingleOrDefault();

            pickUp.Confirmed = true;
            customer.Balance += 29.99;
            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Employees");
        }
    }
}
