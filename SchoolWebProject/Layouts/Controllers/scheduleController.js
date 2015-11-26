myApp.controller('scheduleController',['$scope','$http','scheduleService',function ($scope,$http,scheduleService) {
    scheduleService.InitializeAutocomplate();
    $scope.showSchedule = function () {
        var filter = (document.getElementById('Filter').value).replace(/\s+/g, '');
        var fullSchedule = scheduleService.loadSchedule(filter)
    }
}]);
