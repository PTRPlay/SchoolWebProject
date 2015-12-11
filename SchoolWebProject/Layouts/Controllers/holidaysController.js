myApp.controller('holidaysController', function ($scope, $http, holidaysService) {
    holidaysService.getHolidays()
        .success(function (data) {
            $scope.holidays = [];
            $scope.daysOff = [];
            if (data != null) {
                for (i = 0; i < data.length; i++) {
                    //data[i].StartDay = $scope.dateParser(data[i].StartDay);
                    //data[i].EndDay = $scope.dateParser(data[i].EndDay);
                    var equal = false;
                    if (data[i].StartDay == data[i].EndDay)
                    {
                        equal = true;
                    }
                    data[i].StartDay = new Date(data[i].StartDay);
                    data[i].EndDay = new Date(data[i].EndDay);
                    if (equal) {
                        $scope.daysOff.push(data[i]);
                    }

                    if (!equal) {
                        $scope.holidays.push(data[i]);
                    }
                }
            }
        });

    $scope.dateParser = function (date) {
        var dateParseTempValue = date.slice(0, 10).split('/');
        return new Date(dateParseTempValue[0]);

    }

    $scope.addNewDayOff = function (dayOff) {
        if (dayOff != null) {
            dayOff.StartDay = new Date(dayOff.StartDay);
            dayOff.StartDay.setHours(dayOff.StartDay.getHours() + 3);
            dayOff.EndDay = dayOff.StartDay;
            if (dayOff.Id != null) {
                $http.post("api/holidays/" + dayOff.Id, dayOff);
                window.location.reload("/#/holidays");
            }
            else {
                var newDayOff = { Id: null, Name: dayOff.Name, StartDay: dayOff.StartDay, EndDay: dayOff.StartDay }
                $http.post("api/holidays/", newDayOff);
                window.location.reload("/#/holidays")
            }
        }
    }

    $scope.addNewHolidays = function (holidays) {
        if (holidays != null) {
            holidays.StartDay = new Date(holidays.StartDay);
            holidays.EndDay = new Date(holidays.EndDay);
            holidays.StartDay.setHours(holidays.StartDay.getHours() + 3);
            holidays.EndDay.setHours(holidays.EndDay.getHours() + 3);
            if (holidays.Id != null) {
                $http.post("api/holidays/" + holidays.Id, holidays);
                window.location.reload("/#/holidays");
            }
            else {
                var newHolidays = { Id: null, Name: holidays.Name, StartDay: holidays.StartDay, EndDay: holidays.EndDay }
                $http.post("api/holidays/", newHolidays);
                window.location.reload("/#/holidays")
            }
        }
    }

    $scope.dateChanged = function (e) {
        e = e || window.event;
        var el = (e.srcElement || e.target).parentNode.parentNode;
        el.style.background = "red";
    }

});
