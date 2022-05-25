using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalinaNetworks.DataBase.Entities
{
    public class Photos
    {
        public int UserId { get; set; }

        [MaxLength(50)]
        public string Large { get; set; } = null!;

        [MaxLength(50)]
        public string Small { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
