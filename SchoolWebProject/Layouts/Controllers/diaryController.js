myApp.controller('diaryController', function ($scope, diaryService) {
    diaryService.success(function (data) {
            $scope.diary= data;
    });
});