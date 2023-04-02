using Survey.WebUI.Services;
using System.Text;

namespace Survey.WebUI.Data.Questionnaires
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IHttpService _httpService;

        public QuestionnaireService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<QuestionnaireListVM> GetQuestionnairesAsync(string search, int? orderIndex = null)
        {
            StringBuilder queryParam = new StringBuilder();

            if (!string.IsNullOrEmpty(search))
            {
                queryParam.Append($"search={search}");
            }

            if (orderIndex is not null)
            {
                if (queryParam.Length > 0)
                {
                    queryParam.Append("&");
                }
                queryParam.Append($"orderindex={orderIndex}");
            }

            if (queryParam.Length > 0)
            {
                queryParam.Insert(0,"?");
            }

            return await _httpService.Get<QuestionnaireListVM>($"/api/questionnaires{queryParam}");
        }

        public async Task<QuestionnaireVM> GetQuestionnaireByIdAsync(int id)
        {
            return await _httpService.Get<QuestionnaireVM>($"/api/questionnaires/{id}");
        }

        public async Task<int> Create(QuestionnaireVM questionnaire)
        {
            var command = new
            {
                Name = questionnaire.Name,
                StartDateTime = questionnaire.StartDateTime,
                EndDateTime = questionnaire.EndDateTime
            };

            return await _httpService.Post<int>($"/api/questionnaires", command);
        }

        public async Task Update(QuestionnaireVM questionnaire)
        {
            var command = new
            {
                Id = questionnaire.Id,
                Name = questionnaire.Name,
                StartDateTime = questionnaire.StartDateTime,
                EndDateTime = questionnaire.EndDateTime
            };

            await _httpService.Put($"/api/questionnaires/{questionnaire.Id}", command);
        }

        public async Task ChangeStatus(QuestionnaireVM questionnaire)
        {
            var command = new
            {
                Id = questionnaire.Id
            };

            await _httpService.Put($"/api/questionnaires/{questionnaire.Id}/changestatus", command);
        }
    }
}
