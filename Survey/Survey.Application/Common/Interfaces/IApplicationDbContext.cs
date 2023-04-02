using Microsoft.EntityFrameworkCore;

namespace Survey.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Questionnaire> Questionnaires { get; set; }
        DbSet<QuestionnaireStatus> QuestionnaireStatuses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
