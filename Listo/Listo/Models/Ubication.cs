using System;
using System.Collections.Generic;
using System.Text;

namespace Listo.Models
{
    public class Ubication
    {
        public int UbicationId { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Ubication()
        {
            UbicationId = 0;
            Address = "";
            Description = "";
            Phone ="";
            Latitude = 0;
            Longitude = 0;
        }
    }
}
