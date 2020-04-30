using System;

namespace KnowledgeTestingService.API.Models.Authentication
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}