app.controller('LoginController', ['$scope', 'userservice', function($scope, userservice) {

  $scope.username = "";
  $scope.password = "";

  $scope.login = function(){
    userservice.setUserToSend($scope.username);
    userservice.setPassToSend($scope.password);
    userservice.login().then(function(data){
      console.log("LoginController: login is "+userservice.loggedIn()); // would be undefined
      console.log(data);
    });
  }

  $scope.register = function(){
    userservice.setUserToSend($scope.username);
    userservice.setPassToSend($scope.password);
    userservice.register().then(function(data){
      console.log("LoginController: registered is "+userservice.loggedIn());
      console.log(data);
    });
  }

  $scope.logout = function(){
    userservice.logout();
  }
  // console.log("registering...");
  // $scope.username = "testgirl2";
  // $scope.password = "testpass2";
  // $scope.login();


}]);