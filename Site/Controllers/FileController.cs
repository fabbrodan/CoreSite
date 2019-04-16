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

        public async Task<IActionResult> Upload(string folder)
        {
            foreach (var file in Request.Form.Files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folder, file.FileName);

                try
                {
                    Files miscFile = new Files();
                    miscFile.FileName = file.FileName;
                    miscFile.UploadedDate = DateTime.Now;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    await _context.Files.AddAsync(miscFile);
                }
                catch (IOException)
                {
                    return View("../Shared/Error");
                }
            }

            return RedirectToAction("LoadAllFiles", "Image");
        }

        [HttpPost]
        public async Task<IActionResult> NewFolder()
        {
            var name = Request.Form["folderName"];
            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
            Folders newFolder = new Folders{ FolderName = name };

            if (!Directory.Exists(Path.Combine(rootPath, name)))
            {
                try
                {
                    Directory.CreateDirectory(Path.Combine(rootPath, name));
                    _context.Folders.Add(newFolder);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return View("../Shared/Error");
                }
            }

            return RedirectToAction("LoadAllFiles", "Image");
        }

        public async Task<IActionResult> DeleteFolder(int? id)
        {
            Folders folder = await _context.Folders.FirstAsync(f => f.FolderId == id);
            try
            {
                _context.Folders.Remove(folder);
                Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folder.FolderName), true);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }

            return RedirectToAction("LoadAllFIles", "Image");
        }
    }
}