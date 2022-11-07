﻿using BookCatalogWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogWeb.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Categories { get; set; }
}
