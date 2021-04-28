using EducationalMaterialData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationalMaterialData.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    AuthorId = 1,
                    FirstName = "William",
                    LastName = "Shakespeare"
                }
            );
            modelBuilder.Entity<Material>().HasData(
                new Material { 
                    Name = ".NET Core 3.1 MVC REST API - Full Course",
                    MaterialId = 2, 
                    AuthorId = 1, 
                    Description = " Course Rest API",
                    Url = "https://www.youtube.com/watch?v=fmvcAzHpsk8&t=7339s", 
                    MaterialTypeId = 4 },
                new Material { 
                    Name = "Getting Started with EF Core",
                    MaterialId = 3, 
                    AuthorId = 1, 
                    Description = "EF Core ",
                    Url = "https://docs.microsoft.com/en-gb/ef/core/get-started/overview/first-app?tabs=netcore-cli", 
                    MaterialTypeId = 5 }
            );
            modelBuilder.Entity<MaterialType>().HasData(
                new MaterialType
                {
                    MaterialTypeId = 4,
                    Name = "MVC REST API",
                },
                new MaterialType
                {
                    MaterialTypeId = 5,
                    Name = "EF Core",
                }
            );
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewId = 6,
                    Description = "Good Material",
                    MaterialId = 2
                },
                new Review
                {
                    ReviewId = 7,
                    Description = "Nice One",
                    MaterialId = 3
                }
            );
        }
    }
}
