using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlTypes;
using Site.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;

namespace Site.Controllers
{
    public class ImageController : Controller
    {
        private readonly SiteDBContext _context;

        public ImageController(SiteDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains<string>("Authenticated"))
            {
                return View("Unauthorized");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Upload(List<IFormFile> formFiles)
        {
            foreach (var file in Request.Form.Files)
            {
                var path = "";
                int index = file.FileName.IndexOf('.') + 1;
                string fileType = file.FileName.Substring(index).ToLower();

                int categoryId = Int32.Parse(Request.Form["categoryId"]);
                FileCategories category = _context.FileCategories.First<FileCategories>(c => c.CategoryId == categoryId);
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", category.CategoryLabel, file.FileName);

                try
                {
                    Images img = new Images();
                    img.ImgFileName = file.FileName;
                    img.UploadedDate = DateTime.Now;
                    img.IsPublished = 0;
                    img.CategoryId = categoryId;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    _context.Images.Add(img);
                }
                catch (IOException)
                {
                    return View("../Shared/Error");
                }

                _context.SaveChanges();
            }

            return RedirectToAction("LoadAllFiles");
        }

        [HttpGet]
        public async Task<IActionResult> LoadAllFiles()
        {
            AllFilesViewModel model = new AllFilesViewModel
            {
                Images = await _context.Images.ToListAsync<Images>(),
                Files = await _context.Files.ToListAsync<Files>(),
                Categories = await _context.FileCategories.ToListAsync<FileCategories>(),
                FileFolders = await _context.Folders.ToListAsync<Folders>()
            };

            model.Categories = model.Categories.OrderBy<FileCategories, int>(i => i.CategoryId);
            model.Images = model.Images.OrderByDescending<Images, DateTime>(t => t.UploadedDate);
            model.Files = model.Files.OrderByDescending<Files, DateTime>(t => t.UploadedDate);

            return View("AllFiles", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var img = await _context.FindAsync<Images>(id);
            if (img == null)
            {
                return NotFound();
            }

            return View("Image", img);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var img = await _context.FindAsync<Images>(Id);
            if (img == null)
            {
                return NotFound();
            }
            FileCategories category = await _context.FileCategories.FirstAsync(c => c.CategoryId == img.CategoryId);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", category.CategoryLabel, img.ImgFileName);
            var fileInfo = new FileInfo(path);
            try
            {
                _context.Images.Remove(img);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }

            return RedirectToAction("LoadAllFiles");
        }

        public async Task<IActionResult> Publish(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Images img = await _context.Images.FindAsync(Id);
            if (img == null)
            {
                return NotFound();
            }
            img.IsPublished = 1;
            img.PublishedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction("LoadAllFiles");
        }

        public async Task<IActionResult> Unpublish(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Images img = await _context.Images.FindAsync(Id);
            if (img == null)
            {
                return NotFound();
            }
            img.IsPublished = 0;
            await _context.SaveChangesAsync();

            return RedirectToAction("LoadAllFiles");
        }

        public async Task<IActionResult> CategoryUpdate(int? ImgId, int? CatId)
        {
            if (ImgId == null || CatId == null)
            {
                return NotFound();
            }

            var img = await _context.Images.FirstAsync<Images>(i => i.ImageId == ImgId);

            if (img == null)
            {
                return NotFound();
            }
            FileCategories newCategory = await _context.FileCategories.FirstAsync<FileCategories>(i => i.CategoryId == CatId);
            FileCategories oldCategory = await _context.FileCategories.FirstAsync<FileCategories>(i => i.CategoryId == img.CategoryId);
            img.CategoryId = (int)CatId;

            _context.Images.Update(img);

            try
            {
                using (var oldStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", oldCategory.CategoryLabel, img.ImgFileName), FileMode.OpenOrCreate))
                {
                    using (var newStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", newCategory.CategoryLabel, img.ImgFileName), FileMode.OpenOrCreate))
                    {
                        await oldStream.CopyToAsync(newStream);
                    }
                }

                System.IO.File.Delete(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", oldCategory.CategoryLabel, img.ImgFileName)));

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View("../Shared/Error", img);
            }

            return RedirectToAction("LoadAllFiles");
        }
    }

    public enum IMAGEMIMES
    {
        bmp,
        cod,
        gif,
        ief,
        jpe,
        jpeg,
        jpg,
        jfif,
        svg,
        tif,
        tiff,
        ras,
        cmx,
        ico,
        png,
        pnm,
        pbm,
        pgm,
        ppm,
        rgb,
        xbm,
        xpm,
        xwd
    }
}
