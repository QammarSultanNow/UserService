namespace WebApplication1.Interface
{
    public interface IUserRepository
    {
        Task<int> AddUserData(User user, string avatarName);
    }
}
