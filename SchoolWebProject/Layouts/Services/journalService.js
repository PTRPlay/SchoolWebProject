myApp.factory('markService', ['$http', function ($http) {
    return $http.get("api/mark").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);
