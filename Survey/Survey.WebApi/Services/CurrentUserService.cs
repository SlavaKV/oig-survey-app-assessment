using Survey.Application.Common.Interfaces;

namespace Survey.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        // TODO: Read User and Roles from JWT
        public int UserId { get; set; } = 1;
    }
}
