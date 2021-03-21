using LingvoWeb.Models;

namespace LingvoWeb.Security
{
    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}
