myApp.factory('groups', ['$http', function ($http) {
    return $http.get('api/groups')
	.success(function (data) {
	    return data.get;
	})
	.error(function (data) {
	    return data;
	})

}]);