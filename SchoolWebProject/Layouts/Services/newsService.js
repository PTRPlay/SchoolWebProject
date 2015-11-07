myApp.factory('newsService', ['$http', function ($http) {
    return $http.get("api/announcements").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);

myApp.factory('newsDetailService', ['$scope','$http', '$stateParams', function ($scope, $http, $stateParams) {
    return $http.get("api/announcements/id").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);