myApp.factory('pupils', ['$http', function ($http) {
    //TODO: get pupils function whitch takes a parameters
    return $http.get('api/pupils')
	.success(function (data) {
	    return data.get;
	})
	.error(function (data) {
	    return data;
	})

}]);