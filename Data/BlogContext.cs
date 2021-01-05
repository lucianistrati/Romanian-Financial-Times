using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
//using System.Web;
using RomanianFinancialTimes.Models;
using Microsoft.EntityFrameworkCore;

namespace RomanianFinancialTimes.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options=null):base(options){}

        public DbSet<Models.Writer> Writer { get; set; }
        
        public DbSet<Models.Reader> Reader { get; set; }
        
        public DbSet<Models.Article> Article { get; set; }
        
        public DbSet<Models.User> User { get; set; }
        
        public DbSet<Models.Comment> Comment { get; set; }
    }
}