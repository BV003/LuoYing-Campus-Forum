using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace softs
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated(); //自动建库建表
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Timetable> Timetables { get; set; }

        public DbSet<Post> Posts { get; set; }


    }
}
