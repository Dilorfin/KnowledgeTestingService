using System;

namespace KnowledgeTestingService.Authentication.DataTransferObjects
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}