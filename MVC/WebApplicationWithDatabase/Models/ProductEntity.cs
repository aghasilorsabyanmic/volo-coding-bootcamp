using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationWithDatabase.Models
{
    public partial class Product
    {
        public bool HasIssuedDate
        {
            get
            {
                return Issued != null;
            }
        }
    }
}