myApp.service('scheduleService', ['$http', function ($http) {
    this.loadSchedule = function (filter) {
        return $http.get('api/schedule/?filter='+filter)
        .success(function (data) {
            clearSchedule();
            for (var i = 0; i < data.length; ++i) {
                var idTeacher = data[i].DayOfTheWeek - 1 + "teacher" + data[i].OrderNumber;
                var idSubject = data[i].DayOfTheWeek - 1 + "subject" + data[i].OrderNumber;
                document.getElementById(idTeacher).innerHTML = data[i].Teacher.FirstName + " " + data[i].Teacher.MiddleName + " " + data[i].Teacher.LastName;
                document.getElementById(idSubject).innerHTML = data[i].Subject.Name;
            }
        })
        .error(function (data) {
            return data;
        })
    }

    this.getAllSchedule = function () {
        return $http.get('api/schedule/')
        .success(function (data) {
            return data;
        })
        .error(function (data) {
            return data;
        })
    }

    function clearSchedule() {
        for (var i = 0; i < 5; ++i) {
            for (var j = 1; j < 7; j++) {
                var TeacherId = i + 'teacher' + j;
                var SubjectId = i + 'subject' + j;
                document.getElementById(TeacherId).innerHTML = "";
                document.getElementById(SubjectId).innerHTML = "";
            }
        }
    }
    this.InitializeAutocomplate = function () {
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
                                label: item.FirstName + " " + item.MiddleName + " " + " " + item.LastName,
                                value: item.FirstName + " " + item.MiddleName + " " + " " + item.LastName
                            }
                        }));
                    }
                });
            }
        });

    }
}]);