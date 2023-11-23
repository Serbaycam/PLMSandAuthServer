namespace AuthIdentity.Core.DTOs
{
	public class AuthIdentityUserDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Education { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
