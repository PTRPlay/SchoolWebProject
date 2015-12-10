myApp.factory('errorService', ['$http', function ($http) {
    return{
        postError: function (message) {
            return $http.post("api/error/" + message);
        }
    }
}]);