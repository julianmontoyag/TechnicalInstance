using TechnicalInstance.Data.Entities;

namespace TechnicalInstance.Data.Repositories.Contract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmail(string userEmail);
    }
}
