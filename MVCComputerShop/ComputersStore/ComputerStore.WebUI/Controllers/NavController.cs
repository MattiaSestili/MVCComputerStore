using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;

        public NavController (IProductsRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> type = repository.Products
                    .Select(x => x.Type)
                    .Distinct()
                    .OrderBy(x => x);

            return PartialView(type);
        }

    }
}