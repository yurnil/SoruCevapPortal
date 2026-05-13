using Microsoft.AspNetCore.Http;

namespace SoruCevapPortal.API.DTOs
{
    public class UserUpdateDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile? ProfileImage { get; set; }
    }
}