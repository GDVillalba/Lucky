﻿using Lucky.Data;
using Lucky.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lucky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; 

        public CategoryController(ApplicationDbContext db) //database context is passed from the service configured in startup
        {
            _db = db;   //copy of database context
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Categories;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POSt - CREATE
       [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)          //server side model values validation
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);       //if error occurs return view with obj data
        }
    }
}
