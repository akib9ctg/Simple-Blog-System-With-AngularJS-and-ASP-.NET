using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BlogSystemApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string PostDetails { get; set; }
        public string Time { get; set; }
        public  int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }
    }
}