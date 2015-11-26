myApp.controller('holidaysController', function ($scope, holidaysService) {
    holidaysService.getHolidays()
        .success(function (data) {
        $scope.holidays = data;
    });
});