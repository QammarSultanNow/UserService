using Dapper;
using System.Data;
using WebApplication1.Context;
using WebApplication1.Interface;

namespace WebApplication1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext contet)
        {
            _context = contet;
        }

      

        public async Task<int> AddUserData(User user , string avatarName)
        {
            var procedureName = "sp_AddUserInformation";

            var parameters = new DynamicParameters(user);
            parameters.Add("id", user.id, DbType.String);
            parameters.Add("name", user.name, DbType.String);
            parameters.Add("createdAt", user.createdAt, DbType.String);
            parameters.Add("avatar", avatarName, DbType.String);

            using (var connection = _context.CreateConnection())
            {
               var result = await  connection.ExecuteAsync(procedureName,  parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
