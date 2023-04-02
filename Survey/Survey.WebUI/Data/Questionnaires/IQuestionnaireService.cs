namespace Survey.WebUI.Data.Questionnaires
{
    public interface IQuestionnaireService
    {
        Task<QuestionnaireListVM> GetQuestionnairesAsync(string search, int? orderIndex = null);
        Task<QuestionnaireVM> GetQuestionnaireByIdAsync(int id);

        Task<int> Create(QuestionnaireVM questionnaire);
        Task Update(QuestionnaireVM questionnaire);
        Task ChangeStatus(QuestionnaireVM questionnaire);
    }
}
