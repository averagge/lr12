using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr12
{
    public class Tasks
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Ststus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
