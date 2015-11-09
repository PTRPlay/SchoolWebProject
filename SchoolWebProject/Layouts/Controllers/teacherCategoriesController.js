myApp.controller('teacherCategories', ['$scope', 'teacherCategories', function ($scope, teacherCategories) {
    teacherCategories.success(function (data) {
        $scope.teacherCategories = data;
    });
}]);

myApp.controller('viewTeacherCategories', ['$scope', '$routeParams',function ($scope, $routeParams) {
    teacherCategories.success(function (data) {
        var currentId = $routeParams.id;
        //$scope.teacherCategories = data;
    });
}]);
