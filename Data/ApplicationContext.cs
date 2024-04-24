using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageStaffDBApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ManageStaffDBApp.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get;set; }
        public DbSet<Position> Positions { get;set; }
        public DbSet<Department> Departments { get;set; }


        public ApplicationContext()
        {
            Database.EnsureCreated();     
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=POLISHCHUK-PC;Database=ManageStaffDBApp;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }
    }
}
