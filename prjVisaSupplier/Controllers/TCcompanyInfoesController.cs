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
    public class TCcompanyInfoesController : Controller
    {
        private readonly dbTravalPlatformContext _context;

        public TCcompanyInfoesController(dbTravalPlatformContext context)
        {
            _context = context;
        }

        // GET: TCcompanyInfoes
        public async Task<IActionResult> Index()
        {
              return _context.TCcompanyInfos != null ? 
                          View(await _context.TCcompanyInfos.ToListAsync()) :
                          Problem("Entity set 'dbTravalPlatformContext.TCcompanyInfos'  is null.");
        }

        // GET: TCcompanyInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TCcompanyInfos == null)
            {
                return NotFound();
            }

            var tCcompanyInfo = await _context.TCcompanyInfos
                .FirstOrDefaultAsync(m => m.FId == id);
            if (tCcompanyInfo == null)
            {
                return NotFound();
            }

            return View(tCcompanyInfo);
        }

        // GET: TCcompanyInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TCcompanyInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FId,FType,FCompanyName,FLanguage,FCountry,FCity,FPostalCode,FAddress,FPhoneCountryCode,FPhone,FUrl,FNameOfPersonInCharge,FCertificatePath,FContactName,FContactPosition,FContactEmail,FPassword,FContactPhoneCountryCode,FContactPhone,FContactTimeZone,FIsChecked,FCheckDate,FIsInCooperation,FLogo")] TCcompanyInfo tCcompanyInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tCcompanyInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tCcompanyInfo);
        }

        // GET: TCcompanyInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TCcompanyInfos == null)
            {
                return NotFound();
            }

            var tCcompanyInfo = await _context.TCcompanyInfos.FindAsync(id);
            if (tCcompanyInfo == null)
            {
                return NotFound();
            }
            return View(tCcompanyInfo);
        }

        // POST: TCcompanyInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FId,FType,FCompanyName,FLanguage,FCountry,FCity,FPostalCode,FAddress,FPhoneCountryCode,FPhone,FUrl,FNameOfPersonInCharge,FCertificatePath,FContactName,FContactPosition,FContactEmail,FPassword,FContactPhoneCountryCode,FContactPhone,FContactTimeZone,FIsChecked,FCheckDate,FIsInCooperation,FLogo")] TCcompanyInfo tCcompanyInfo)
        {
            if (id != tCcompanyInfo.FId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tCcompanyInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TCcompanyInfoExists(tCcompanyInfo.FId))
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
            return View(tCcompanyInfo);
        }

        // GET: TCcompanyInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TCcompanyInfos == null)
            {
                return NotFound();
            }

            var tCcompanyInfo = await _context.TCcompanyInfos
                .FirstOrDefaultAsync(m => m.FId == id);
            if (tCcompanyInfo == null)
            {
                return NotFound();
            }

            return View(tCcompanyInfo);
        }

        // POST: TCcompanyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TCcompanyInfos == null)
            {
                return Problem("Entity set 'dbTravalPlatformContext.TCcompanyInfos'  is null.");
            }
            var tCcompanyInfo = await _context.TCcompanyInfos.FindAsync(id);
            if (tCcompanyInfo != null)
            {
                _context.TCcompanyInfos.Remove(tCcompanyInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TCcompanyInfoExists(int id)
        {
          return (_context.TCcompanyInfos?.Any(e => e.FId == id)).GetValueOrDefault();
        }
    }
}
