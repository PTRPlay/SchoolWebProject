myApp.controller('scheduleController',['$scope','$http','scheduleService',function ($scope,$http,scheduleService) {
    scheduleService.InitializeAutocomplate();
    $scope.showSchedule = function () {
        var teacherFilter = (document.getElementById('TeacherFilter').value).replace(/\s+/g, '');
        var subjectFilter = (document.getElementById('SubjectFilter').value).replace(/\s+/g+/-/, '');
        if (teacherFilter == "") teacherFilter ="null";
        var filter = teacherFilter;
        filter += " " + subjectFilter;
        if (subjectFilter == "") filter += "null";
        var fullSchedule = scheduleService.loadSchedule(filter)
    }
}]);
