using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserLibrary.Models
{
    public class User
    {
        [Range(1000, 9999)]
        public int UserPass { get; set; }
        public string UserInfo { get; set; }
        public User()
        {
            UserPass = 123;
            UserInfo = "bruh";
        }
    }
}