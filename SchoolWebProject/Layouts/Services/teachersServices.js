myApp.factory('teachers', ['$http', function ($http) {
    return $http.get('api/teacher').success(function (data) {
        return data;
    });

}]);