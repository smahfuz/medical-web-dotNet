﻿using CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.DATA
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) { }
       public DbSet<Patient> Patients { get; set; }
       public DbSet<Department> Departments { get; set; }

       
    }
}
