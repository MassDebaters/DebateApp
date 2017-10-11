app.controller('DebateController', ['$scope', '$interval', '$routeParams','userservice','debateservice', function($scope, $interval, $routeParams, userservice, debateservice) {
  
    debateservice.setDebateId($routeParams.id);
    debateservice.getDebate();
    $scope.count = 0;
    $scope.debate = {};
    $scope.user = {};
    $scope.user.loggedIn = userservice.loggedIn();
  
    $scope.user.location = 4;
    $scope.user.debater = true;
    $scope.user.voter = false;
    $scope.user.vote = false;
    $scope.stage = {};
    $scope.stage.toSendOne = "";
    $scope.stage.toSendTwo = "";
    $scope.toSend = "";
    $scope.stage.panelOne = "";
    $scope.stage.panelTwo = "";
    
  
    var promise;
  
  /////////////////////////////////////////////////////////
    if($scope.user.loggedIn){
      $scope.user.username = userservice.getUsername();
      $scope.user.accountId = userservice.getAccountId();
    }
    else{
      $scope.user.username = "Robot";
      $scope.user.accountId = 0;
    }
  /////////////////////////////////////////////////////////
  $scope.decideLocation = function(){
    
    if($scope.playerOne == $scope.user.username)
      $scope.user.location = 1;
    else if($scope.playerTwo == "bot" && $scope.user.loggedIn)
      $scope.user.location = 2;
    else if($scope.user.loggedIn)
      $scope.user.location = 3;
  
    if($scope.user.location < 3)
      $scope.user.debater = true;
    else
      $scope.user.debater = false; 
    console.log("debater: "+$scope.user.debater);
  }
  
  $scope.joinDebate = function(){
    if($scope.user.location === 2){
      debateservice.setOpener($scope.user.username+" joins the debate");
      debateservice.joinTeam();
    }
  }
  
  $scope.post = function(){
    if($scope.user.location === 1)
      $scope.stage.toSendOne += $scope.toSend+"\n";
    else if($scope.user.location === 2)
      $scope.stage.toSendTwo += $scope.toSend+"\n";  
    
    $scope.toSend = "";
  }
  
  $scope.finalize = function(){
    if(location == 1){
      debateservice.setComment($scope.stage.toSendOne);
      $scope.stage.toSendOne = '';
    }
    else if(location == 2){
      debateservice.setComment($scope.stage.toSendTwo);
      $scope.stage.toSendTwo = '';
    }
    debateservice.post();
  }
  /////////////////////////////////////////////////////////
  
    $scope.start = function(){
      promise = 
        $interval(function () {
          $scope.debate = debateservice.getData().d;
          
          $scope.teamOne = $scope.debate.teams[0];
          $scope.playerOne = $scope.teamOne.members[0].username;
          $scope.teamTwo = $scope.debate.teams[1];
          if($scope.teamTwo.members[1] == null) $scope.playerTwo = "bot";
          else $scope.playerTwo = $scope.teamTwo.members[1].username;
          $scope.decideLocation();
          
          $scope.audience = $scope.debate.audience;
          $scope.posts = $scope.debate.round;
          debateservice.getDebate();
          console.log("location:" +$scope.user.location+" "+$scope.count++);
        }, 4000);
    }
  
    $scope.stop = function(){
      $interval.cancel(promise);
    }
  
    $scope.$on('$destroy', function(){
      $scope.stop();
    })
  
  /////////////// End of Setup Functions /////////////////////
  ////////////////// Begin Action Functions //////////////////
  // (posting) if your name matches player 1 or player 2, then 
  // 1. your messages will append to the according panel. 
  // 2. panel is $scope.panelOne or $scope.panelTwo
  // 3. there is a location variable
  // 4. I'll use debateservce post function
  // when a finalize button is pressed, if location 1 or 2. ng-show="debater"
  // - refresh panel once outside interval
  
  // (voting) if your location is 3, and you are logged in,
  // 1. two buttons will be made available ng-show="voter", vote left vote right
  // 2. I will use debateservice to post the vote on click
  
  //(join debate or join audience) a function will decide your
  // location
  // if you're logged in,
    // if you made the room, 
      // will become location 1, 
      // automatically joined on creation
    // if you did not make the room, and first to join room
      // will become location 2
      // will launch join debate 
    // if you did not make the room, and playertwo is not "bot" 
      // location will become 3
      // join audience 
  
    //(start debate) if playerTwo is not "bot"
    // will show a start button ng-show="gamestart"
  
    //(openers) all posts, openers, toSend,
    // openers, allPosts, toSend
    // post function(message, location)
      // append message to model
      // append message to toSend
    // finalize ()
      // send post to logic
    // displayPosts()
      // opener + posts for both sides 
  
    
  
    
  
  
  
    $scope.start();
  }]);