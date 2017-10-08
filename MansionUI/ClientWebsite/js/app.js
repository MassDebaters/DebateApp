var app = angular.module("MansionApp", ['ngRoute']);

app.config(function ($routeProvider) { 
  $routeProvider 
    .when('/lobby', { 
      controller: 'LobbyController', 
      templateUrl: 'views/lobby.html' 
    })
    .when('/', { 
      controller: 'LobbyAliveController', 
      templateUrl: 'views/lobbyalive.html' 
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