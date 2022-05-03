using Dapper;
using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
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
        private readonly ISkillRepository _skillRepository;
        private readonly string _connectionString;
        public GetAllSkillsQueryHandler(ISkillRepository skillRepository, IConfiguration configuration)
        {
            _skillRepository = skillRepository;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        //COM EF CORE
        //public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        //{
        //    var skills = await _projectRepository.GetAll();

        //    var skillsViewModel = skills
        //        .Select(s => new SkillViewModel(s.Id, s.Description))
        //        .ToList();

        //    return skillsViewModel;
        //}

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _skillRepository.GetAllDapperAsync();
        }
    }
}
