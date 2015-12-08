myApp.controller('scheduleController',['$scope','$http','scheduleService',function ($scope,$http,scheduleService) {
    $scope.service = scheduleService($scope);
    $scope.showSchedule = function () {
        var teacherFilter = (document.getElementById('TeacherFilter').value).replace(/\s+/g, '');
        var subjectFilter = (document.getElementById('SubjectFilter').value).replace(/\s+/g+/-/, '');
        if (teacherFilter == "") teacherFilter ="null";
        var filter = teacherFilter;
        filter += " " + subjectFilter;
        if (subjectFilter == "") filter += "null";
        var fullSchedule = loadSchedule(filter);
    }

    loadSchedule = function (filter) {
        return $http.get('api/schedule/?filter=' + filter)
        .success(function (data) {
            clearSchedule();
            for (var i = 0; i < data.length; ++i) {
                var idTeacher = data[i].DayOfTheWeek  + "teacher" + data[i].OrderNumber;
                var idSubject = data[i].DayOfTheWeek  + "subject" + data[i].OrderNumber;
                document.getElementById(idTeacher).innerHTML = data[i].Teacher.FirstName + " " + data[i].Teacher.MiddleName + " " + data[i].Teacher.LastName;
                document.getElementById(idSubject).innerHTML = data[i].Subject.Name;
            }
        })
        .error(function (data) {
            return data;
        })
    }

    function clearSchedule() {
        for (var i = 1; i < 6; ++i) {
            for (var j = 1; j < 7; j++) {
                var TeacherId = i + 'teacher' + j;
                var SubjectId = i + 'subject' + j;
                document.getElementById(TeacherId).innerHTML = "";
                document.getElementById(SubjectId).innerHTML = "";
            }
        }
    }

}]);

