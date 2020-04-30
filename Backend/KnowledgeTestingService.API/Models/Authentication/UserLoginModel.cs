using System.ComponentModel.DataAnnotations;

namespace KnowledgeTestingService.API.Models.Authentication
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}