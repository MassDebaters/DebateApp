app.factory("debateService", ['$http', function($http) { 

  return $http.get('http://localhost:5000/api/values') 
            .success(function(data) { 
              return data; 
            }) 
            .error(function(err) { 
              return err; 
            }); 
}]);