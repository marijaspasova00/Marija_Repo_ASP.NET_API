using Marija_Homework_Class02_Code.Domain.Models;
using System;

namespace Marija_Homework_Class02_Code.Data
{
    public static class StaticDb
    {
        public static List<User> Users = new List<User>()
        {
            new User { Id = 1, FullName = "John Doe", Email = "john.doe@example.com" },
            new User { Id = 2, FullName = "Jane Smith", Email = "jane.smith@example.com" },
            new User { Id = 3, FullName = "Michael Johnson", Email = "michael.johnson@example.com" },
            new User { Id = 4, FullName = "Emily Brown", Email = "emily.brown@example.com" },
            new User { Id = 5, FullName = "David Wilson", Email = "david.wilson@example.com" },
            new User { Id = 6, FullName = "Sarah Davis", Email = "sarah.davis@example.com" },
            new User { Id = 7, FullName = "James Miller", Email = "james.miller@example.com" },
            new User { Id = 8, FullName = "Anna Martinez", Email = "anna.martinez@example.com" },
            new User { Id = 9, FullName = "Robert Taylor", Email = "robert.taylor@example.com" },
            new User { Id = 10, FullName = "Linda Anderson", Email = "linda.anderson@example.com" }
        };
    }
}
