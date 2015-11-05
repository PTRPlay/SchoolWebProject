myApp.factory('pupils', ['$http', function ($http) {
    return $http.get('api/pupils')
	.success(function (data) {
	    return data.get;
	})
	.error(function (data) {
	    return data;
	})

}]);