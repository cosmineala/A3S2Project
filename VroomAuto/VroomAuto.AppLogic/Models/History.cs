using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VroomAuto.AppLogic.Models
{
    class History
    {
        [Key]
        public int ID { get; set; }
        public User User { get; set; }
        public Car Car { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
