﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogSystemApp.Models
{
    public class User
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string  Phone { get; set; }
        public string  Password { get; set; }
    }
}