using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angular_app_tutorial.Domain
{
    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Day { get; set; }
        public bool Remainder { get; set; }
    }
}
