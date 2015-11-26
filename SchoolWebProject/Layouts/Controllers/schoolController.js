myApp.controller('schoolController', function ($scope, schoolService) {
    schoolService.loadSchool()
        .success(function (data) {
        $scope.school = data;
    });
});