var UserDatabase = {
  user: "Robot",
  pass: "",
  logout_string: "play as guest",
  users: [
    {
      name:"Justin",
      password:"123",
      id:"1",
      astros: 100
    },
    {
      name:"Lenny",
      password:"456",
      id:"2",
      astros: 100
    },
    {
      name:"Greg",
      password:"789",
      id:"3",
      astros: 100
    }
  ],
  
  find_user: function(username, p, db){
    for (var i = 0; i < db.users.length; i++){
      if (db.users[i].name == username && db.users[i].password == p)
      	return db.users[i];
 		 }
  	  return 0;
		},
    
	session_stop: function(db){
    db.user = "Robot";
    db.pass = "";
    db.logout_string = "play as guest";
 	 },
    
  session_start: function(username, p, db){
    var u = db.find_user(username,p,db);
    if(u == 0){
      db.session_stop(db);
      return false;
    }
    else
      {
        db.user = u.name;
        db.pass = u.password;
        db.logout_string = "logout";
        return true;
      }
 	 }
  
};