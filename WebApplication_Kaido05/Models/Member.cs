using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication_Kaido05.Models
{
    //member model
    public class Member
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    //context class
    public class MyContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
    }
}