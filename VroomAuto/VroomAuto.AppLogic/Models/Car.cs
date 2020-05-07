using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VroomAuto.AppLogic.Models
{
    public class Car
    {
        public int ID { get; set; }

        public string RegistrationNumber { get; set; }

        public int Km { get; set; }

        public DateTime ManufacutreDate { get; set; }

        public string Status { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Class { get; set; }

        public float Price { get; set; }



    }
}
