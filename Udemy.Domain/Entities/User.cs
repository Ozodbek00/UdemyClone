using Udemy.Domain.Enums;

namespace Udemy.Domain.Entities
{
    public class User: Auditable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
