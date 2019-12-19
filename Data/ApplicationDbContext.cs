using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthApp.Models;

namespace AuthApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AuthApp.Models.Tasks> Tasks { get; set; }
        public DbSet<AuthApp.Models.Modules> Modules { get; set; }
        public DbSet<AuthApp.Models.Priorities> Priorities { get; set; }
        public DbSet<AuthApp.Models.TaskStatus> TaskStatus { get; set; }
        public DbSet<AuthApp.Models.Assignments> Assignments { get; set; }
    }
}
