app.factory('debateservice', ['logic','userservice',function(logic, userservice){

  var debateservice = {};
  var _getDebate = "Debates/GetDebate/"; // get GetDebate/id (to get the debate object)
  var _joinTeam = "Debates/JoinTeam"; // post JoinTeam(DebateID, username, Opener)
  var _joinAudience = "Debates/JoinAudience"; //post JoinAudience(DebateId, Username)
  var _startDebate = "Debates/StartDebate/"; // get StartDebate/id
  var _vote = "Debates/Vote"; // put Vote(UserId, DebateID, Team[bool])
  var _post = "Debates/Post"; // put Post(UserId, DebateID, Comment)

  // get user/id (might not need, since username is in debate object)

  var _debateId = '';
  var _pot = '';
  var _gameStage = false;
  var _setupStage = true;
  var _completed = false;
  var _awardsDisbursed = false;
  var _debateTopic = '';
  var _debateCategory = '';
  var _turnLength = '';
  var _postLength = '';
  var _sourcesRequired = '';
  var _numberOfRounds = '';
  var _currentPotShareL = '';
  var _currentPotShareR = '';
  var _status = '';
  var _roundStart = '';
  var _lastGet = '';
  var _winner = '';
  var _loser = '';

  var _audience = [];
  var _round = [];

  var _teamOnePlayers = []; //of objects
  var _teamOneRoundsWon = '';
  var _teamOneShare = '';
  var _teamOneSize = '';
  var _teamOneReady = false;

  var _teamTwoPlayers = [];
  var _teamTwoRoundsWon = '';
  var _teamTwoShare = '';
  var _teamTwoSize = '';
  var _teamTwoReady = false;

////////// end of general variables //////////

  var _opener = '';
  var _team = '';
  var _comment = '';

//////////// end of user specific vairables ///////

  
  debateservice.setDebateId = function(debateId){_debateId = debateId;}
  debateservice.setOpener = function(opener){_opener = opener};
  debateservice.setComment = function(comment){_comment = comment};

  debateservice.getDebateId = function(){return _debateId;}
///////end of getters and setters /////
  var readData = function(data){
    _pot = data.d.pot;
    _gameStage = data.d.gameStage;
    _setupStage = data.d.setupStage;
    _completed = data.d.completed;
    _awardsDisbursed = data.d.awardsDisbursed;
    _debateTopic = data.d.debateTopic;
    _debateCategory = data.d.debateCategory;
    _turnLength = data.d.turnLength;
    _postLength = data.d.postLength;
    _sourcesRequired = data.d.sourcesRequired;
    _numberOfRounds = data.d.numberOfRounds;
    _currentPotShareL = data.d.currentPotShareL;
    _currentPotShareR = data.d.currentPotShareR;
    _status = data.d.status;
    _roundStart = data.d.roundStart;
    _lastGet = data.d.lastGet;
    _winner = data.d.winner;
    _loser = data.d.loser;
  
    _audience = data.d.audience;
    _round = data.d.round;
  
    _teamOnePlayers = data.d.teams[0].members ;
    _teamOneRoundsWon = data.d.teams[0].roundsWon ;
    _teamOneShare = data.d.teams[0].winningsShare ;
    _teamOneSize = data.d.teams[0].teamLimit ;
    _teamOneReady = data.d.teams[0].readyToStart ;
    _teamTwoPlayers = data.d.teams[1].members ;
    _teamTwoRoundsWon = data.d.teams[1].roundsWon ;
    _teamTwoShare = data.d.teams[1].winningsShare ;
    _teamTwoSize = data.d.teams[1].teamLimit ;
    _teamTwoReady = data.d.teams[1].readyToStart ;
    
  }

  var useLogic = function(command, method, post){
    logic.reset();
    logic.setCommand(command);
    logic.setMethod(method);
    logic.setPost(post);
    var p = logic.execute();
    p.then(function(data){
      readData(data);
    }
      );
    return p;
  }
  
  debateservice.getDebate = function(){ // test
    logic.reset();
    logic.setCommand(_getDebate+_debateId);
    logic.setMethod("GET");
    var p = logic.execute();
    p.then(function(data){
      readData(data)
    }); // test 
    return p;
  }

  debateservice.joinTeam = function(){
    logic.reset();
    logic.setCommand(_joinTeam);
    logic.setMethod("POST");
    logic.setPost({
      DebateID: _debateId,
      username: userservice.getUsername(),
      Opener: _opener
    });
    var p = logic.execute();
    p.then(function(data){
      readData(data)
    });
    return p; 
  }

  debateservice.startDebate = function(){
    logic.reset();
    logic.setCommand(_startDebate+_debateId);
    logic.setMethod("GET");
    var p = logic.execute();
    p.then(function(data){
      readData(data)
    });
    return p;
  }

  debateservice.vote = function(){
    return useLogic(_vote, "PUT", {
      UserId: userservice.getAccountId(), 
      DebateID: _debateId,
      Team: _team});
  }

  debateservice.post = function(){
    return useLogic(_post, "PUT", {
      UserId: userservice.getAccountId(),
      DebateID: _debateId,
      Comment: _comment
    });
  }

  debateservice.joinAudience = function(){
    return useLogic(_post, "POST",{
      DebateID: _debateId,
      Username: userservice.getUsername()
    });
  }

  return debateservice;




}]);