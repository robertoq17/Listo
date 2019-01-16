using System;
using System.Collections.Generic;
using System.Text;

namespace Listo.Models
{
    public class ListHogar
    {
        public List<Category> Elements { get; set; }

        public ListHogar()
        {
            Elements = new List<Category>();
            LoadElements();
        }

        public void LoadElements()
        {
            Elements.Add(new Category
            {
                Name = "PLOMEROS",
                Detail = "",
            });

            Elements.Add(new Category
            {
                Name = "ELECTRICISTAS",
                Detail = "",
            });

            Elements.Add(new Category
            {
                Name = "JARDINEROS",
                Detail = "",
            });

            Elements.Add(new Category
            {
                Name = "ALBAÑILES",
                Detail = "",
            });
        }
    }
}
