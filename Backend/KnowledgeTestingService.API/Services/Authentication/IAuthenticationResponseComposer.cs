using KnowledgeTestingService.Authentication.DataTransferObjects;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnowledgeTestingService.API.Services.Authentication
{
    public interface IAuthenticationResponseComposer
    {
        IActionResult ComposeForLogIn(Result<TokenDto> logInResult);
        IActionResult ComposeForRegister(IEnumerable<IdentityError> registrationResult);
    }
}