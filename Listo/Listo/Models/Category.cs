using System;
using System.Collections.Generic;
using System.Text;

namespace Listo.Models
{
    public class Category
    {
        public string Name { get; set; }

        public string Detail { get; set; }
        
        public CGroup SubCategory { get; set; }
    }
}
