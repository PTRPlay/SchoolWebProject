myApp.factory('categories', ['$http', function ($http) {
    return $http.get("Kolya will input directory").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);