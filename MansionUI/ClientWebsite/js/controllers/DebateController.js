app.controller('DebateController', ['$scope', '$routeParams', function($scope, $routeParams) {
  
  $scope.ud = UserDatabase;
  $scope.dbd = DebateDatabase; 
  $scope.debate_index = $routeParams.id;
  $scope.datetime = Date.now();
  //$scope.dbd.set_index($scope.debate_index, $scope.dbd);
  
  var i = $scope.debate_index;
  
  var bot = function(debate_id, player, database){
    if(database.has_members(i,player,database))
      return database.player_name(i,player,database);
    else return "bot";
  }
  
  $scope.player_one = bot(i,0,$scope.dbd);
  $scope.player_two = bot(i,1,$scope.dbd);
  
  $scope.score_one = $scope.dbd.rounds_won(i,0,$scope.dbd);
  $scope.score_two = $scope.dbd.rounds_won(i,1,$scope.dbd);

  $scope.a = false;
  $scope.b = false;
  $scope.a_string = "undepressed";
  $scope.b_string = "undepressed";
  
  $scope.depressed = function(message){
    if($scope.a)
      $scope.a = !$scope.a;
    else if(message=='a')
      $scope.a = !$scope.a;
    if($scope.b)
      $scope.b = !$scope.b;
    else if (message=='b')
      $scope.b = !$scope.b;
    
    if($scope.a)
      $scope.a_string = "depressed";
    else
      $scope.a_string = "undepressed";
    
    if($scope.b)
      $scope.b_string = "depressed";
    else
      $scope.b_string = "undepressed";
  };

 
  



}]);