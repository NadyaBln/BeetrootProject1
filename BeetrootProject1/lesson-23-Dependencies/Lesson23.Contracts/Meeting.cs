using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson23.Contracts
{
    public class Meeting
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public User Creator { get; set; }

        public List<User> Partisipants { get; set; }

        public Room Room { get; set; }
    }
}
