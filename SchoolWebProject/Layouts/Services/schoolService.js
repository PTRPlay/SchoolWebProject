myApp.factory('schoolService', ['$http', function ($http) {
    return{
        loadSchool: function () {
            return $http.get("api/schools/1").success(function (data) {
                return data;
            }).error(function (data) {
                return data;
            });
        }
    }
}]);