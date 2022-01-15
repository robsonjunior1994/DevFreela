using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
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

    }
}

