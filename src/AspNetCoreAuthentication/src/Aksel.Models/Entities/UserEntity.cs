namespace Aksel.Models.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}