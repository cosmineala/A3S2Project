using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VroomAuto.AppLogic.Models
{
    class UnwantedUser
    {
        [Key]
        public int ID { get; set; }
        public string CNP { get; set; }
    }
}
