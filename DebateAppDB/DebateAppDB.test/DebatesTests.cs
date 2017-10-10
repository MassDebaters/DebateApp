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
            var actual = JsonObject.SelectToken(@"d.debateTopic").Value<string>();
            var expected = "this is a debate";

            Assert.NotNull(debates);
            Assert.IsType<DebateModel>(debates);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void AddDebates()
        {
            var newDebate = "{\"d\":{\"teams\":[{\"members\":[{\"hasVoted\":false,\"hasResponded\":false,\"userID\":70,\"username\":\"testgirl5\",\"password\":null,\"astros\":100}],\"roundsWon\":0,\"winningsShare\":0.5,\"opener\":{\"commentText\":\"lyes\",\"timeStamp\":\"10 / 10 / 2017 3:54:50 PM\",\"userID\":70},\"teamLimit\":1,\"readyToStart\":true},{\"members\":[],\"roundsWon\":0,\"winningsShare\":0.5,\"opener\":null,\"teamLimit\":1,\"readyToStart\":false}],\"round\":[],\"pot\":10,\"debate_ID\":1,\"_gamestage\":false,\"setupStage\":true,\"completed\":false,\"awardsDisbursed\":false,\"debateTopic\":\"this is a debate\",\"debateCategory\":\"debates\",\"audience\":[],\"turnLength\":60,\"postLength\":200,\"sourcesRequired\":0,\"numberOfRounds\":5,\"currentPotShareL\":0.0,\"currentPotShareR\":0.0,\"status\":\"Setup Stage.\",\"roundStart\":0,\"lastGet\":0,\"winner\":null,\"loser\":null}}";
            var Debate = JsonConvert.DeserializeObject<DebateModel>(newDebate);
            Assert.NotNull(Debate);
            debate.AddDebate(Debate);

            var actual = debate.GetDebate(4);

            Assert.NotNull(actual.d);
            Assert.IsType<DebateModel>(actual);
        }
    }
}
