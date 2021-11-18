using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistrationApp.Models;
using UserRegistrationApp.Repository;

namespace UserRegistrationApp.Controllers
{
    public class UserController : Controller
    {
        UserRepository usr = new UserRepository();
        public IActionResult Index()
        {
            ModelState.Clear();
            return View(usr.display());
        }

        // GET: User/Create
        public IActionResult Details(int id)
        {
            return View(usr.display().Find(ur => ur.id == id));
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public IActionResult Create(UserRegModel userRegModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (usr.InsertData(userRegModel))
                {
                    ViewBag.Message = "Data Saved Successfully !";
                }
                return View(userRegModel);
                //return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // GET: User/Edit/5
        public IActionResult Edit(int id)
        {
            return View(usr.display().Find(ur => ur.id == id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, UserRegModel ur)
        {
            try
            {
                // TODO: Add update logic here
                if (usr.UpdateData(ur))
                {
                    ViewBag.Message = "Data Updated Successfully!";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public IActionResult Delete(int id)
        {
            return View(usr.display().Find(ur => ur.id == id));
        }

        // POST: User/Delete/5
        [HttpPost]
        public IActionResult Delete(int id, UserRegModel ur)
        {
            try
            {
                // TODO: Add delete logic here
                if (usr.DeleteData(ur))
                {
                    ViewBag.Message = "Data Deleted Successfully!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
