namespace Survey.Domain.Entities
{
    public class CurrentUser
    {
        public int Id { get; set; } = 1;
        public bool IsSystem { get; set; } = false; // Put 'true' to be a System User
    }
}
