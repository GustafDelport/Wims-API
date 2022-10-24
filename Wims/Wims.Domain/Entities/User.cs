using Wims.Domain.Interfaces;

namespace Wims.Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
