using System.ComponentModel.DataAnnotations;

namespace KnowledgeTestingService.API.Models.Authentication
{
    public class UserRegisterModel
    {
        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}