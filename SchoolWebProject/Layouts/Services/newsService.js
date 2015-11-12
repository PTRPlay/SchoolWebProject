myApp.factory('newsService', ['$http', function ($http) {
    return $http.get("api/announcements").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);

