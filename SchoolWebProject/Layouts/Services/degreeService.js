myApp.factory('degree', ['$http', function ($http) {
    return $http.get("api/degree").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);