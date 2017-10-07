var app = angular.module("MansionApp", ['ngRoute']);

app.config(function ($routeProvider) { 
  $routeProvider 
    .when('/', { 
      controller: 'LobbyController', 
      templateUrl: 'views/lobby.html' 
    })
    .when('/login',{
    controller: 'LoginController',
    templateUrl: 'views/login.html'
  })
  	 .when('/:id',{
    	controller: 'DebateController',
		  templateUrl: 'views/debate.html'
  })
    .otherwise({ 
      redirectTo: '/' 
    }); 
});