﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) {
            _db = db;
                }
        public IActionResult Index()
        {
            List<Category> objCategoryList =  _db.categories.ToList();
            return View(objCategoryList);
        }

        public ActionResult Create() {
            return View();

        }
    }
}
