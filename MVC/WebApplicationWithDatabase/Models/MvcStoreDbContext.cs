using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationWithDatabase.Models
{
    public partial class MvcStoreDbContext
    {
        public MvcStoreDbContext(string name) : base($"name={name}")
        {

        }
    }
}