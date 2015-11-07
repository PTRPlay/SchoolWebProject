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

myApp.controller('categoriesController', function ($scope, categories) {
    categories.success(function (data) {
        $scope.listCategories = data;
    });
});

myApp.controller('degreeController', function ($scope, degree) {
    degree.success(function (data) {
        $scope.listDegrees = data;
    });
});