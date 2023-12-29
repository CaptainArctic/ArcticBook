using ArcticBook.Models.DTO;

namespace ArcticBook.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(Login model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(Registration model);
    }
}
