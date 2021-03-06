﻿using SimpleCrud.Entities;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using SimpleCrud.Validators;
using System;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
           
        }

        public ActionResult Index()
        {
            var userList = _repository.GetAllUsers();
            return View(userList);
        }

        public ActionResult Edit(long id)
        {
           var model = _repository.GetUser(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            Validate(model);
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Add()
        {
            var user = new AddUserModel();
            return View(user);
        }

        [HttpPost]
        public ActionResult Add(AddUserModel user)
        {
            Validate(user);
          
            if (ModelState.IsValid)
            {
                _repository.Add(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
          
        }

        public ActionResult Delete (long id)
        {
           return View(id);
        }

        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}