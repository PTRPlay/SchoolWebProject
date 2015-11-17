myApp.factory('diaryService', ['$http', function ($http) {
    return $http.get("api/diary/56").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);