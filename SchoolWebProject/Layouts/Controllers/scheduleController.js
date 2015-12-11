myApp.controller('scheduleController',['$scope','$http','scheduleService',function ($scope,$http,scheduleService) {
    $scope.teacherFilter = "Kolia";
    $scope.group = "7-А";

    $scope.showSchedule = function () {
        clearSchedule();
        scheduleService.getSchedule($scope.teacherFilter,$scope.group).success(function (data) {
            clearSchedule();
            for (var i = 0; i < data.length; ++i) {
                var idTeacher = data[i].DayOfTheWeek + "teacher" + data[i].OrderNumber;
                var idSubject = data[i].DayOfTheWeek + "subject" + data[i].OrderNumber;
                var idRoom = data[i].DayOfTheWeek + "room" + data[i].OrderNumber;
                document.getElementById(idTeacher).innerHTML = data[i].Teacher.FirstName + " " + data[i].Teacher.MiddleName + " " + data[i].Teacher.LastName;
                document.getElementById(idSubject).innerHTML = data[i].Subject.Name;
                document.getElementById(idRoom).innerHTML = data[i].ClassRoom;
            }
        })
        .error(function (data) {
            return data;
        })
    }

    $scope.Edit = function (group) {
        var schedules = [];
        for (var day = 1; day < 6; day++)
            for (var order = 1; order < 8; order++) {
                var teacher = document.getElementById(day + 'teacher' + order).textContent.split(" ");
                var subject = document.getElementById(day + 'subject' + order).textContent;
                schedules.push(
                    {
                        OrderNumber: order,
                        DayOfTheWeek: day,
                        teacher: {
                            FirstName: teacher[0],
                            MiddleName: teacher[1],
                            LastName: teacher[2]
                        },
                        subject: {
                            Name: subject
                        },
                        group: group
                    }
                    )
            }
        $http.post('api/schedule', schedules);
    }


    function clearSchedule() {
        for (var i = 1; i < 6; ++i) {
            for (var j = 1; j < 7; j++) {
                var TeacherId = i + 'teacher' + j;
                var SubjectId = i + 'subject' + j;
                var RoomId = i + 'room' + j;
                document.getElementById(TeacherId).innerHTML = "";
                document.getElementById(SubjectId).innerHTML = "";
                document.getElementById(RoomId).innerHTML = "";
            }
        }
    }

}]);

