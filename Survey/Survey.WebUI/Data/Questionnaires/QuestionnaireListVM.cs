namespace Survey.WebUI.Data.Questionnaires
{
    public class QuestionnaireListVM
    {
        public List<QuestionnaireListItemVM> Questionnaires { get; set; } = new();
        public List<ListOrderItem> OrderItems { get; set; } = new();
    }
}
