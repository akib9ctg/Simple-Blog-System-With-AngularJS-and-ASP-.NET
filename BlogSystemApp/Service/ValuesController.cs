using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogSystemApp.Models;

namespace BlogSystemApp.Service
{
    public class ValuesController : ApiController
    {
        
        [HttpPost]
        [ActionName("SaveUser")]
        public void SaveStudent([FromBody]User user)
        {
            MyDbContext myDbContext = new MyDbContext();
            myDbContext.Users.Add(user);
            myDbContext.SaveChanges();
        }

        [HttpPost]
        [ActionName("SavePost")]
        public void SavePost([FromBody]Post post)
        {
            MyDbContext myDbContext = new MyDbContext();
            myDbContext.Posts.Add(post);
            myDbContext.SaveChanges();
        }

        [HttpGet]
        [ActionName("GetAllPosts")]
        public List<PostView> GetAllPosts()
        {
            MyDbContext myDbContext = new MyDbContext();
            return myDbContext.Database.SqlQuery<PostView>("exec GetAllPosts")
                .ToList();

        }
        
        [HttpGet]
        [ActionName("GetUserById")]
        public User GetUserById(int stId)
        {
            MyDbContext myDbContext = new MyDbContext();
            var user= myDbContext.Users.Where(m => m.Id == stId).FirstOrDefault();
            return user;
        }
    }
}