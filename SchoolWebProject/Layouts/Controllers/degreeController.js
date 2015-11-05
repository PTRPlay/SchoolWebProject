myApp.controller('degreeController', function ($scope, degree) {
    degree.success(function (data) {
        $scope.listDegrees = data;
    });
});