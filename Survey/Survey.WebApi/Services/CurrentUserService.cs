using Survey.Application.Common.Interfaces;
using Survey.Domain.Entities;

namespace Survey.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        // TODO: Read User and Roles from JWT
        public CurrentUser User { get; set; } = new CurrentUser { Id = 1 };
    }
}
