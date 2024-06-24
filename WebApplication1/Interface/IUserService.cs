namespace WebApplication1.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUserInformation();
        Task<string> DownloadAvatar(string avatarUrl);
    }
}
