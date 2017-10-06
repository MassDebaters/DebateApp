using DebateApp.Domain;

using System;
using Xunit;
using Xunit.Abstractions;

namespace DebateApp.Test
{
    public class DebateShould
    {
        private readonly ITestOutputHelper _output;
        public DebateShould(ITestOutputHelper Output)
        {
            _output = Output;
        }
        
    }
}
