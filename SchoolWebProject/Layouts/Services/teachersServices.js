myApp.factory('teachers', ['$http', function ($http){
	return $http.get('api/teacher')
	.success(function (data) {
		return data.get;
	})
	.error (function (data) {
	    return data;
	})

﻿}]);