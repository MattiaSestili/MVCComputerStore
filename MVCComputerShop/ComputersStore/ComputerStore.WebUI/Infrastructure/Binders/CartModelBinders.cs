using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerStore.Domain.Entities;
using System.Web.Mvc;

namespace ComputerStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinders : IModelBinder
    {
        private const string sessionkey = "Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //get the Cart from the session
            Cart cart = null;

            if(controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionkey];
            }
            //create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new Cart();
                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionkey] = cart;
                }
            }
            return cart;
        }
    }
}