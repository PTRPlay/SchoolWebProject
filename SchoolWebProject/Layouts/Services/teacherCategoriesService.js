myApp.factory('teacherCategories', ['$http', function ($http) {
    return $http.get("api/teachercategory/").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);


myApp.factory('teachersByCategory', ['$http', function ($http) {
    return $http.get('api/teachercategory/{Id}')
	.success(function (data) {
	    return data;
	})
	.error(function (data) {
	    return data;
	})

}]);