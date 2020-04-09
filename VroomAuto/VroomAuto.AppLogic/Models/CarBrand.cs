﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VroomAuto.AppLogic.Models
{
    class CarBrand
    {
        [Key]
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
