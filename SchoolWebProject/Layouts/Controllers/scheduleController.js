var some = 2;
var isShowScheduleInvoked = false;
function GetList(id) {
    if (document.getElementById('editCheckBox').checked && isShowScheduleInvoked)
        alert(id);
}

myApp.controller('scheduleController', ['$scope', '$http', 'scheduleService', function ($scope, $http, scheduleService) {
    scheduleService.InitializeAutocomplate();
    $scope.IsValidUser = window.currentUser.Role == "Admin";
    $scope.IsEnableEdit = false;
    $scope.showSchedule = function () {
        isShowScheduleInvoked = true;
        var teacherFilter = (document.getElementById('TeacherFilter').value).replace(/\s+/g, '');
        var subjectFilter = (document.getElementById('SubjectFilter').value).replace(/\s+/g+/-/, '');
        if (teacherFilter == "") teacherFilter ="null";
        var filter = teacherFilter;
        filter += " " + subjectFilter;
        if (subjectFilter == "") filter += "null";
        var fullSchedule = scheduleService.loadSchedule(filter)
    }
    
}]);
