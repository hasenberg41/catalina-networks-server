using CatalinaNetworks.Core.Models;
using CatalinaNetworks.Core.Models.Paggination;

namespace CatalinaNetworks.Core.Services
{
    public interface IUserService
    {
        Task<UsersPage> Get(QuerryParameters parameters);
    }
}
