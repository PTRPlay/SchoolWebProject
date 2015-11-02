myApp.factory('teachers', ['$http', function ($http) {
    return $http.get('Home/GetTeachers')
       .success(function (data) {
           return data;
       })
       .error(function (data) {
           return data;
       });
}]);