using SimpleCrud.Entities;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using System;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _repository = new PersonRepository();

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
            _repository.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            var user = new AddUserModel();
            return View(user);
        }

        [HttpPost]
        public ActionResult Add(AddUserModel user)
        {
            var dateOfBirth = user.DateOfBirth;
            var now = DateTime.UtcNow;

            var yearsDifference = now.Year - dateOfBirth.Year;

            if(yearsDifference <= 10)
            {
                ModelState.AddModelError(nameof(user.DateOfBirth), "User must be older than 10 years!");
            }

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