﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            
            //Client seeding
            modelBuilder.Entity<Client>().HasData(new Client { Id = 1, Name = "Tacta" });

            //User seedings
             modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "Nermin.Selim", FirstName = "Nermin", LastName = "Selim", Role = "Administrator", AvatarURL = "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg" },
               new User { Id = 2, UserName = "Selim.Nermin", FirstName = "Selim", LastName = "Nermin", Role = "User", AvatarURL = "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg" });
            
            //Project seedings

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, ClientId = 1, Name = "Tracker", Code = "TA10001" },
                new Project { Id = 2, ClientId = 1, Name = "Tracker2", Code = "TA10002" });

            //ProjectTasks seedings
            
            modelBuilder.Entity<ProjectTask>().HasData(
                 new ProjectTask { Id = 1, ProjectId = 1, Name = "Design", Billable = true },
                  new ProjectTask { Id = 2, ProjectId = 1, Name = "Implementation", Billable = true },
                   new ProjectTask { Id = 3, ProjectId = 1, Name = "Review", Billable = false },
                    new ProjectTask { Id = 4, ProjectId = 1, Name = "Marketing", Billable = true },
                    new ProjectTask { Id = 5, ProjectId = 2, Name = "UI", Billable = true },
                     new ProjectTask { Id = 6, ProjectId = 2, Name = "Backend", Billable = true },
                      new ProjectTask { Id = 7, ProjectId = 2, Name = "Deployment", Billable = true },
                       new ProjectTask { Id = 8, ProjectId = 2, Name = "Audit", Billable = false });

            //UserProject seedings

            modelBuilder.Entity<UserProject>().HasData(
                    new UserProject { UserId = 1, ProjectId = 2 },
                    new UserProject { UserId = 2, ProjectId = 1 });

            //ProjectTaskEntries

            modelBuilder.Entity<ProjectTaskEntry>().HasData(
                new ProjectTaskEntry { Id = 1,  UserId = 1, ProjectTaskId = 1, Date = DateTime.Now, DurationInMin = 30, Note=" Lorem ipsum dolor sit amet" },
                new ProjectTaskEntry { Id = 2, UserId = 1, ProjectTaskId = 2, Date = DateTime.Now, DurationInMin = 90, Note = " Lorem ipsum dolor sit amet" },
                new ProjectTaskEntry { Id = 3, UserId = 1, ProjectTaskId = 3, Date = DateTime.Now, DurationInMin = 60, Note = " Lorem ipsum dolor sit amet" },
                new ProjectTaskEntry { Id = 4, UserId = 1, ProjectTaskId = 4, Date = DateTime.Now, DurationInMin = 90, Note = " Lorem ipsum dolor sit amet" }

                );





        }

    }
}
