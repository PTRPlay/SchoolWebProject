myApp.controller('ScheduleDirectiveController', ['$scope',function ($scope) {

    var days = [{ day: 'Понелілок', color: '#E9E9E9' }, { day: 'Вівторок', color: '#F7F5F3' }, { day: 'Середа', color: '#E9E9E9' }, { day: 'Четвер', color: '#F7F5F3' }, { day: 'Пятниця', color: '#E9E9E9' }];
    var DAY_NUMBER = 6;
    var LESSON_NUMBER = 8;

    $scope.AddEvent = function () {
        if (window.currentUser.Role == "Admin") {
            $(".editableTD").dblclick(function () {
                var OriginalContent = $(this).text();
                $(this).addClass("cellEditing");
                $(this).html("<input type='text' value='" + OriginalContent + "'/>");
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
        }
    };

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
                                id: item.Id
                            }
                        }));
                    }
                });
            },
            select: function (e, ui) {
                $('#hidden_id').val('' + ui.item.id);
            },
        });

        $('#TeacherFilter').click(function () {
            $(this).val('');
        })
    }

    $scope.CreateSchedule = function () {
        var dom = document.getElementById('Schedule');
        for (var i = 1; i < DAY_NUMBER; i++) {
            var day = document.createElement("tbody");
            day.setAttribute('style','background:'+days[i-1].color);
            var tr = document.createElement('tr');
            tr.innerHTML = "<td rowspan='" + 7 + "'>" + days[i-1].day + "</td><td>" + 1 + "</td><td id=" + i + "teacher1 class='editableTD'></td><td id=" + i + "subject1 class='editableTD'></td><td id=" + i + "room1 class='editableTD'></td>";
            day.appendChild(tr);
            for (var j = 2; j < LESSON_NUMBER; j++) {
                var tr = document.createElement('tr');
                var numbercell = "<td>"+j+"</td>";
                var teachercell = "<td class='editableTD' id = '" + i + "teacher" + j + "'></td>";
                var subjectcell = "<td class='editableTD' id = '" + i + "subject" + j + "'></td>";
                var roomcell = "<td class='editableTD' id = '" + i + "room" + j + "'></td>";
                tr.innerHTML = numbercell + teachercell + subjectcell + roomcell;
                day.appendChild(tr);
            }
            dom.appendChild(day);
        };
    }

}])