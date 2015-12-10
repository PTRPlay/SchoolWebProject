myApp.factory('scheduleService', ['$http',function ($http) {
    return {
        getSchedule: function (teacher, group) {

            return $http.get('api/schedule/?teacher=' + teacher+"&group="+group).success(function (data) {
                return data;
            }).error(function (data) {
                return data;
            });
        }
    }
}]);
