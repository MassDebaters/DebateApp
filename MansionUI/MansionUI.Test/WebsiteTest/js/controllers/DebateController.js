app.controller('DebateController', ['$scope', function($scope) {
  
$scope.pageinfo= 
  
  { 
 title: "Mansion", 
 series_img: "http://free-icon-rainbow.com/i/icon_04533/icon_045330_256.png", 
 description: "In Debate", 
datetime: new Date(2017, 9, 1, 00, 00, 00, 00) 

};
  
$scope.debates =
 [
  
 {"Teams":[{"RoundsWon":0,"WinningsShare":0.5,"Opener":{"PostID":0,"CommentText":"Not yet...","TimeStamp":"0001-01-01T00:00:00","UserID":0,"MaxLength":0,"Team":null,"Astros":0,"Votes":0,"Sources":null,"DebateID":0},"TeamLimit":0,"Members":[{"HasVoted":false,"HasResponded":false,"UserID":0,"Username":"DarwinsBeard","Password":"Fogey","Astros":100,"YourDebates":[],"Notifications":null}],"ReadyToStart":false},{"RoundsWon":0,"WinningsShare":0.5,"Opener":null,"TeamLimit":0,"Members":null,"ReadyToStart":false}],"Round":[],"GameStage":false,"DebateTopic":"Are we any good at this?","DebateCategory":"Grown Up Problems","Audience":[],"TurnLength":60,"PostLength":200,"SourcesRequired":0,"NumberOfRounds":5,"Pot":0,"SetupStage":true},

 {"Teams":[{"RoundsWon":0,"WinningsShare":0.5,"Opener":{"PostID":0,"CommentText":"Not yet...","TimeStamp":"0001-01-01T00:00:00","UserID":0,"MaxLength":0,"Team":null,"Astros":0,"Votes":0,"Sources":null,"DebateID":0},"TeamLimit":0,"Members":[{"HasVoted":false,"HasResponded":false,"UserID":0,"Username":"DarwinsBeard","Password":"Fogey","Astros":100,"YourDebates":[],"Notifications":null}],"ReadyToStart":false},{"RoundsWon":0,"WinningsShare":0.5,"Opener":null,"TeamLimit":0,"Members":null,"ReadyToStart":true}],"Round":[],"GameStage":true,"DebateTopic":"Best Anime?","DebateCategory":"Fantasy","Audience":[],"TurnLength":120,"PostLength":100,"SourcesRequired":1,"NumberOfRounds":8,"Pot":200,"SetupStage":false},

 {"Teams":[{"RoundsWon":0,"WinningsShare":0.5,"Opener":{"PostID":0,"CommentText":"Not yet...","TimeStamp":"0001-01-01T00:00:00","UserID":0,"MaxLength":0,"Team":null,"Astros":0,"Votes":0,"Sources":null,"DebateID":0},"TeamLimit":0,"Members":[{"HasVoted":false,"HasResponded":false,"UserID":0,"Username":"DarwinsBeard","Password":"Fogey","Astros":100,"YourDebates":[],"Notifications":null}],"ReadyToStart":false},{"RoundsWon":0,"WinningsShare":0.5,"Opener":null,"TeamLimit":0,"Members":null,"ReadyToStart":false}],"Round":[],"GameStage":false,"DebateTopic":"Love is overrated","DebateCategory":"Grown Up Problems","Audience":[],"TurnLength":120,"PostLength":300,"SourcesRequired":0,"NumberOfRounds":5,"Pot":250,"SetupStage":true},

  
 ];



}]);