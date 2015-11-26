myApp.service('scheduleService', ['$http', function ($http) {
    this.loadSchedule = function (filter) {
        return $http.get('api/schedule/?filter='+filter)
        .success(function (data) {
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
}]);