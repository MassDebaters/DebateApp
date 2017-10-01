var app = angular.module("MansionApp", ['ngRoute']);

app.config(function ($routeProvider) { 
  $routeProvider 
    .when('/', { 
      controller: 'LobbyController', 
      templateUrl: 'views/lobby.html' 
    })
  	 .when('/:id',{
    	controller: 'DebateController',
		  templateUrl: 'views/debate.html'
  })
    .otherwise({ 
      redirectTo: '/' 
    }); 
});