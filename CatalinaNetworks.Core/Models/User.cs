using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalinaNetworks.Core.Models
{
    public class User
    {
        public int Id { get; }

        public string Name { get; set; } = null!;

        public string? UniqueUrlName { get; set; }

        public Photos? Photos { get; set; }
    }
}
