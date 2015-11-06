myApp.controller('teacherCategoriesController', ['$scope', 'teacherCategories', function ($scope, teacherCategories) {
    teacherCategories.success(function (data) {
        $scope.teacherCategories = data;
    });
}]);