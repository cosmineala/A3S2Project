﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VroomAuto.AppLogic.Models
{
    public class UserType
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

    }
}
