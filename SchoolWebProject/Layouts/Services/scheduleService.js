myApp.service('schedule', ['$http', function ($http) {
    return $http.get('api/schedule')
	.success(function (data) {
	    return data;
	})
	.error(function (data) {
	    return data;
	})
}]);
