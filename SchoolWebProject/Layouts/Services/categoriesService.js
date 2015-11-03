myApp.factory('categories', ['$http', function ($http) {
    return $http.get("api/teacherscategory").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);