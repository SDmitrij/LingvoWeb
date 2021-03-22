using MediatR;

namespace LingvoWeb.Security.User.Login
{
    public class LoginQuery : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}