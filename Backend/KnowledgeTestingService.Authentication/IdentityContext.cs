using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeTestingService.Authentication
{
    public sealed class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions<IdentityContext> contextOptions)
            : base(contextOptions)
        {
            this.Database.EnsureCreated();
        }
    }
}