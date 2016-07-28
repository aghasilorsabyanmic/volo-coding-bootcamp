using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationWithDatabase.Models
{
    public class ModelFactory
    {
        public static ModelFactory Create()
        {
            return new ModelFactory();
        }

        public ProductViewModel Create(Product model)
        {
            return new ProductViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Issued = model.Issued
            };
        }
    }
}