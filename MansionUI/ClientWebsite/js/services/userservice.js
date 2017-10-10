app.factory('userservice', ['logic',function(logic){

  // remembers everything given to it
  // AccountId, Username, Role, Astros
  var userservice = {}
  var _accountId = "";
  var _username = "";
  var _role = "";
  var _astros = "";
  var _userToSend = "";
  var _passToSend = "";
  var _loggedIn = false;

  var registerUser = "User/RegisterUser";
  var getUser = "User/GetUser/";

  userservice.setAccountId = function(accountId){_accountId = accountId;}
  userservice.setUsername = function(username){_username = username;}
  userservice.setPassword = function(password){_password = password}
  userservice.setRole = function(role){_role = role;}
  userservice.setAstros = function(astros){_astros = astros;}

  userservice.getAccountId = function(){return _accountId;}
  userservice.getPassword = function(){return _password;}
  userservice.getUsername = function(){return _username;}
  userservice.getRole = function(){return _role;}
  userservice.getAstros = function(){return _astros;}
  userservice.loggedIn = function(){return _loggedIn;}

  userservice.setUserToSend = function(toSend){_userToSend = toSend;}
  userservice.setPassToSend = function(toSend){_passToSend = toSend;}

  userservice.login = function(){
    logic.reset();
    logic.setCommand(getUser+_userToSend);
    logic.setMethod("GET");
    console.log("userservice: "+getUser+_userToSend);
    var p = logic.execute();
    p.then(function(data){
      _accountId = data.accountId;
      _username = data.username;
      _role = data.role;
      _astros = data.astros;
      if(_accountId)
        _loggedIn = true;
      else
        _loggedIn = false;
    });
    return p;
  }

  userservice.register = function(){
    logic.reset();
    logic.setCommand(registerUser);
    logic.setMethod("POST");
    logic.setPost({ Username: _userToSend, Password: _passToSend});
    var p = logic.execute();
    p.then(function(data){
      _accountId = data.accountId;
      _username = data.username;
      _role = data.role;
      _astros = data.astros;
      if(_accountId)
        _loggedIn = true;
      else
        _loggedIn = false;
    });
    return p;

  }

  userservice.logout = function(){
    _accountId = "";
    _username = "";
    _role = "";
    _astros = "";
    _userToSend = "";
    _passToSend = "";
    _loggedIn = false;
  }

  // how debate will display information
  // each debate object has user ids
  // it will need to get users from service, and display those objects

  return userservice;

}]);