myApp.factory('holidaysService', ['$http', function ($http) {
    return {
        getHolidays: function () {
            return $http.get('api/holidays')
            .success(function (data) {
                return data;
            })
            .error(function (data) {
                return data;
            })
        },

        getHolidaysByDate: function (date) {
            return $http.get('api/holidays/?date=' + date)
        .success(function (data) {
            return data;
        })
        .error(function (data) {
            return data;
        })
        }

    }
}]);


