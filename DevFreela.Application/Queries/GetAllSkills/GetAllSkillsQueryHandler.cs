using Dapper;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        //COM EF CORE
        //public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        //{
        //    var skills = _dbContext.Skills;

        //    var skillsViewModel = skills
        //        .Select(s => new SkillViewModel(s.Id, s.Description))
        //        .ToList();

        //    return skillsViewModel;
        //}

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "SELECT id, Description FROM Skills";
                var skills =  await sqlConnection.QueryAsync<SkillViewModel>(script);

                return skills.ToList();
            }
        }
    }
}
