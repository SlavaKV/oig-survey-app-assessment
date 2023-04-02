using Survey.Domain.Enums;

namespace Survey.Domain.Entities
{
    public sealed class QuestionnaireStatus
    {
        private QuestionnaireStatus()
        {
        }

        private QuestionnaireStatus(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public static QuestionnaireStatus Concept = new QuestionnaireStatus(Dom.QuestionnaireStatus.Concept, "Concept");
        public static QuestionnaireStatus Scheduled = new QuestionnaireStatus(Dom.QuestionnaireStatus.Scheduled, "Scheduled");
        public static QuestionnaireStatus Active = new QuestionnaireStatus(Dom.QuestionnaireStatus.Active, "Active");
        public static QuestionnaireStatus Completed = new QuestionnaireStatus(Dom.QuestionnaireStatus.Completed, "Completed");

        public QuestionnaireStatus GetNext()
        {
            switch (this.Id)
            {
                case Dom.QuestionnaireStatus.Concept: return Scheduled;
                case Dom.QuestionnaireStatus.Scheduled: return Active;
                case Dom.QuestionnaireStatus.Active: return Completed;
            }
            return null;
        }
    }
}
