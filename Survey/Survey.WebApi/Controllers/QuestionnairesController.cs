using Microsoft.AspNetCore.Mvc;
using Survey.Application.Questionnaires.Commands.Create;
using Survey.Application.Questionnaires.Queries.GetQuestionnaire;
using Survey.Application.Questionnaires.Queries.GetQuestionnaires;

namespace Survey.WebApi.Controllers
{
    public class QuestionnairesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<QuestionnaireListDto>> GetAll([FromQuery] GetQuestionnairesQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionnaireDto>> GetById(int id)
        {
            return await Mediator.Send(new GetQuestionnaireQuery {Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateQuestionnaireCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateQuestionnaireCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/changestatus")]
        public async Task<ActionResult> ChangeStatus(int id, ChangeStatusQuestionnaireCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
