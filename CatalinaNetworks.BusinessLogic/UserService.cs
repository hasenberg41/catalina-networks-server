using CatalinaNetworks.Core.Models;
using CatalinaNetworks.Core.Repositories;
using CatalinaNetworks.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalinaNetworks.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository) => _repository = repository;


    }
}
