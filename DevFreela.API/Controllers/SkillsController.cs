using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Get()
        {
            var getAllSkillsQuery = new GetAllSkillsQuery();
            var skills = await _mediator.Send(getAllSkillsQuery);
            return Ok(skills);
        }

    }
}
