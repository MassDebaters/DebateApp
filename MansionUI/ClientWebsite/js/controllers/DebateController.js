app.controller('DebateController', ['$scope', '$interval', '$routeParams','userservice','debateservice', function($scope, $interval, $routeParams, userservice, debateservice) {

  $scope.debate = debateservice;
  $scope.debate.setDebateId($routeParams.id);
  $scope.debate.getDebate();
  console.log($scope.debate.getDebateId());
  $scope.user = userservice;
  
  

  $interval(function () {
    debateservice.getDebate();
}, 1000);

  




}]);