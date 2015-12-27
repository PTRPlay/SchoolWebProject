myApp.controller('ScheduleDirectiveController', ['$scope', 'teachersService', function ($scope, teachersService) {

    var days = [{ day: 'Понелілок', color: '#E9E9E9' }, { day: 'Вівторок', color: '#F7F5F3' }, { day: 'Середа', color: '#E9E9E9' }, { day: 'Четвер', color: '#F7F5F3' }, { day: 'Пятниця', color: '#E9E9E9' }];
    var DAY_NUMBER = 6;
    var LESSON_NUMBER = 8;
    var FULL_NAME_SPACES = 3;

    $scope.AddEvent = function () {
        //if (window.currentUser.Role == "Admin") {
            $(".editableTD").dblclick(function () {
                var cell = $(this);
                var OriginalContent = cell.text();
                if (OriginalContent.split(" ").length > FULL_NAME_SPACES) {
                    OriginalContent = "";
                }
                cell.text("");
                cell.addClass("cellEditing");
                var select = document.createElement("SELECT");
                var HtmlElement = ModifieTeacher(cell,select);

                HtmlElement.onchange = function () {
                    var index = this.selectedIndex;
                    var text = this.options[index].text;
                    cell[0].removeChild(cell[0].childNodes[0]);
                    cell[0].textContent = text;
                    cell[0].classList.remove("cellEditing");
                };

                HtmlElement.onmouseleave = function () {
                    cell[0].removeChild(cell[0].childNodes[0]);
                    cell[0].textContent = OriginalContent;
                    cell[0].classList.remove("cellEditing");
                }

                cell.children().first().focus();
            });
        //}
    };

   

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

    function ModifieTeacher(cell,select) {
        select.classList.add("cellEditing")

        teachersService.getTeachers().success(function (data) {
            var teachers = "";
            for (var element in data) {
                teachers += "<option>" + data[element].FirstName + " " + data[element].MiddleName + " " + data[element].LastName + "</option>";
            }
            select.innerHTML = teachers;
            cell.append(select);
        })
        return select;
    }

    function ModifieGroup(cell,select){

    }

}])