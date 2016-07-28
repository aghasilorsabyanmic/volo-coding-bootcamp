using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationWithDatabase.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? Issued { get; set; }
    }
}