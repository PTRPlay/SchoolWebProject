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
        },
        getTeacherById: function (id) {
            return $http.get('api/teacher/' + id)
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                return data;
            })
        }
    }
}]);


