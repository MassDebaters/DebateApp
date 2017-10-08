app.controller('LobbyAliveController', ['$scope', 'logic', function($scope, logic) {
  
  
  logic.success(function(data) {
    $scope.debates = data;
  });
  
  
}]);