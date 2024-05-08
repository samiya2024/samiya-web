using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Assessment1_2_.Models;
using System.Data.Entity;

namespace Assessment1_2_.Models
{
    public class MoviesDB : DbContext
    {
        public DbSet<Movies> Movies { get; set; }
    }
}