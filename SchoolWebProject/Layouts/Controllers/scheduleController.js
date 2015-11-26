myApp.controller('scheduleController',['$scope','$http','schedule',function ($scope,$http,schedule) {
    schedule.InitializeAutocomplate();
    $scope.showSchedule = function () {
        var filter = (document.getElementById('Filter').value).replace(/\s+/g, '');
        var fullSchedule = schedule.loadSchedule(filter)
    }
}]);
