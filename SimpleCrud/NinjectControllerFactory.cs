using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleCrud
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public IKernel Kernel { get; set; }

        public NinjectControllerFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = null;

            if (controllerType != null)
                controller = (IController)Kernel.Get(controllerType);

            return controller;
        }

    }
}