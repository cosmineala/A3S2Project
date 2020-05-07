using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VroomAuto.AppLogic.Models
{
    public class History
    {
        public int ID { get; set; }
        public string User { get; set; }
        public string Car { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
