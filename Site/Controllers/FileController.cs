using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Site.Controllers
{
    public class FileController : Controller
    {
        private readonly SiteDBContext _context;

        public FileController(SiteDBContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Delete()
        {

            foreach (var key in Request.Form.Keys)
            {
                int Id = 0;
                Int32.TryParse(key, out Id);

                if (Id == 0)
                {
                    break;
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
            }

            return RedirectToAction("Index", "Image");
        }

        public async Task<IActionResult> Upload(List<IFormFile> formFiles)
        {
            int folderId = Int32.Parse(Request.Form["folderId"]);
            Folders folder = await _context.Folders.FirstAsync(f => f.FolderId == folderId);

            foreach (var file in Request.Form.Files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folder.FolderName, file.FileName);

                try
                {
                    Files newFile = new Files();
                    newFile.FileName = file.FileName;
                    newFile.FolderId = folderId;
                    newFile.UploadedDate = DateTime.Now;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    await _context.Files.AddAsync(newFile);
                    await _context.SaveChangesAsync();
                }
                catch (IOException)
                {
                    return View("../Shared/Error");
                }
            }

            return RedirectToAction("Index", "Image");
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

            return RedirectToAction("Index", "Image");
        }

        public async Task<IActionResult> DeleteFolder(int? id)
        {
            
            Folders folder = _context.Folders.First(f => f.FolderId == id);

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

            return RedirectToAction("Index", "Image");
        }
    }
}