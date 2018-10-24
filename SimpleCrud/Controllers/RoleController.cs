using SimpleCrud.Models;
using SimpleCrud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRolesRepository _repository;
        public RoleController(IRolesRepository repository)
        {
            _repository = repository;
        }
       
        public ActionResult Index()
        {
           var rolesList = _repository.GetRoleModels();
            return View(rolesList);
        }

        public ActionResult Add()
        {
            var role = new AddRoleModel();
            return View(role);
        }

        [HttpPost]
        public ActionResult Add(AddRoleModel role)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(role);
                return RedirectToAction("Index");
            }
            else
            {
                return View(role);
            }
        }

        public ActionResult Delete(long id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult Delete(long id,object dummy)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}