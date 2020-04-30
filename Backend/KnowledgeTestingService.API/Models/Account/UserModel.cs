namespace KnowledgeTestingService.API.Models.Account
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public long? LockoutEnd { get; set; }
    }
}