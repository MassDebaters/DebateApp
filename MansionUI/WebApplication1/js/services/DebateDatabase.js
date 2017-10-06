var DebateDatabase = {
  debates:
 [
	{"Teams":[{"RoundsWon":0,"WinningsShare":0.5,"Opener":{"PostID":0,"CommentText":"Not yet...","TimeStamp":"0001-01-01T00:00:00","UserID":0,"MaxLength":0,"Team":null,"Astros":0,"Votes":0,"Sources":null,"DebateID":0},"TeamLimit":0,"Members":[{"HasVoted":false,"HasResponded":false,"UserID":0,"Username":"DarwinsBeard","Password":"Fogey","Astros":100,"YourDebates":[],"Notifications":null}],"ReadyToStart":false},{"RoundsWon":0,"WinningsShare":0.5,"Opener":null,"TeamLimit":0,"Members":null,"ReadyToStart":false}],"Round":[],"GameStage":false,"DebateTopic":"Are we any good at this?","DebateCategory":"Grown Up Problems","Audience":[],"TurnLength":60,"PostLength":200,"SourcesRequired":0,"NumberOfRounds":5,"Pot":0,"SetupStage":true},

 {"Teams":[{"RoundsWon":0,"WinningsShare":0.5,"Opener":{"PostID":0,"CommentText":"Not yet...","TimeStamp":"0001-01-01T00:00:00","UserID":0,"MaxLength":0,"Team":null,"Astros":0,"Votes":0,"Sources":null,"DebateID":0},"TeamLimit":0,"Members":[{"HasVoted":false,"HasResponded":false,"UserID":0,"Username":"DarwinsBeard","Password":"Fogey","Astros":100,"YourDebates":[],"Notifications":null}],"ReadyToStart":false},{"RoundsWon":0,"WinningsShare":0.5,"Opener":null,"TeamLimit":0,"Members":null,"ReadyToStart":true}],"Round":[],"GameStage":true,"DebateTopic":"Best Anime?","DebateCategory":"Fantasy","Audience":[],"TurnLength":120,"PostLength":100,"SourcesRequired":1,"NumberOfRounds":8,"Pot":200,"SetupStage":false},

 {"Teams":[{"RoundsWon":0,"WinningsShare":0.5,"Opener":{"PostID":0,"CommentText":"Not yet...","TimeStamp":"0001-01-01T00:00:00","UserID":0,"MaxLength":0,"Team":null,"Astros":0,"Votes":0,"Sources":null,"DebateID":0},"TeamLimit":0,"Members":[{"HasVoted":false,"HasResponded":false,"UserID":0,"Username":"DarwinsBeard","Password":"Fogey","Astros":100,"YourDebates":[],"Notifications":null}],"ReadyToStart":false},{"RoundsWon":0,"WinningsShare":0.5,"Opener":null,"TeamLimit":0,"Members":null,"ReadyToStart":false}],"Round":[],"GameStage":false,"DebateTopic":"Love is overrated","DebateCategory":"Grown Up Problems","Audience":[],"TurnLength":120,"PostLength":300,"SourcesRequired":0,"NumberOfRounds":5,"Pot":250,"SetupStage":true}
  
 ],
  
  has_members: function(debate_index, zero_or_one, dbd){
    is_null = dbd.debates[debate_index].Teams[zero_or_one].Members==null;
    return !is_null;
  },
  
  player_name: function(debate_index, zero_or_one, dbd){
    return dbd.debates[debate_index].Teams[zero_or_one].Members[0].Username;
  },
  
  rounds_won: function(debate_index, zero_or_one, dbd){
    return dbd.debates[debate_index].Teams[zero_or_one].RoundsWon;
  }
}