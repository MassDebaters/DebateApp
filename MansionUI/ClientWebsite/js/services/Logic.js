app.factory('logic', ['$http', function($http) {
  return $http.get('http://ec2-18-221-110-13.us-east-2.compute.amazonaws.com/DomainApi/api/Debates/GetAllDebate')
         .success(function(data) {
           return data;
         })
         .error(function(data) {
           return data;
         });
}]);