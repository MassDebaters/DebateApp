app.controller('LobbyController', ['$scope', '$interval', 'logic','userservice', function($scope, $interval, logic, userservice) {
  var getAllDebates = 'Debates/GetAllDebate';
  var createCasual = 'Debates/CreateCasual';
  
  // logicservice.success(function(data) { //I think this calls the service
  //   $scope.debates = data;
  // });
  $scope.new = {};
  $scope.new.debateName = "";
  $scope.new.debateTopic = "";
  $scope.new.debateCategory = "";
  $scope.new.debateOpener = "";
  $scope.chosen = {};
  $scope.chosen.debateId = '';
  $scope.debates = {};
  $scope.getAllDebates = function(){
    logic.reset();
    logic.setCommand(getAllDebates);
    logic.setMethod("GET");
    logic.execute().then(function(data){
      
      $scope.debates = data; // takes a second
      
    }, function(data){
      console.log(data);
    })
  }
  
  $scope.createCasualDebate = function(uId, top, cat, open){
    
    logic.reset();
    logic.setCommand(createCasual);
    logic.setMethod("POST");
    logic.setPost({
      UserID: uId,
      Topic: top,
      Category: cat,
      Opener: open
    });
    logic.execute();
  }
  
  $scope.createCasualDebateClick = function(){
    if(!userservice.loggedIn()){
      console.log("LobbyController: Not logged in");
      return;
    }
    $scope.createCasualDebate(
      userservice.getAccountId(),
      $scope.new.debateTopic,
      $scope.new.debateCategory,
      $scope.new.debateOpener
    );
  }

  $scope.enterDebate = function(index){
    $scope.chosen.debateId = $scope.debates[index].d.debate_ID;
  }

  
  //$scope.createCasualDebate(1, "Tap water is fantastic", "Health", "Tap water is full of toxins.");
  $interval(function () {
    $scope.getAllDebates();
}, 1000);

}]);