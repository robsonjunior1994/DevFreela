﻿using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProjects;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        //// Criando com o padrão Service
        //// api/projects
        //[HttpGet]
        //public IActionResult Get(string query)
        //{
        //    //Validação
        //    //Buscar todos os projetos ou filtrar para uma busca especifica
        //    var projects = _projectService.GetAll(query);
        //    return Ok(projects);
        //}

        // Criando com o padrão CQRS query
        // api/projects
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {

            //Validação
            //Buscar todos os projetos ou filtrar para uma busca especifica
            var getAllProjectsQuery = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(getAllProjectsQuery);
            return Ok(projects);
        }
        //// Criando com o padrão Service
        //// api/projects/3
        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var project = _projectService.GetById(id);

        //    if (project == null)
        //        return NotFound();

        //    return Ok(project);
        //}

        // Criando com o padrão CQRS query
        // api/projects/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getProjectByIdQuery = new GetProjectByIdQuery(id);
            var project = await _mediator.Send(getProjectByIdQuery);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        //// Criando com o padrão Service
        //// api/projects
        //[HttpPost]
        //public IActionResult Post([FromBody]NewProjectInputModel inputModel)
        //{
        //    //Validação
        //    if (inputModel.Title.Length > 50)
        //        return BadRequest();

        //    // Criar um Projeto
        //    var id = _projectService.Create(inputModel);

        //    //returna um 2021
        //    return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        //}

        // Criando com o padrão CQRS commands
        // api/projects
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectsCommand command)
        {
            // Criar um Projeto
            var id = await _mediator.Send(command);

            //returna um 2021
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //// Criando com o padrão Service
        //// api/projects/3
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] UpdateProjectInputModel InputModel)
        //{
        //    //Validação
        //    if (InputModel.Description.Length > 200)
        //        return BadRequest();

        //    //Atualiza o projeto
        //    _projectService.Update(InputModel);

        //    return NoContent();
        //}

        // Criando com o padrão CQRS
        // api/projects/3
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            //Atualiza o projeto
            await _mediator.Send(command);

            return NoContent();
        }

        //// Criando com o padrão Service
        //// api/projects/3
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    // Validação
        //    if (id < 0)
        //        return BadRequest();

        //    _projectService.Delete(id);
        //    return NoContent();
        //}

        // Criando com o padrão CQRS commands
        // api/projects/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteProjectCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        //// Criando com o padrão Service
        //// api/projects/1/comments POST
        //[HttpPost("{id}/comments")]
        //public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel InputModel)
        //{
        //    _projectService.CreateComment(InputModel);
        //    return NoContent();
        //}

        // Criando com o padrão CQRS commands
        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        //// Criando com o padrão Service
        //// api/projects/1/start PUT
        //[HttpPut("{id}/start")]
        //public IActionResult Start(int id)
        //{
        //    _projectService.Start(id);
        //    return NoContent();
        //}

        // api/projects/1/start PUT
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(StartProjectCommand command)
        {
            await _mediator.Send(command.Id);
            return NoContent();
        }

        //// Criando com o padrão Service
        //// api/projects/1/finish
        //[HttpPut("{id}/finish")]
        //public IActionResult Finish(int id)
        //{
        //    _projectService.Finish(id);
        //    return NoContent();
        //}

        // Criando com o padrão CQRS commands
        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(FinishProjectCommand command)
        {

            await _mediator.Send(command.Id);
            return NoContent();
        }


    }
}

