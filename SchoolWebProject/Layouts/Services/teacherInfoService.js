myApp.factory('teacher', ['$http', function ($http) {
    return $http.get('api/teacher/{id}')
	.success(function (data) {
	    return data.get;
	})
	.error(function (data) {
	    return data;
	})

}]);

myApp.factory('categories', ['$http', function ($http) {
    return $http.get("api/teachercategory").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);

myApp.factory('degree', ['$http', function ($http) {
    return $http.get("api/teacherdegree").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);
