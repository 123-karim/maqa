using maqa.controler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maqa.Data.sqlserveref
{
     public class DBcontext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=\\.\pipe\MSSQL$KARIM\sql\query;Database=ArticalProject;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<AuthorPost> AuthorPost { get; set; }


    }
}
