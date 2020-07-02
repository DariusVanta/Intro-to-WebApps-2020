using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intro_to_WebApps.Models
{
    public class OrganizerItem
    {
        public long Id { get; set; }
        public string Tasks { get; set; }
        public bool IsComplete { get; set; }
    }
}
