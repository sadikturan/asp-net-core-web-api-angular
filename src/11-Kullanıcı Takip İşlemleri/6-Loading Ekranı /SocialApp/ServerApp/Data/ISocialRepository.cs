using System.Collections.Generic;
using System.Threading.Tasks;
using ServerApp.Models;

namespace ServerApp.Data
{
    public interface ISocialRepository
    {
        void Add<T>(T entity) where T:class;
        void Delete<T>(T entity) where T:class;
        Task<bool> SaveChanges();
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers(UserQueryParams userParams);
        Task<bool> IsAlreadyFollowed(int followerUserId,int userId);
    }
}