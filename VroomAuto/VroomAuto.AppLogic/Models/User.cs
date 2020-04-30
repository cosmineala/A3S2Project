using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VroomAuto.AppLogic.Models
{
    public class User
    {
        public int ID { get; set; }
        public Guid IdentityID { get; set; }

        //public int UserTypeID { get; set; }
        //public UserType UserType { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string CNP { get; set; }


    }
}
