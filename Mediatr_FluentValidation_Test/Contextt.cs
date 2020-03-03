﻿using System;
using Mediatr_FluentValidation_Test.Model;
using Microsoft.EntityFrameworkCore;

namespace Mediatr_FluentValidation_Test
{
    public class Contextt : DbContext

    {
        public Contextt(DbContextOptions<Contextt> opt) : base(opt) { }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customer_Payment_Card> CPC { get; set; }
        public DbSet<Merhcant> merhcants { get; set; }

    }
}
