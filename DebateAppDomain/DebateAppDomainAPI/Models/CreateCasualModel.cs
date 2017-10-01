using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateAppDomainAPI.Models
{
    public class CreateCasualModel
    {
        public UserModel u;
        public string Topic { get; set; }
        public string Category { get; set; }
        public string Opener { get; set; }
    }
}
