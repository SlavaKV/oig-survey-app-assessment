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
            await SeedStatuses(context);
            await SeedQuestionnaire(context);
        }

        private static async Task SeedStatuses(ApplicationDbContext context)
        {
           
            if (!context.QuestionnaireStatuses.Any())
            {
                await context.QuestionnaireStatuses.AddRangeAsync(
                    QuestionnaireStatus.Concept,
                    QuestionnaireStatus.Scheduled,
                    QuestionnaireStatus.Active,
                    QuestionnaireStatus.Completed);
                await context.SaveChangesAsync();
            }
            /**/
        }

        private static async Task SeedQuestionnaire(ApplicationDbContext context)
        {
            if (!context.Questionnaires.Any())
            {
                var questionnaireTime = DateTime.Now;
                var questionnaire1 = Questionnaire.Create();
                questionnaire1.Name = "Here is questionnaire from User1 in status 'Concept'";
                questionnaire1.StartDateTime = questionnaireTime;
                questionnaire1.EndDateTime = questionnaireTime.AddHours(1);
                questionnaire1.UserId = 1;

                var questionnaire2 = Questionnaire.Create();
                questionnaire2.Name = "Here is questionnaire from other User in status 'Concept'";
                questionnaire2.StartDateTime = questionnaireTime;
                questionnaire2.EndDateTime = questionnaireTime.AddHours(1);
                questionnaire2.UserId = 2;

                await context.Questionnaires.AddAsync(questionnaire1);
                await context.SaveChangesAsync();

                await context.Questionnaires.AddAsync(questionnaire2);
                await context.SaveChangesAsync();
            }
        }
    }
}
