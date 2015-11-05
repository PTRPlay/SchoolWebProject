<<<<<<< HEAD
myApp.factory('teachers', ['$http', function ($http){
	return $http.get('api/teachers')
	.success(function (data) {
		return data.get;
	})
	.error (function (data) {
	    return data;
	})
=======
﻿myApp.factory('teachers', ['$http', function ($http) {
    return $http.get('Home/GetTeachers')
       .success(function (data) {
           return data;
       })
       .error(function (data) {
           return data;
       });
>>>>>>> 6cbb462dd287b01d260ba7bcd93ba068bcac2345
}]);