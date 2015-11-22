﻿myApp.factory('diaryService', ['$http', function ($http) {

    return {
        getDiary: function (id, date) {
            return $http.get('api/diary/diary/' + id + '/' + date)
            .success(function (data) {
                return data.get;
            })
            .error(function (data) {
                return data;
            })
        }
    }

}]);