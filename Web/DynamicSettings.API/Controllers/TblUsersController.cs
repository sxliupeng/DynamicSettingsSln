using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DynamicSettings.CodeFirst.Context;
using DynamicSettings.EF.Model;

namespace DynamicSettings.API.Controllers
{
    public class TblUsersController : Controller
    {
        private readonly SettingsManagementDbContext _context;

        public TblUsersController(SettingsManagementDbContext context)
        {
            _context = context;
        }

        // GET: TblUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: TblUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // GET: TblUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,DateCreated,DateModified,TimeStamp")] TblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                tblUser.ID = Guid.NewGuid();
                _context.Add(tblUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUser);
        }

        // GET: TblUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.Users.FindAsync(id);
            if (tblUser == null)
            {
                return NotFound();
            }
            return View(tblUser);
        }

        // POST: TblUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,DateCreated,DateModified,TimeStamp")] TblUser tblUser)
        {
            if (id != tblUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserExists(tblUser.ID))
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
            return View(tblUser);
        }

        // GET: TblUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // POST: TblUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(tblUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserExists(Guid id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
