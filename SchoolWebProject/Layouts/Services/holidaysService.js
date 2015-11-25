myApp.factory('holidays', ['$http', function ($http){
	return $http.get('api/holidays')
	.success(function (data) {
		return data;
	})
	.error (function (data) {
	    return data;
	})

}]);


