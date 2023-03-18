﻿using BookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }

        public DbSet<Author> authors { get; set; }

        public DbSet<Book> books { get; set; }

        public DbSet<User> users { get; set; }
        public DbSet<Review> reviews { get; set; }
    }
}