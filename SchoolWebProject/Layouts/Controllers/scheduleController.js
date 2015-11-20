myApp.controller('scheduleController', function ($scope, schedule) {
    schedule.success(function (data) {
        $scope.schedule = data;
    })
});
