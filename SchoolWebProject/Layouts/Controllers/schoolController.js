myApp.controller('schoolController', function ($scope, schoolService) {
    schoolService.success(function (data) {
        $scope.school = data;
    });
});