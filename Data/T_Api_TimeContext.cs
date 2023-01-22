using System;
using Microsoft.EntityFrameworkCore;
using T_Api_Time.Models;

namespace T_Api_Time.Data
{
    public class T_Api_TimeContext : DbContext
    {
        public T_Api_TimeContext(DbContextOptions<T_Api_TimeContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    "Server = localhost; " +
                    "Database = ToDoNewDb; " +
                    "User Id = sa ; " +
                    "Password = HardT0Gue$$Pa$$word; " +
                    "Encrypt=False"
                );
        }

    }
}

