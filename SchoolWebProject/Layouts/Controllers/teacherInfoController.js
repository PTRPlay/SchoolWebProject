myApp.controller('teacherInfoController', ['$scope', 'teachersService', 'permissionService', function ($scope, teachersService, permissionService) {
    teachersService.getTeachers()
        .success(function (data) {
        $scope.getTeacher = function () {
            var id = document.URL.split("teacher/")[1];
            for (var i = 0; i < data.length; i++) {
                if (data[i].Id == id)
                    return data[i];
            }
        }
        });
    $scope.showTeacherInfo = function () {
        return permissionService.showTeachers();
    };

    $scope.showTeacherEditDelete = function () {
        return permissionService.showAddEditTeacher();
    };
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