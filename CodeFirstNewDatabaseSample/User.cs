﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstNewDatabaseSample
{
    public class User
    {
        [Key]
        public string Username { get; set; }    
        public string DisplayName { get; set; } 
    }
}
