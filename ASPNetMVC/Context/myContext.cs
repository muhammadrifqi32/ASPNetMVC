using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPNetMVC.Context
{
    public class myContext : DbContext
    {
        public myContext() : base("ASPNetMVC") { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
    }
}