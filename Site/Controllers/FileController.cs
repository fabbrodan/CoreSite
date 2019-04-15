using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Microsoft.EntityFrameworkCore;

namespace Site.Controllers
{
    public class FileController : Controller
    {
        private readonly SiteDBContext _context;

        public FileController(SiteDBContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var file = await _context.FindAsync<Files>(Id);

            if (file == null)
            {
                return NotFound();
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", file.FileName);
            FileInfo info = new FileInfo(path);
            try
            {
                _context.Files.Remove(file);
                info.Delete();
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }

            return RedirectToAction("LoadAllFiles", "Image");
        }
    }
}