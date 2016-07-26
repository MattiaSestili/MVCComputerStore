using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ComputerStore.WebUI.Models;

namespace ComputerStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int PageSize = 4;

        //remove Index Action Methodd replace with a constructor
        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }

        //tells the framework to render the default view for the action method
        public ViewResult List(string type, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => type == null || p.Type == type)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = type == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e => e.Type == type).Count()

                },

                CurrentType = type
            };
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}