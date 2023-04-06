using Survey.Domain.Enums;

namespace Survey.Domain.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public QuestionnaireStatus Status { get; private set; } = QuestionnaireStatus.Concept;

        public int UserId { get; set; } // TODO: change this the easiest way

        public void SetDates(DateTime startDateTime, DateTime endDateTime)
        {
            if(startDateTime.AddHours(1) > endDateTime)
            {
                throw new Exception("The end date and time are at least one hour after the beginning date and time");
            }

            StartDateTime= startDateTime;
            EndDateTime= endDateTime;
        }

        public bool IsClosable(CurrentUser currentUser)
        {
            return UserId == currentUser.Id && Status == QuestionnaireStatus.Active;
        }

        public void Close(CurrentUser currentUser)
        {
            if (IsClosable(currentUser))
            {
                ChangeStatus(QuestionnaireStatus.Completed);
            }
        }

        public bool IsScheduled(CurrentUser currentUser)
        {
            if (StartDateTime > DateTime.Now && Status == QuestionnaireStatus.Concept)
            {
                if (currentUser.IsSystem)
                {
                    return true;
                }
                else
                {
                    return UserId == currentUser.Id;
                }
            }
            else
            {
                return false;
            }
        }

        public void Schedule(CurrentUser currentUser)
        {
            if (IsScheduled(currentUser))
            {
                ChangeStatus(QuestionnaireStatus.Scheduled);
            }
        }

        public bool IsUpdatable(CurrentUser currentUser)
        {
            return UserId == currentUser.Id &&
                (Status == QuestionnaireStatus.Concept || Status == QuestionnaireStatus.Scheduled);
        }

        private void ChangeStatus(QuestionnaireStatus newStatus)
        {
            if (
                (Status == QuestionnaireStatus.Concept && newStatus == QuestionnaireStatus.Scheduled) ||
                (Status == QuestionnaireStatus.Scheduled && newStatus == QuestionnaireStatus.Active) ||
                (Status == QuestionnaireStatus.Active && newStatus == QuestionnaireStatus.Completed) 
                )
            {
                Status = newStatus;
            }
            else
            {
                throw new Exception($"Cannot set Status {newStatus.ToString()} the previously one is {Status.ToString()}");
            }
        }

        //-----------------------------------------------------------------------------------------------

        // Use this method only for DB seed. Shouldn't be calld according to business rules
        public void SetStatus(QuestionnaireStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
