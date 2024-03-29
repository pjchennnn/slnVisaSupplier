﻿using System;
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


        public IActionResult amchart3()
        {
            var 亞洲 = _context.TVcountries.Where(t => t.FRegion == "亞洲").ToList();
            var 北美洲 = _context.TVcountries.Where(t => t.FRegion == "北美洲").ToList();
            var 中南美洲 = _context.TVcountries.Where(t => t.FRegion == "中南美洲").ToList();
            var 歐洲 = _context.TVcountries.Where(t => t.FRegion == "歐洲").ToList();
            var 非洲 = _context.TVcountries.Where(t => t.FRegion == "非洲").ToList();
            var 大洋洲 = _context.TVcountries.Where(t => t.FRegion == "大洋洲").ToList();
            ViewBag.亞洲 = 亞洲;
            ViewBag.北美洲 = 北美洲;
            ViewBag.中南美洲 = 中南美洲;
            ViewBag.歐洲 = 歐洲;
            ViewBag.非洲 = 非洲;
            ViewBag.大洋洲 = 大洋洲;
            return View();
        }

        public IActionResult countries()
        {
            var countries = _context.TVcountries.ToList();
            if (countries != null)
            {
                return Json(countries);
            }
            return Json(null);
        }

        public JsonResult VVProduct()
        {
            var VVProduct = _context.VVproductViews;
            return Json(VVProduct);
        }
        
        public JsonResult VVProductByCountry(string country)
        {
            var VVProductByCountry = _context.VVproductViews.Where(c => c.國家 ==  country);
            return Json(VVProductByCountry);
        }
        
        public JsonResult VVProductEnabled()
        {
            var VVProductEnabled = _context.VVproductViews.Where(e => e.啟用狀態 == true);
            return Json(VVProductEnabled);
        }

        public JsonResult VProductsAll()
        {
            var VProductsAll = _context.TVproducts
                                .Include(t => t.FCountry)
                                .Include(t => t.FLengthOfStay)
                                .Include(t => t.FProcessingTime)
                                .Include(t => t.FSupplier)
                                .Include(t => t.FValidityPeriod)
                                .Select(t => new
                                {
                                    fName = t.FName,
                                    fSupplier = t.FSupplier.FCompanyName,
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

            return Json(VProductsAll);
        }

        public JsonResult VProductsEnabled()
        {
            var VProductsEnabled = _context.TVproducts
                                .Include(t => t.FCountry)
                                .Include(t => t.FLengthOfStay)
                                .Include(t => t.FProcessingTime)
                                .Include(t => t.FSupplier)
                                .Include(t => t.FValidityPeriod)
                                .Where(t => t.FEnabled == true)
                                .Select(t => new
                                {
                                    fName = t.FName,
                                    fSupplier = t.FSupplier.FCompanyName,
                                    fRegion = t.FCountry.FRegion,
                                    fCountry = t.FCountry.FCountry,
                                    fNewOrLost = t.FNewOrLost,
                                    fInterviewRequirement = t.FInterviewRequirement,
                                    fEntityOrElectronic = t.FEntityOrElectronic,
                                    fProcessingTime = t.FProcessingTime.FProcessingTime,
                                    fValidityPeriod = t.FValidityPeriod.FValidityPeriod,
                                    fLengthOfStayId = t.FLengthOfStay.FLengthOfStay,
                                    fPrice = t.FPrice
                                });

            return Json(VProductsEnabled);
        }

        public JsonResult VProductsBySupplier(string company)
        {
            var VProductsBySupplier = _context.TVproducts
                                .Include(t => t.FCountry)
                                .Include(t => t.FLengthOfStay)
                                .Include(t => t.FProcessingTime)
                                .Include(t => t.FSupplier)
                                .Include(t => t.FValidityPeriod)
                                .Where(t => t.FSupplier.FCompanyName == company)
                                .Select(t => new
                                {
                                    fName = t.FName,
                                    fSupplier = t.FSupplier.FCompanyName,
                                    fRegion = t.FCountry.FRegion,
                                    fCountry = t.FCountry.FCountry,
                                    fNewOrLost = t.FNewOrLost,
                                    fInterviewRequirement = t.FInterviewRequirement,
                                    fEntityOrElectronic = t.FEntityOrElectronic,
                                    fProcessingTime = t.FProcessingTime.FProcessingTime,
                                    fValidityPeriod = t.FValidityPeriod.FValidityPeriod,
                                    fLengthOfStayId = t.FLengthOfStay.FLengthOfStay,
                                    fPrice = t.FPrice
                                });

            return Json(VProductsBySupplier);
        }

        public IActionResult searchProductsByCountry(string country)
        {
            var Products = _context.TVproducts.Include(t => t.FCountry).Where(c => c.FCountry.FCountry == country && c.FEnabled == true).ToList();
            if (Products.Count() == 0)
            {
                return Json("");
            }
            else
            {
                int productsCount = Products.Count;
                int averagePrice = Convert.ToInt32(Products.Average(p => p.FPrice));
                return Json(new { ProductsCount = productsCount, AveragePrice = averagePrice });
            }
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
