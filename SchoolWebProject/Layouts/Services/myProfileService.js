myApp.factory('myProfileService', ['$http', function ($http) {
    return {
        getUser: function (id) {
            return $http.get('api/user/' + id)
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                return data;
            })
        }
    }
}]);