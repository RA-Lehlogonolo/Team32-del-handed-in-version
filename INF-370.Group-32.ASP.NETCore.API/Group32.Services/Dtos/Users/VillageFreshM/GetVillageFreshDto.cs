﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Users.VillageFreshM
{

   public class GetVillageFreshDto
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AutoAssignedPassword { get; set; }
      
    }
}
