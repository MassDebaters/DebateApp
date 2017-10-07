app.controller('LoginController', ['$scope', function($scope) {
  
  $scope.ud = UserDatabase;
  $scope.success = false;
  $scope.escape_link = "";
 
	$scope.login ={
    username: "",
    password: ""
  };
  
  $scope.signin = function(){
    var name = $scope.login.username;
    var pass = $scope.login.password;
    
    $scope.success = $scope.ud.session_start(name, pass, $scope.ud);
    if(!$scope.success){
     	$scope.login.username = "";
      $scope.login.password = "";
      $scope.escape_link = "#/";
    }
    
  };
  
  $scope.signout = function(){
    if($scope.ud.user != "Robot")
      $scope.escape_link = "#/login";
   	else
      $scope.escape_link = "#/";
    $scope.ud.session_stop($scope.ud);
  }
  
  
} ] );