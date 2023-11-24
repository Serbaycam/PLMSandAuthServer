using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AuthIdentity.Core.Entities
{
    public class AuthIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int? Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Education { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
