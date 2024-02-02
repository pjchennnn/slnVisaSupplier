using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prjVisaSupplier.Models;

namespace prjVisaSupplier.Controllers
{
    public class TVordersController : Controller
    {
        private readonly dbTravalPlatformContext _context;

        public TVordersController(dbTravalPlatformContext context)
        {
            _context = context;
        }

        // GET: TVorders
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> IndexOld()
        {
            var dbTravalPlatformContext = _context.TVorders;
            return View(await dbTravalPlatformContext.ToListAsync());
        }

        [Route("/TVorders/IndexJson")]
        public JsonResult IndexJson()
        {
            var VOrders = _context.TVorders
                                            .Include(t => t.FCoupon)
                                            .Include(t => t.FCustomer)
                                            .Include(t => t.FProduct)
                                            .Include(t => t.FStatus)
                                            .Select(t => new
                                            {
                                                fOrderId = t.FOrderId,
                                                fProductName = t.FProduct.FName,
                                                fCustomerName = t.FCustomer.FName,
                                                fPrice = t.FProduct.FPrice,
                                                fQuantity = t.FQuantity,
                                                fDepartureDate = t.FDepartureDate,
                                                fInterviewRequirement = t.FProduct.FInterviewRequirement,
                                                fEntityOrElectric = t.FProduct.FEntityOrElectronic,
                                                fForPickupOrDeliveryAddress = t.FForPickupOrDeliveryAddress,
                                                fInterviewReminder = t.FInterviewReminder,
                                                fEvaluate = t.FEvaluate,
                                                fCoupon = t.FCoupon.FCouponName,
                                                fTotal = t.FProduct.FPrice * t.FQuantity - t.FCoupon.FDiscount,
                                                fMemo = t.FMemo,
                                                fStatus = t.FStatus.FVorderStatus

                                            });
            //var VOrders = from o in _context.TVorders
            //              join co in _context.TCouponLists on o.FCouponId equals co.FCouponId
            //              join cu in _context.TCustomers on o.FCustomerId equals cu.FCustomerId
            //              join p in _context.TVproducts on o.FProductId equals p.FId
            //              join st in _context.TVorderStatuses on o.FStatusId equals st.FId
            //              select new
            //              {
            //                  fOrderId = o.FOrderId,
            //                  fProductName = p.FName,
            //                  fCustomerName = cu.FName,
            //                  fPrice = p.FPrice,
            //                  fQuantity = o.FQuantity,
            //                  fDepartureDate = o.FDepartureDate,
            //                  fInterviewRequirement = p.FInterviewRequirement,
            //                  fEntityOrElectric = p.FEntityOrElectronic,
            //                  fForPickupOrDeliveryAddress = o.FForPickupOrDeliveryAddress,
            //                  fInterviewReminder = o.FInterviewReminder,
            //                  fEvaluate = o.FEvaluate,
            //                  fCoupon = co.FCouponName,
            //                  fTotal = p.FPrice * o.FQuantity - co.FDiscount,
            //                  fMemo = o.FMemo,
            //                  fStatus = st.FVorderStatus
            //              };
            return Json(VOrders);
        }


        // GET: TVorders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TVorders == null)
            {
                return NotFound();
            }

            var tVorder = await _context.TVorders
                .Include(t => t.FCoupon)
                .Include(t => t.FCustomer)
                .Include(t => t.FProduct)
                .Include(t => t.FStatus)
                .FirstOrDefaultAsync(m => m.FId == id);
            if (tVorder == null)
            {
                return NotFound();
            }

            return View(tVorder);
        }

        // GET: TVorders/Create
        public IActionResult Create()
        {
            ViewData["FCouponId"] = new SelectList(_context.TCouponLists, "FCouponId", "FCouponName");
            ViewData["FCustomerId"] = new SelectList(_context.TCustomers, "FCustomerId", "FName");
            ViewData["FProductId"] = new SelectList(_context.TVproducts, "FId", "FName");
            ViewData["FStatusId"] = new SelectList(_context.TVorderStatuses, "FId", "FVorderStatus");
            return View();
        }

        // POST: TVorders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FId,FOrderId,FProductId,FCustomerId,FPrice,FQuantity,FDepartureDate,FForPickupOrDeliveryAddress,FInterviewReminder,FEvaluate,FMemo,FStatusId,FCouponId")] TVorder tVorder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tVorder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FCouponId"] = new SelectList(_context.TCouponLists, "FCouponId", "FCouponId", tVorder.FCouponId);
            ViewData["FCustomerId"] = new SelectList(_context.TCustomers, "FCustomerId", "FCustomerId", tVorder.FCustomerId);
            ViewData["FProductId"] = new SelectList(_context.TVproducts, "FId", "FName", tVorder.FProductId);
            ViewData["FStatusId"] = new SelectList(_context.TVorderStatuses, "FId", "FId", tVorder.FStatusId);
            return View(tVorder);
        }

        // GET: TVorders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TVorders == null)
            {
                return NotFound();
            }

            var tVorder = await _context.TVorders.FindAsync(id);
            if (tVorder == null)
            {
                return NotFound();
            }
            ViewData["FCouponId"] = new SelectList(_context.TCouponLists, "FCouponId", "FCouponId", tVorder.FCouponId);
            ViewData["FCustomerId"] = new SelectList(_context.TCustomers, "FCustomerId", "FCustomerId", tVorder.FCustomerId);
            ViewData["FProductId"] = new SelectList(_context.TVproducts, "FId", "FName", tVorder.FProductId);
            ViewData["FStatusId"] = new SelectList(_context.TVorderStatuses, "FId", "FId", tVorder.FStatusId);
            return View(tVorder);
        }

        // POST: TVorders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FId,FOrderId,FProductId,FCustomerId,FPrice,FQuantity,FDepartureDate,FForPickupOrDeliveryAddress,FInterviewReminder,FEvaluate,FMemo,FStatusId,FCouponId")] TVorder tVorder)
        {
            if (id != tVorder.FId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tVorder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVorderExists(tVorder.FId))
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
            ViewData["FCouponId"] = new SelectList(_context.TCouponLists, "FCouponId", "FCouponId", tVorder.FCouponId);
            ViewData["FCustomerId"] = new SelectList(_context.TCustomers, "FCustomerId", "FCustomerId", tVorder.FCustomerId);
            ViewData["FProductId"] = new SelectList(_context.TVproducts, "FId", "FName", tVorder.FProductId);
            ViewData["FStatusId"] = new SelectList(_context.TVorderStatuses, "FId", "FId", tVorder.FStatusId);
            return View(tVorder);
        }

        // GET: TVorders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TVorders == null)
            {
                return NotFound();
            }

            var tVorder = await _context.TVorders
                .Include(t => t.FCoupon)
                .Include(t => t.FCustomer)
                .Include(t => t.FProduct)
                .Include(t => t.FStatus)
                .FirstOrDefaultAsync(m => m.FId == id);
            if (tVorder == null)
            {
                return NotFound();
            }

            return View(tVorder);
        }

        // POST: TVorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TVorders == null)
            {
                return Problem("Entity set 'dbTravalPlatformContext.TVorders'  is null.");
            }
            var tVorder = await _context.TVorders.FindAsync(id);
            if (tVorder != null)
            {
                _context.TVorders.Remove(tVorder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVorderExists(int id)
        {
          return (_context.TVorders?.Any(e => e.FId == id)).GetValueOrDefault();
        }
    }
}
