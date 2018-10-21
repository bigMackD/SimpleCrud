using SimpleCrud.Entities;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using SimpleCrud.Validators;
using System;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _repository = new PersonRepository();
        private readonly IValidator<AddUserModel> _addUserValidator = new AddUserModelValidator();

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
           var validateResult = _addUserValidator.Validate(user);

           foreach(var res in validateResult)
            {
                ModelState.AddModelError(res.Key, res.Message);
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