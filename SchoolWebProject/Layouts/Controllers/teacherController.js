myApp.controller('teachersController', ['$scope', 'teachers', function ($scope, teachers) {
    teachers.success(function (data) {
        $scope.teachers = data;
    });
}

]);
