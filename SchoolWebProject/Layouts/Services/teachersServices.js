myApp.factory('teachersService', ['$http', function ($http) {
    return {
        getTeachers: function () {
            return $http.get('api/teacher')
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                return data;
            })
        }
    }
}]);


