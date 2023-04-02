namespace Survey.Application.Questionnaires.Queries.GetQuestionnaires
{
    public class QuestionnaireListDto
    {
        public List<QuestionnaireDto> Questionnaires { get; set; } = new();
        public List<ListOrderItem> OrderItems { get; set; } = new();
    }
}
