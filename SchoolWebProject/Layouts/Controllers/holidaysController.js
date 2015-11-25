myApp.controller('holidaysController', function ($scope, holidays) {
    holidays.success(function (data) {
        $scope.holidays = data;
    });
});