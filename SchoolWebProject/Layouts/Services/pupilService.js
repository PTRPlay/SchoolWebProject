myApp.factory('pupils', ['$http', function ($http) {
    return $http.get('api/pupil').success(function (data) {
        return data;
    });

}]);