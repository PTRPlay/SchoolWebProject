myApp.controller('teacherCategories', ['$scope', 'teacherCategories', function ($scope, teacherCategories) {
    teacherCategories.success(function (data) {
        $scope.teacherCategories = data;
    });
}]);

myApp.controller('teachersByCategory', ['$scope', 'teachers','$routeParams', function ($scope, teachers, $routeParams) {
    var Id = $routeParams.Id;
    teachers.success(function (data) {
       $scope.teachers = data;
    });
}]);

