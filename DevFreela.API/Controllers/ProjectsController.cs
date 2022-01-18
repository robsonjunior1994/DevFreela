using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        public ProjectsController(IOptions<OpeningTimeOption> option)
        {
            _option = option.Value;
        }

        // api/projects
        [HttpGet]
        public IActionResult Get(string query)
        {
            //Validação
            //Buscar todos os projetos ou filtrar para uma busca especifica
            return Ok();
        }

        // api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Validação
            //Buscar um projeto por id
            return Ok();
        }

        // api/projects
        [HttpPost]
        public IActionResult Post([FromBody]CreateProjectModel createProject)
        {
            //Validação
            if (createProject.Title.Length > 50)
                return BadRequest();

            // Criar um Projeto

            //returna um 2021
            return CreatedAtAction(nameof(GetById), new { id = createProject.Id}, createProject);
        }

        // api/projects/3
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            //Validação
            if (updateProject.Description.Length > 200)
                return BadRequest();

            //Atualiza o projeto

            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Validação
            if (id < 0)
                return BadRequest();

            //Buscar o projeto, se existir
            //Deleta o projeto
            return NoContent();

            // Se buscar e não encontrar
            return BadRequest();
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createCommentModel)
        {
            return NoContent();
        }
        // api/projects/1/start PUT
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }

    }
}

