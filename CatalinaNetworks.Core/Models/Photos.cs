using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalinaNetworks.Core.Models
{
    public class Photos
    {
        public int UserId { get; set; }

        public string Large { get; set; } = null!;

        public string Small { get; set; } = null!;

    }
}
