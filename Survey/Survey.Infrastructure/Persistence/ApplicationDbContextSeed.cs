using Microsoft.EntityFrameworkCore;
using Survey.Domain.Entities;
using Survey.Domain.Enums;

namespace Survey.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task Init(ApplicationDbContext context)
        {
            if (context.Database.IsSqlServer())
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();
            }
        }

        public static async Task Seed(ApplicationDbContext context)
        {
            await SeedQuestionnaire(context);
        }

        private static async Task SeedQuestionnaire(ApplicationDbContext context)
        {
            var questionnaireTime = DateTime.Now;
            if (!context.Questionnaires.Any())
            {
                questionnaireTime = DateTime.Now;
                var q1 = new Questionnaire
                {
                    Name = "Q from User1 in status 'Concept' dates in past",
                    UserId = 1
                };
                q1.SetDates(questionnaireTime.AddDays(-10), questionnaireTime.AddDays(-9));
                context.Questionnaires.Add(q1);

                questionnaireTime = DateTime.Now;
                var q2 = new Questionnaire
                {
                    Name = "Q from User1 in status 'Concept' NOW beween dates",
                    UserId = 1
                };
                q2.SetDates(questionnaireTime.AddDays(-3), questionnaireTime.AddDays(10));
                context.Questionnaires.Add(q2);

                questionnaireTime = DateTime.Now;
                var q3 = new Questionnaire
                {
                    Name = "Q from User1 in status 'Concept' dates in future",
                    UserId = 1
                };
                q3.SetDates(questionnaireTime.AddDays(3), questionnaireTime.AddDays(10));
                context.Questionnaires.Add(q3);

                questionnaireTime = DateTime.Now;
                var q4 = new Questionnaire
                {
                    Name = "Q 2 from User1 in status 'Concept' dates in future",
                    UserId = 1
                };
                q4.SetDates(questionnaireTime.AddDays(3), questionnaireTime.AddDays(10));
                context.Questionnaires.Add(q4);

                questionnaireTime = DateTime.Now;
                var q5 = new Questionnaire
                {
                    Name = "Q from User1 in status 'Sheduled' dates in future",
                    UserId = 1
                };
                q5.SetDates(questionnaireTime.AddDays(3), questionnaireTime.AddDays(10));
                q5.SetStatus(QuestionnaireStatus.Scheduled);
                context.Questionnaires.Add(q5);

                questionnaireTime = DateTime.Now;
                var q6 = new Questionnaire
                {
                    Name = "Q 2 from User1 in status 'Sheduled' dates in future",
                    UserId = 1
                };
                q6.SetDates(questionnaireTime.AddDays(3), questionnaireTime.AddDays(10));
                q6.SetStatus(QuestionnaireStatus.Scheduled);
                context.Questionnaires.Add(q6);

                questionnaireTime = DateTime.Now;
                var q7 = new Questionnaire
                {
                    Name = "Q from User1 in status 'Active' NOW between dates",
                    UserId = 1
                };
                q7.SetDates(questionnaireTime.AddDays(-5), questionnaireTime.AddDays(10));
                q7.SetStatus(QuestionnaireStatus.Active);
                context.Questionnaires.Add(q7);

                questionnaireTime = DateTime.Now;
                var q8 = new Questionnaire
                {
                    Name = "Q 2 from User1 in status 'Active' NOW between dates",
                    UserId = 1
                };
                q8.SetDates(questionnaireTime.AddDays(-5), questionnaireTime.AddDays(10));
                q8.SetStatus(QuestionnaireStatus.Active);
                context.Questionnaires.Add(q8);

                questionnaireTime = DateTime.Now;
                var q9 = new Questionnaire
                {
                    Name = "Q from User1 in status 'Completed' dates in past",
                    UserId = 1
                };
                q9.SetDates(questionnaireTime.AddDays(-12), questionnaireTime.AddDays(-3));
                q9.SetStatus(QuestionnaireStatus.Completed);
                context.Questionnaires.Add(q9);

                questionnaireTime = DateTime.Now;
                var q10 = new Questionnaire
                {
                    Name = "Q 2 from User1 in status 'Completed' dates in past",
                    UserId = 1
                };
                q10.SetDates(questionnaireTime.AddDays(-12), questionnaireTime.AddDays(-3));
                q10.SetStatus(QuestionnaireStatus.Completed);
                context.Questionnaires.Add(q10);

                questionnaireTime = DateTime.Now;
                var q11 = new Questionnaire
                {
                    Name = "Q from User2 in status 'Completed' dates in past",
                    UserId = 2
                };
                q11.SetDates(questionnaireTime.AddDays(-12), questionnaireTime.AddDays(-3));
                q11.SetStatus(QuestionnaireStatus.Completed);
                context.Questionnaires.Add(q11);

                questionnaireTime = DateTime.Now;
                var q12 = new Questionnaire
                {
                    Name = "Q from User2 in status 'Active' NOW between dates",
                    UserId = 2
                };
                q12.SetDates(questionnaireTime.AddDays(-12), questionnaireTime.AddDays(3));
                q12.SetStatus(QuestionnaireStatus.Active);
                context.Questionnaires.Add(q12);

                questionnaireTime = DateTime.Now;
                var q13 = new Questionnaire
                {
                    Name = "Q from User2 in status 'Scheduled' dates in future",
                    UserId = 2
                };
                q13.SetDates(questionnaireTime.AddDays(1), questionnaireTime.AddDays(3));
                q13.SetStatus(QuestionnaireStatus.Scheduled);
                context.Questionnaires.Add(q13);

                questionnaireTime = DateTime.Now;
                var q14 = new Questionnaire
                {
                    Name = "Q from User2 in status 'Concept' dates",
                    UserId = 2
                };
                q14.SetDates(questionnaireTime.AddDays(1), questionnaireTime.AddDays(3));
                q14.SetStatus(QuestionnaireStatus.Concept);
                context.Questionnaires.Add(q14);

                await context.SaveChangesAsync();
            }
        }
    }
}
