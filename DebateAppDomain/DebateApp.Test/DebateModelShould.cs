using DebateAppDomainAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DebateAppDomain.Test
{
    public class DebateModelShould
    {
        private readonly ITestOutputHelper _output;
        private DebateModel dmut;
        public DebateModelShould(ITestOutputHelper Output)
        {
            _output = Output;
            dmut = new DebateModel();
        }
        [Fact]
        public void SendOutASerializedCasualDebate()
        {
            _output.WriteLine(JsonConvert.SerializeObject(dmut.Expose()));
        }
    }
}
