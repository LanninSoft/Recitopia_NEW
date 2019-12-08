﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recitopia.Models;

namespace Recitopia.Controllers
{
    public class AppUsersController : AuthorizeController
    {
        private readonly RecitopiaDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        public AppUsersController(RecitopiaDBContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        [Authorize]
        // GET: AppUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppUsers.ToListAsync());
        }

        // GET: AppUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // GET: AppUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: AppUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [FromForm] AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                //USE LINQ TO UPDATE USER
                var appuser = _context.AppUsers.Find(id);
                try
                {
                    if (appuser != null)
                    {
                        appuser.FirstName = appUser.FirstName;
                        appuser.LastName = appUser.LastName;
                        appuser.PhoneNumber = appUser.PhoneNumber;
                        appuser.Address1 = appUser.Address1;
                        appuser.Address2 = appUser.Address2;
                        appuser.City = appUser.City;
                        appuser.State = appUser.State;
                        appuser.ZipCode = appUser.ZipCode;
                        appuser.WebUrl = appUser.WebUrl;
                        appuser.Notes = appUser.Notes;
                        appuser.Customer_Id = appUser.Customer_Id;
                        appuser.Email = appUser.Email;
                        appuser.EmailConfirmed = appUser.EmailConfirmed;
                        appuser.PhoneNumberConfirmed = appUser.PhoneNumberConfirmed;
                        appuser.TwoFactorEnabled = appUser.TwoFactorEnabled;
                        appuser.LockoutEnd = appUser.LockoutEnd;
                        appuser.LockoutEnabled = appUser.LockoutEnabled;
                        appuser.AccessFailedCount = appUser.AccessFailedCount;

                        await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppUserExists(appUser.Id))
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
            return View(appUser);
        }

        // GET: AppUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.AppUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppUserExists(string id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}
