using Ninject;
using SimpleCrud.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public abstract class BaseController : Controller
    {
        [Inject]
        public IKernel Kernel { get; set; }

        public void Validate<TModel>(TModel model) 
        {
            var validator = Kernel.Get <IValidator<TModel>>();

            var result = validator.Validate(model);
            
            foreach (var res in result)
            {
                ModelState.AddModelError(res.Key, res.Message);
            }

        }
    }
}