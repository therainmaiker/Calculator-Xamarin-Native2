using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reservation_V4.Data;
using Reservation_V4.Models;

namespace Reservation_V4.Controllers
{
    public class ReservationTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly RoleManager<IdentityRole> _roleManager;

        public ReservationTypeController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        // GET: ReservationTypeController
        
        public async Task<ActionResult>  Index()
        {
            var allTypes = await _context.ReservationTypes.ToListAsync();
            return View(allTypes);
        }

        // GET: ReservationTypeController/Details/5
        //public ActionResult Details(int id)
        //{
            
        //    return View();
        //}

        // GET: ReservationTypeController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ReservationTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create([Bind("ReservationName,AccessNumber")] ReservationType reservationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationType);
        }

        // GET: ReservationTypeController/Edit/5
        public  ActionResult Edit(int? id)
        {
            var reservation =  _context.ReservationTypes.Find(id);
            
            return View(reservation);
        }

        // POST: ReservationTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id , ReservationType reservationType )
        {
            

            if (ModelState.IsValid)
            {
                
                    _context.Update(reservationType);
                    await _context.SaveChangesAsync();
                
               
                return RedirectToAction(nameof(Index));
            }
            return View(reservationType);
        }

        // GET: ReservationTypeController/Delete/5
        
        public ActionResult Delete(int id , ReservationType reservationType)
        {
            

            var reservation = _context.ReservationTypes.Find(id);
            

            return View(reservation);
        }

        // POST: ReservationTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var reservations = await _context.ReservationTypes.FindAsync(id);
            _context.ReservationTypes.Remove(reservations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
