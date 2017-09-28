using DebateApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateAppDomainAPI
{
    public class DbButler
    {
        public Debate GetDebate(int id)
        {
            var res = null;//http client sends get request with ID to db debate controller
            var d = .Deserialize(res);
        }
    }
}
