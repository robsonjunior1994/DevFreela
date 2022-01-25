using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto .NET Core 5 - 1", "Descrição do projeto 1", 1, 1, 1000),
                new Project("Meu projeto .NET Core 5 - 2", "Descrição do projeto 2", 1, 1, 2000),
                new Project("Meu projeto .NET Core 5 - 3", "Descrição do projeto 3", 1, 1, 3000)
            };

            Users = new List<User>
            {
                new User("Robson Junior", "robson@mail.com", new DateTime(1994,1,23)),
                new User("Lucas Nobre", "nobre@mail.com", new DateTime(1995,5,21)),
                new User("Eneas Lucas", "eneas@mail.com", new DateTime(1996,3,4))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL"),
            };

        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
