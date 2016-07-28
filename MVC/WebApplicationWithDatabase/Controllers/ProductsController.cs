using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationWithDatabase.Models;

namespace WebApplicationWithDatabase.Controllers
{
    public class ProductsController : Controller
    {
        private MvcStoreDbContext db = new MvcStoreDbContext();
        private ModelFactory modelFactory = ModelFactory.Create(); 

        // GET: Products
        public ActionResult Index()
        {
            
            var products = db.Products.ToList()
                .Select(p => modelFactory.Create(p));
            //if(products[0].HasIssuedDate) //products[0].Issued != null
            //{

            //}
            return View(products);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}