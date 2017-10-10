app.factory('logic', function($http, $q){
  var service = {};
  var baseUrl = 'http://ec2-18-221-110-13.us-east-2.compute.amazonaws.com/DomainApi/api/';
  var _command = '';
  var _finalUrl = '';
  var _id = '';
  var _postObject = null
  var _method = ''

  var makeUrl = function () {
    _finalUrl = baseUrl + _command + _id;
    return _finalUrl;
  }

  service.reset = function(){
    _command = '';
    _finalUrl = '';
    _id = '';
    _postObject = {};
  }

  service.setPost = function(postObject){
    _postObject = postObject;
  }

  service.getPost = function(){
    return _postObject;
  }

  service.setCommand = function(command){
    _command = command;
  }

  service.setMethod = function(method){
    _method = method;
  }

  service.getCommand = function(){
    return _command;
  }

  service.execute = function(){
    makeUrl();
    var deferred = $q.defer();
    
    $http({
      method: _method,
      url: _finalUrl,
      data: _postObject
    }).success(function(data){
      deferred.resolve(data);
    }).error(function(){
      deferred.reject('service.execute.get: There was in error ');
    })
    
    return deferred.promise;
  }

  return service;

});