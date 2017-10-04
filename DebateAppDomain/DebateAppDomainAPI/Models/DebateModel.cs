using DebateApp.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DebateAppDomainAPI.Models
{
    public class DebateModel
    {
        public int Debate_id;

        public string DebateString => JsonConvert.SerializeObject(d);
        public Debate d { get; set; }
        public DebateModel(Debate de)
        {
            d = de;
        }

    }
}

