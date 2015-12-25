myApp.controller('holidaysController', function ($scope, $state, $stateParams, $http, holidaysService) {
    holidaysService.getHolidays()
        .success(function (data) {
            $scope.holidays = [];
            $scope.daysOff = [];
            $scope.semestr1 = [];
            $scope.semestr2 = [];
            if (data != null) {
                for (i = 0; i < data.length; i++) {
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
                        if (data[i].Name == "Semestr1") {
                            $scope.semestr1.push(data[i]);
                        }
                        else if (data[i].Name == "Semestr2") {
                            $scope.semestr2.push(data[i]);
                        }
                        else $scope.holidays.push(data[i]);
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
                $http.post("api/holidays/" + dayOff.Id, dayOff)
                            .success(function () {
                                $state.go('holidays', { start: $stateParams.start }, { reload: true });
                            });
            }
            else {
                var newDayOff = { Id: null, Name: dayOff.Name, StartDay: dayOff.StartDay, EndDay: dayOff.StartDay }
                $http.post("api/holidays/", newDayOff)
                            .success(function () {
                                $state.go('holidays', { start: $stateParams.start }, { reload: true });
                            });
            }
        }
        $state.go('holidays', { start: $stateParams.start }, { reload: true });
    }

    $scope.addNewHolidays = function (holidays) {
        if (holidays != null) {
            holidays.StartDay = new Date(holidays.StartDay);
            holidays.EndDay = new Date(holidays.EndDay);
            holidays.StartDay.setHours(holidays.StartDay.getHours() + 3);
            holidays.EndDay.setHours(holidays.EndDay.getHours() + 3);
            if (holidays.Id != null) {
                $http.post("api/holidays/" + holidays.Id, holidays)
                            .success(function () {
                                $state.go('holidays', { start: $stateParams.start }, { reload: true });
                            });
            }
            else {
                var newHolidays = { Id: null, Name: holidays.Name, StartDay: holidays.StartDay, EndDay: holidays.EndDay }
                $http.post("api/holidays/", newHolidays)
                            .success(function () {
                                $state.go('holidays', { start: $stateParams.start }, { reload: true });
                            });
            }
        }
    }

    $scope.ChangeEndDay = function (event) {
        event = event || window.event;
        var el = (event.srcElement || event.target).parentNode.parentNode.parentNode;
        var startDate = el.querySelector("#startDay");
        var endDate = el.querySelector("#endDay");
        startDate.max = endDate.value;
        endDate.min = startDate.value;
        }

    $scope.deleteHolidays = function (id) {
        if (id != null) {
            $http.delete("api/holidays/"+id)
            .success(function () {
                $state.go('holidays', { start: $stateParams.start }, { reload: true });
            });
        }
    };


    $scope.dateChanged = function (e) {
        e = e || window.event;
        var el = (e.srcElement || e.target).parentNode.parentNode.parentNode;
        el.style.background = "#E6F6FF";
    }

});
