using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalinaNetworks.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, int key) 
            : base($"Entity \"{name}\" ({key}) not found. ")
        { 
        
        }
    }
}
