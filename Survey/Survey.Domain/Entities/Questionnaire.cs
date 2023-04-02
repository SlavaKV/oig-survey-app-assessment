namespace Survey.Domain.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int StatusId { get; private set; } // TODO: Exclude
        public QuestionnaireStatus Status { get; private set; }
        public int UserId { get; set; } // TODO: change this the easiest way

        private Questionnaire()
        {
        }

        public static Questionnaire Create()
        {
            return new Questionnaire
            {
                StatusId = QuestionnaireStatus.Concept.Id
            };
        }

        public void ChangeStatus()
        {
            var newStatus = Status.GetNext();
            if (newStatus is not null)
            {
                StatusId = newStatus.Id;
            }
        }

        public QuestionnaireStatus NextStatus => Status.GetNext();
        public string NextStatusName
        {
            get
            {
                var status = Status.GetNext();
                if (status is not null)
                {
                    return status.Name;
                }
                return string.Empty;
            }
        }

        // TODO: Change into User instead UserId
        public bool IsUpdatable(int userId)
        {
            return UserId == userId;
        }
    }
}
