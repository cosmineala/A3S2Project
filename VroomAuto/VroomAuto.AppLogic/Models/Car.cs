using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VroomAuto.AppLogic.Models
{
    class Car
    {
        [Key]
        public int ID { get; set; }
        public string RegistrationNumber { get; set; }
        public int Km { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ManufacutreDate { get; set; }

        public CarStatus Status { get; set; }

        public CarBrand Brand { get; set; }

        public CarModel Model { get; set; }

        public CarClass Class { get; set; }

        public float Price { get; set; }



    }
}
