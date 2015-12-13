myApp.factory('scheduleService', ['$http',function ($http) {
    return {
        getSchedule: function (teacher, group) {
            return $http.get('api/schedule/?teacher=' + teacher+"&group="+group).success(function (data) {
                return data;
            }).error(function (data) {
                return data;
            });
        },

        sendSchedule:function(schedules){
            return $http.post('api/schedule', schedules).success(function (data) {
                return data;
            }).error(function (data) {
                return data;
            });
        }   
    }
}]);
