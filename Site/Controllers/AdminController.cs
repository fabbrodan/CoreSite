﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Controllers
{
    public class AdminController : Controller
    {
        private readonly SiteDBContext _context;

        public AdminController(SiteDBContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!HttpContext.Session.Keys.Contains<string>("Authenticated"))
            {
                return View("../Image/Unauthorized");
            }

            List<FileCategories> categoryList = await _context.FileCategories.ToListAsync<FileCategories>();
            return View(categoryList);
        }

        [HttpPost]
        public async Task<IActionResult> NewCategory()
        {
            FileCategories category = new FileCategories
            {
                CategoryLabel = Request.Form["categoryLabel"]
            };

            await _context.FileCategories.AddAsync(category);
            try
            {
                await _context.SaveChangesAsync();
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", category.CategoryLabel)))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", category.CategoryLabel));
                }
            }
            catch (Exception)
            {
                return View("../Shared/Error");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int? Id)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
            List<Images> imgList = await _context.Images.Where<Images>(i => i.CategoryId == Id).ToListAsync<Images>();
            FileCategories oldCategory = await _context.FileCategories.FirstAsync<FileCategories>(c => c.CategoryId == Id);

            if (imgList.Count() > 0)
            {
                try
                {
                    foreach (Images img in imgList)
                    {
                        string oldPath = Path.Combine(path, oldCategory.CategoryLabel, img.ImgFileName);
                        var file = new FileInfo(oldPath);
                        file.MoveTo(Path.Combine(path, "No Category", img.ImgFileName));
                        img.CategoryId = 0;
                    }
                    Directory.Delete(Path.Combine(path, oldCategory.CategoryLabel));
                    _context.FileCategories.Remove(oldCategory);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return View("../Shared/Error");
                }
            }
            else
            {
                _context.FileCategories.Remove(oldCategory);
                Directory.Delete(Path.Combine(path, oldCategory.CategoryLabel));
                await _context.SaveChangesAsync();
            }

            List<FileCategories> categoryList = await _context.FileCategories.ToListAsync<FileCategories>();

            return RedirectToAction("Index", categoryList);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory()
        {
            string newLabel = Request.Form["newLabel"];
            int categoryId = Int32.Parse(Request.Form["categoryId"]);

            FileCategories category = await _context.FileCategories.FirstAsync<FileCategories>(i => i.CategoryId == categoryId);

            string oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", category.CategoryLabel);
            string newPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", newLabel);

            try
            {
                Directory.Move(oldPath, newPath);
                category.CategoryLabel = newLabel;
                _context.FileCategories.Update(category);
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return View("../Shared/Error");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditContactPage()
        {
            string text = Request.Form["text"];

            ContactText contactText = await _context.ContactText.FirstAsync(i => i.ID == 1);
            contactText.Text = text;
            _context.ContactText.Update(contactText);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}