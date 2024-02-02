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
    public class TVproductsController : Controller
    {
        private readonly dbTravalPlatformContext _context;

        public TVproductsController(dbTravalPlatformContext context)
        {
            _context = context;
        }

        // GET: TVproducts
        public async Task<IActionResult> Index()
        {
            var dbTravalPlatformContext = _context.TVproducts.Include(t => t.FCountry).Include(t => t.FLengthOfStay).Include(t => t.FProcessingTime).Include(t => t.FSupplier).Include(t => t.FValidityPeriod);
            return View(await dbTravalPlatformContext.ToListAsync());
        }

        public IActionResult Earth()
        {
            return View();
        }


        public JsonResult IndexJson()
        {
            var VProducts = _context.TVproducts
                                .Include(t => t.FCountry)
                                .Include(t => t.FLengthOfStay)
                                .Include(t => t.FProcessingTime)
                                .Include(t => t.FSupplier)
                                .Include(t => t.FValidityPeriod)
                                .Select(t => new
                                {
                                    fName = t.FName,
                                    fSuppiler = t.FSupplier.FCompanyName,
                                    fRegion = t.FCountry.FRegion,
                                    fCountry = t.FCountry.FCountry,
                                    fNewOrLost = t.FNewOrLost,
                                    fInterviewRequirement = t.FInterviewRequirement,
                                    fEntityOrElectronic = t.FEntityOrElectronic,
                                    fProcessingTime = t.FProcessingTime.FProcessingTime,
                                    fValidityPeriod = t.FValidityPeriod.FValidityPeriod,
                                    fLengthOfStayId = t.FLengthOfStay.FLengthOfStay,
                                    fPrice = t.FPrice,
                                    fEnabled = t.FEnabled
                                });

            return Json(VProducts);
        }

        // GET: TVproducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TVproducts == null)
            {
                return NotFound();
            }

            var tVproduct = await _context.TVproducts
                .Include(t => t.FCountry)
                .Include(t => t.FLengthOfStay)
                .Include(t => t.FProcessingTime)
                .Include(t => t.FSupplier)
                .Include(t => t.FValidityPeriod)
                .FirstOrDefaultAsync(m => m.FId == id);
            if (tVproduct == null)
            {
                return NotFound();
            }

            return View(tVproduct);
        }

        // GET: TVproducts/Create
        public IActionResult Create()
        {
            ViewData["FCountryId"] = new SelectList(_context.TVcountries, "FId", "FCountry");
            ViewData["FLengthOfStayId"] = new SelectList(_context.TVlengthOfStays, "FId", "FLengthOfStay");
            ViewData["FProcessingTimeId"] = new SelectList(_context.TVprocessingTimes, "FId", "FId");
            ViewData["FSupplierId"] = new SelectList(_context.TCcompanyInfos, "FId", "FId");
            ViewData["FValidityPeriodId"] = new SelectList(_context.TVvalidityPeriods, "FId", "FValidityPeriod");
            return View();
        }

        // POST: TVproducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FId,FCountryId,FSupplierId,FName,FNewOrLost,FInterviewRequirement,FEntityOrElectronic,FProcessingTimeId,FValidityPeriodId,FLengthOfStayId,FPrice,FEnabled")] TVproduct tVproduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tVproduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FCountryId"] = new SelectList(_context.TVcountries, "FId", "FCountry", tVproduct.FCountryId);
            ViewData["FLengthOfStayId"] = new SelectList(_context.TVlengthOfStays, "FId", "FLengthOfStay", tVproduct.FLengthOfStayId);
            ViewData["FProcessingTimeId"] = new SelectList(_context.TVprocessingTimes, "FId", "FId", tVproduct.FProcessingTimeId);
            ViewData["FSupplierId"] = new SelectList(_context.TCcompanyInfos, "FId", "FId", tVproduct.FSupplierId);
            ViewData["FValidityPeriodId"] = new SelectList(_context.TVvalidityPeriods, "FId", "FValidityPeriod", tVproduct.FValidityPeriodId);
            return View(tVproduct);
        }

        // GET: TVproducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TVproducts == null)
            {
                return NotFound();
            }

            var tVproduct = await _context.TVproducts.FindAsync(id);
            if (tVproduct == null)
            {
                return NotFound();
            }
            ViewData["FCountryId"] = new SelectList(_context.TVcountries, "FId", "FCountry", tVproduct.FCountryId);
            ViewData["FLengthOfStayId"] = new SelectList(_context.TVlengthOfStays, "FId", "FLengthOfStay", tVproduct.FLengthOfStayId);
            ViewData["FProcessingTimeId"] = new SelectList(_context.TVprocessingTimes, "FId", "FId", tVproduct.FProcessingTimeId);
            ViewData["FSupplierId"] = new SelectList(_context.TCcompanyInfos, "FId", "FId", tVproduct.FSupplierId);
            ViewData["FValidityPeriodId"] = new SelectList(_context.TVvalidityPeriods, "FId", "FValidityPeriod", tVproduct.FValidityPeriodId);
            return View(tVproduct);
        }

        // POST: TVproducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FId,FCountryId,FSupplierId,FName,FNewOrLost,FInterviewRequirement,FEntityOrElectronic,FProcessingTimeId,FValidityPeriodId,FLengthOfStayId,FPrice,FEnabled")] TVproduct tVproduct)
        {
            if (id != tVproduct.FId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tVproduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVproductExists(tVproduct.FId))
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
            ViewData["FCountryId"] = new SelectList(_context.TVcountries, "FId", "FCountry", tVproduct.FCountryId);
            ViewData["FLengthOfStayId"] = new SelectList(_context.TVlengthOfStays, "FId", "FLengthOfStay", tVproduct.FLengthOfStayId);
            ViewData["FProcessingTimeId"] = new SelectList(_context.TVprocessingTimes, "FId", "FId", tVproduct.FProcessingTimeId);
            ViewData["FSupplierId"] = new SelectList(_context.TCcompanyInfos, "FId", "FId", tVproduct.FSupplierId);
            ViewData["FValidityPeriodId"] = new SelectList(_context.TVvalidityPeriods, "FId", "FValidityPeriod", tVproduct.FValidityPeriodId);
            return View(tVproduct);
        }

        // GET: TVproducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TVproducts == null)
            {
                return NotFound();
            }

            var tVproduct = await _context.TVproducts
                .Include(t => t.FCountry)
                .Include(t => t.FLengthOfStay)
                .Include(t => t.FProcessingTime)
                .Include(t => t.FSupplier)
                .Include(t => t.FValidityPeriod)
                .FirstOrDefaultAsync(m => m.FId == id);
            if (tVproduct == null)
            {
                return NotFound();
            }

            return View(tVproduct);
        }

        // POST: TVproducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TVproducts == null)
            {
                return Problem("Entity set 'dbTravalPlatformContext.TVproducts'  is null.");
            }
            var tVproduct = await _context.TVproducts.FindAsync(id);
            if (tVproduct != null)
            {
                _context.TVproducts.Remove(tVproduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVproductExists(int id)
        {
          return (_context.TVproducts?.Any(e => e.FId == id)).GetValueOrDefault();
        }
    }
}
