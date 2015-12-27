myApp.factory('modifieCellService', ['$http', 'teachersService', 'subjectsService', function ($http, teachersService, subjectsService) {
    return {
        modifieTeacherCell: function (cell, select) {
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
        },
        modifieGroupCell: function (cell, select) {
            select.classList.add("cellEditing")

            subjectsService.getSubjects().success(function (data) {
                var groups = "";
                for (var element in data) {
                    groups += "<option>" + data[element].Name + "</option>";
                }
                select.innerHTML = groups;
                cell.append(select);
            })
            return select;
        },

        modifieRoomCell: function (cell, select) {
            select.classList.add("cellEditing");
            $.get("api/Room", function (data) {
                var rooms = "";
                for (var element in data) {
                    rooms += "<option>" + data[element] + "</option>";
                }
                select.innerHTML = rooms;
                cell.append(select);
            })
            return select;
        }

    }
}]);