namespace Core.Application.Interfaces
{
    public interface IUserService
    {
        Task SaveUser(string username, string password);
    }
}
