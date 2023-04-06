using Microsoft.AspNetCore.Mvc;
using Survey.Application.Questionnaires.Commands.Close;
using Survey.Application.Questionnaires.Commands.Create;
using Survey.Application.Questionnaires.Commands.Schedule;
using Survey.Application.Questionnaires.Commands.Update;
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

        [HttpPut("{id}/close")]
        public async Task<ActionResult> Close(int id, CloseQuestionnaireCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/schedule")]
        public async Task<ActionResult> Schedule(int id, ScheduleQuestionnaireCommand command)
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
