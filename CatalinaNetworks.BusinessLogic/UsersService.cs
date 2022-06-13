using CatalinaNetworks.Core.Models;
using CatalinaNetworks.Core.Models.Paggination;
using CatalinaNetworks.Core.Repositories;
using CatalinaNetworks.Core.Services;

namespace CatalinaNetworks.BusinessLogic
{
    public class UsersService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UsersService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<User>> Get(QuerryParameters parameters)
        {
            return await _repository.Get(parameters);
        }
        // TODO: сделать остальные методы
    }
}
