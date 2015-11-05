myApp.factory('teacher', ['$http', function ($http) {
    return $http.get('api/teacher/{id}')
	.success(function (data) {
	    return data.get;
	})
	.error(function (data) {
	    return data;
	})

}]);