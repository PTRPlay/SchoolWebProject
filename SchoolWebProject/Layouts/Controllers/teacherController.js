myApp.controller('teachersController',function ($scope,teachers) {
    teachers.success(function (data) {
        $scope.teachers = data;
    });
}

);
