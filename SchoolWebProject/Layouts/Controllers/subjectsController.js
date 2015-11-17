myApp.controller('subjectsController', function ($scope, subjects) {
    $scope.count;
    subjects.success(function (data) {
        $scope.listSubjects = data;
    });
});