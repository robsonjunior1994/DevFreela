﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title,inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);

            _dbContext.Projects.Add(project);
            //_dbContext.SaveChange();
            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.ProjectComments.Add(comment);
            //_dbContext.SaveChange();

        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Cancel();
            //_dbContext.Projects.Update(project);
            //_dbContext.SaveChange();

        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Finish();
            //_dbContext.Projects.Update(project);
            //_dbContext.SaveChange();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Title, p.CreateAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            var projectDetailsViewModel = new ProjectDetailsViewModel
                (
                    project.Id,
                    project.Title,
                    project.Description,
                    project.TotalCost,
                    project.StarteAt,
                    project.FinishedAt
                );
            
            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Start();
            //_dbContext.Projects.Update(project);
            //_dbContext.SaveChange();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            //var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.id);
            //_dbContext.Projects.Update(project);
            //_dbContext.SaveChange();
        }
    }
}
