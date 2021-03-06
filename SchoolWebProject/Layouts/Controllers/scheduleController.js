﻿myApp.controller('scheduleController', ['$scope', '$http', 'scheduleService', 'permissionService', function ($scope, $http, scheduleService, permissionService) {

    $scope.teacherFilter = {
        name: "Введіть Прізвище для пошуку",
        id: 0
    };
    $scope.group = {};

    var DAY_NUMBER = 6;
    var LESSON_NUMBER = 8;

    $scope.showSchedule = function () {
        clearSchedule();
        scheduleService.getSchedule($scope.teacherFilter.id,$scope.group.Id).success(function (data) {
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
        for (var day = 1; day < DAY_NUMBER; day++)
            for (var order = 1; order < LESSON_NUMBER; order++) {
                var teacher = document.getElementById(day + 'teacher' + order).textContent.split(" ");
                var subject = document.getElementById(day + 'subject' + order).textContent;
                var room = document.getElementById(day + 'room' + order).textContent
                if ((teacher != '') && (subject != '') && (room != '')) {
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
                            groupId: group.Id,
                            classRoom: room
                        }
                        )
                }
            }
        scheduleService.sendSchedule(schedules).success(function () {
            $scope.showSchedule();
        });
    }

    $scope.GetScheduleFromJson = function (evt) {
        var file = evt.files;
        var reader = new FileReader();

        reader.onload = (function (theFile) {
            return function (e) {
                var schedule = JSON.parse(e.target.result);
                $http.post('api/schedule', schedule);
            };
        })(file[0]);
        reader.readAsText(file[0]);
    }

    $scope.fileSchedule = function () {
        return permissionService.fileSchedule();
    }

    $scope.showEditSchedule = function () {
        return permissionService.showEditSchedule();
    }


    function clearSchedule() {
        for (var i = 1; i < DAY_NUMBER; ++i) {
            for (var j = 1; j < LESSON_NUMBER; j++) {
                var TeacherId = i + 'teacher' + j;
                var SubjectId = i + 'subject' + j;
                var RoomId = i + 'room' + j;
                document.getElementById(TeacherId).innerHTML = "";
                document.getElementById(SubjectId).innerHTML = "";
                document.getElementById(RoomId).innerHTML = "";
            }
        }
    }

     $scope.InitializeAutocomplate = function () {
        $('#TeacherFilter').autocomplete({
            source: function (request, response) {
                var filter = request.term;
                $.ajax(
                {
                    url: 'api/teacher?filter=' + filter,
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.FirstName + " " + item.MiddleName + " " + item.LastName,
                                value: item.FirstName + " " + item.MiddleName + " " + item.LastName,
                                id:item.Id
                            }
                        }));
                    }
                });
            },
            select: function (e, ui) {
                $scope.teacherFilter.id = ui.item.id;
            },
        });
     }

     $scope.Clear = function(){
         $scope.teacherFilter.name="";
         $scope.teacherFilter.id = 0;
         $scope.showSchedule();
     }

}]);

