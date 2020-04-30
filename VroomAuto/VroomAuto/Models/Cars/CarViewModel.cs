using VroomAuto.AppLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VroomAuto.Models.Cars
{
    public class CarViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
    }
}
