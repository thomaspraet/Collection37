using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Collection.Web.Data;
using Collection.Web.Models;
using Collection.Web.Models.Artworks;
using AutoMapper;
using Collection.Web.Services;

namespace Collection.Web.Controllers
{
    public class ArtworksController(IArtworksService _artworksService) : Controller
    {
        // GET: Artworks
        public async Task<IActionResult> Index()
        {
            var viewData = await _artworksService.GetAll();
            return View(viewData);
        }

        // GET: Artworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var artwork = await _artworksService.Get<ArtworkReadOnlyVM>(id.Value);    
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // GET: Artworks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtworkCreateVM artworkCreate)
        {
            if (ModelState.IsValid)
            {
                await _artworksService.Create(artworkCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(artworkCreate);
        }

        // GET: Artworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artwork = await _artworksService.Get<ArtworkEditVM>(id.Value);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // POST: Artworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArtworkEditVM artworkEdit)
        {
            if (id != artworkEdit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _artworksService.Edit(artworkEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_artworksService.ArtworkExists(artworkEdit.Id))
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
            return View(artworkEdit);
        }

        // GET: Artworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artwork = await _artworksService.Get<ArtworkReadOnlyVM>(id.Value);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // POST: Artworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _artworksService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
