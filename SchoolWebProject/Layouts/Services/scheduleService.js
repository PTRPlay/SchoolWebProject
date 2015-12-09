myApp.service('scheduleService', ['$http',function ($http,$scope) {
    return function ($scope) {
        $scope.AddEvent = function () {
            $("td").dblclick(function () {
                var OriginalContent = $(this).text();
                $(this).addClass("cellEditing");
                $(this).html("<input type='text' value='" + OriginalContent + "' />");
                $(this).children().first().focus();

                $(this).children().first().keypress(function (e) {
                    if (e.which == 13) {
                        var newContent = $(this).val();
                        $(this).parent().text(newContent);
                        $(this).parent().removeClass("cellEditing");
                    }
                });

                $(this).children().first().blur(function () {
                    $(this).parent().text(OriginalContent);
                    $(this).parent().removeClass("cellEditing");
                });
            });
        };

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
                                    label: item.FirstName + " " + item.MiddleName + " " + " " + item.LastName,
                                    value: item.FirstName + " " + item.MiddleName + " " + " " + item.LastName
                                }
                            }));
                        }
                    });
                }
            });
        }


        var obj = {};
        return obj;
    }

}]);

myApp.factory('scheduleServiceForjournal', ['$http', function ($http) {
    return {
        getAllSchedule:function()
        {
            return  $http.get('api/schedule/').success(function (data) {
                return data;
            }).error(function (data) {
                return data;
            });
        }
    }
}]);