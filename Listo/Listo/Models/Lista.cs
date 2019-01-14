using System;
using System.Collections.Generic;
using System.Text;

namespace Listo.Models
{
    public class Lista
    {
        public List<Category> Elements { get; set; }

        public Lista()
        {
            Elements = new List<Category>();
            LoadElements();
        }

        public void LoadElements()
        {
            Elements.Add(new Category
            {
                Name = "HOGAR",
                Detail = "",
            });

            Elements.Add(new Category
            {
                Name = "SALUD",
                Detail = "",
            });

            Elements.Add(new Category
            {
                Name = "PROFESIONALES",
                Detail = "",
            });
        }
    }
}
