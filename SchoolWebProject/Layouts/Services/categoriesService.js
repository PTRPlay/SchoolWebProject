﻿myApp.factory('categories', ['$http', function ($http) {
    return $http.get("api/teachercategory").success(function (data) {
        return data;
    }).error(function (data) {
        return data;
    });
}]);