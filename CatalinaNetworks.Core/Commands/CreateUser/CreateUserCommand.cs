using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalinaNetworks.Core.Models;
using MediatR;

namespace CatalinaNetworks.Core.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; } = "";

        public string? UniqueUrlName { get; set; }

        public Photos? Photos { get; set; }
    }
}
