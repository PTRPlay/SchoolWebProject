myApp.factory('teachers', ['$http', function ($http){
	return $http.get('api/teachers')
	.success(function (data) {
		return data.get;
	})
	.error (function (data) {
	    return data;
	})
}]);