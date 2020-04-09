using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VroomAuto.AppLogic.Models
{
    public class CarClass
    {
        [Key]
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
