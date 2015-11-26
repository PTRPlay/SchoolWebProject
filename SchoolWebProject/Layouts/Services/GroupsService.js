myApp.factory('groupsService', ['$http', function ($http) {
    return{
        getGroups: function () {
            return $http.get('api/groups')
            .success(function (data) {
                return data.get;
            })
            .error(function (data) {
                return data;
            })
        }
    }
}]);