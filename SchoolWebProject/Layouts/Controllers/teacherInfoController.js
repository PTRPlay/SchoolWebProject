myApp.controller('teacherInfoController', ['$scope', 'teacher', function ($scope, teachers) {
    teachers.success(function (data) {
        /*$scope.getTeacher = function () {
            var id = document.URL.split("?")[1].split("=")[1];
            //var teachers = JSON.parse(data);
            for (teacher in teachers)
            {
                if (teacher.id == id)
                    return teacher;
            }
        }*/
        $scope.teacher = data;
    });
}]);