using DebateAppDB.dbRest.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DebateAppDB.test
{
    public class DebatesTests
    {
        private DebateModel debate;

        public DebatesTests()
        {
            debate = new DebateModel();
        }

        [Fact]
        public void GetAllDebates()
        {
            var debates = debate.GetAllDebates();

            Assert.NotEmpty(debates);
            Assert.IsType<List<DebateModel>>(debates);
        }

        [Fact]
        public void GetDebate()
        {
            var debates = debate.GetDebate(1);

            var ModelToJson = JsonConvert.SerializeObject(debates);
            var JsonObject = JObject.Parse(ModelToJson);
            var actual = JsonObject.SelectToken(@"d.debateTopic");//.Value<string>();
            var expected = "this is a debate";

            Assert.NotNull(debates);
            Assert.IsType<DebateModel>(debates);
            Assert.Equal(actual, expected);
        }
    }
}
