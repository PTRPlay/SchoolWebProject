myApp.factory('subjects', ['$http', function ($http) {
    return $http.get("api/subjects").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);