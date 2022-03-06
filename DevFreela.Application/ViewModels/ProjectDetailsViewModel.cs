using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal? totalCost, DateTime? starteAt, DateTime finishedAt, string clientFullName, string freelacerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StarteAt = starteAt;
            FinishedAt = finishedAt;
            ClientFullName = clientFullName;
            FreelacerFullName = freelacerFullName;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal? TotalCost { get; private set; }
        public DateTime? StarteAt { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public string ClientFullName { get; private set; }
        public string FreelacerFullName { get; private set; }

    }
}
