app.directive('debateSummary', function() { 
  return { 
    restrict: 'E', 
    scope: { 
      debate: '=' 
    }, 
    templateUrl: 'js/directives/debateSummary.html' 
  }; 
});