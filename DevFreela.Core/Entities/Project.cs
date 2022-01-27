using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreelancer, decimal? totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            CreateAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Coments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal? TotalCost { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime? StarteAt { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Coments { get; private set; }

        public void Cancel()
        {
            if(Status == ProjectStatusEnum.InProgress)
                Status = ProjectStatusEnum.Cancelled;
        }

        public void Finish()
        {
            if (Status == ProjectStatusEnum.InProgress)
                Status = ProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
        }

        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
                Status = ProjectStatusEnum.InProgress;
                StarteAt = DateTime.Now;
        }

        //excluir depois que implementar o EF
        public void Update(string title, string description, decimal totalCost)
        {
            this.Title = title;
            this.Description = description;
            this.TotalCost = totalCost;
       
        }
    }
}
