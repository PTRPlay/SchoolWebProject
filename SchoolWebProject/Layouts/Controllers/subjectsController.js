myApp.controller('subjectsController', function ($scope, subjects) {
    subjects.success(function (data) {
        $scope.listSubjects = data;
    });
});