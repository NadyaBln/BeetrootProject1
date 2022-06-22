using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson23.Contracts
{
    public class Room
    {
        public string Name { get; set; }

        public List<Meeting> Meetings { get; set; }
    }
}
