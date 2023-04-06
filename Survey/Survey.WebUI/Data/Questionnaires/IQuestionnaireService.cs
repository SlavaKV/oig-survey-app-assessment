namespace Survey.WebUI.Data.Questionnaires
{
    public interface IQuestionnaireService
    {
        Task<QuestionnaireListVM> GetQuestionnairesAsync(string search, int? orderIndex = null);
        Task<QuestionnaireViewModel> GetQuestionnaireByIdAsync(int id);

        Task<int> Create(QuestionnaireViewModel questionnaire);
        Task Update(QuestionnaireViewModel questionnaire);
        Task Close(int id);
        Task Schedule(int id);
    }
}
