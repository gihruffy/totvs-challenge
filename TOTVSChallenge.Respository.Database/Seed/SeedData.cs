using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Respository.Database.Seed
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                User.Create( id: 1, password: "123456", role: "Admin", username: "giovanni", isActive: true ),
                User.Create(id: 2, password: "654321", role: "Admin", username: "teste", isActive: true),
                User.Create(id: 3, password: "123456", role: "User", username: "outro", isActive: false)
            );
        }
    }
}
