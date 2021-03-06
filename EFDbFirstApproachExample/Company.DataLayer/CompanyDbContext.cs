﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DomainModels;
//using EFDbFirstApproachExample.Migrations;

namespace Company.DataLayer
{
    public class CompanyDbContext: DbContext
    {
        public CompanyDbContext() : base("myconnectionstring")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
