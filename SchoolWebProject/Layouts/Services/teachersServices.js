myApp.factory('teachers', ['$http', function ($http){
	return $http.get('api/teacher')
	.success(function (data) {
		return data;
	})
	.error (function (data) {
	    return data;
	})

}]);


myApp.factory('teachersByCategory', ['$http', function ($http){
    return $http.get('api/teachercategory/{Id}')
	.success(function (data) {
	    return data;
	})
	.error (function (data) {
	    return data;
	})

}]);
