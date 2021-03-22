using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservation_V4.Data;
using Reservation_V4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation_V4.Controllers
{
    public class ReservationController : Controller
    {
        private ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        private RoleManager<IdentityRole> _roleManager;

        public ReservationController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: ReservationController

        [Authorize(Roles = "Student,Admin")]
        public async Task<ActionResult> Index()
        {
            var jointuretables = await _context.Reservations
              .Include(x => x.ReservationType)
              .ToListAsync();

            return View(jointuretables.OrderByDescending(c => c.Date));
        }

        //[Authorize(Roles = "Admin")]
        //public async Task<ActionResult> Index()
        //{
        //    var jointuretables = await _context.Reservations
        //      .Include(x => x.ReservationType)
        //      .ToListAsync();

        //    return View(jointuretables.OrderByDescending(c => c.Date));

        //}

        //public IActionResult InsertModelView(ReservStudentViewModel model)
        //{
        //    Guid UserID = new Guid();
        //    Reservation reservation = new Reservation()
        //    {
        //        Date = model.Date,
        //        Status = model.Status,
        //        Cause = model.Cause

        //    };

        //    ReservationType type = new ReservationType() { ReservationName = model.ReservationName };

        //    var usId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    reservation.Id = Convert.ToInt32(usId);
        //    reservation.ReservationType = type;
        //    _context.Reservations.Add(reservation);
        //     _context.SaveChangesAsync();

        //    return View();

        //}

        // GET: ReservationController/Create

        public ActionResult Create(ContactStatus status)
        {
            var filterby = _context.Reservations.OrderBy(r => r.Date);

            List<ReservationType> reservationTypes = _context.ReservationTypes.ToList();
            ViewBag.reservatiolist = new SelectList(reservationTypes, "Id", "ReservationName");

            ViewBag.getuserid = _userManager.GetUserId(HttpContext.User);
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            //  var query = _context.Reservations.FromSqlRaw("INSERT INTO reservations (ID,Date,Status,Cause,ReservationTypeId, UserId,ReservationId)VALUES(10, '2021-03-12 12:05:00.000000', 'Status', 'Cause', 2, '1c53fef4-2a86-4257-9f3b-ff08c06ef66a', 3)");

            //// get all users infos
            var userID = await _userManager.GetUserAsync(User);
            //var ResType = _context.ReservationTypes.SingleAsync(x => x.Id == reservation.);

            reservation.UserId = userID.Id;

            //reservation.ReservationTypeId =ResType ;
            //reservation.ReservationTypeId = reservation.ReservationTypeId;

            //var reserve = new Reservation();
            //reserve.Date = reservation.Date;
            //reserve.Cause = reservation.Cause;
            //reserve.Status = reservation.Status;
            //reserve.ReservationTypeId = reservation.ReservationTypeId;

            //reserve.UserId = userID.Id;

            await _context.AddAsync(reservation);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ReservationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var reser = await _context.Reservations.FindAsync(id);
            // send to view

            // get Reservations Type list
            List<ReservationType> reservationTypes = _context.ReservationTypes.ToList();
            ViewBag.reservationlist = new SelectList(reservationTypes, "Id", "ReservationName");

            return View(reser);
        }



       
        public async Task<IActionResult> StatusChanger(int Id , bool Status)
        {
            
           // ContactStatus st = Status == true ? ContactStatus.Approved : ContactStatus.Rejected;
           // var Reservation = await _context.Reservations.FindAsync(Id);
           // Reservation.Status = st;
           // _context.Update(Reservation);
           //await _context.SaveChangesAsync();

           return RedirectToAction(nameof(Index));
            //reservation.Status = reservation.Status == ContactStatus.Approved;



        }
        

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reservation reservation)
        {
            _context.Update(reservation);
            await _context.SaveChangesAsync();

            //get reservation by id
            // user id hidden
            // update object
            return RedirectToAction(nameof(Index));
        }
    }
}