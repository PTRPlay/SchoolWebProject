myApp.controller('newsController', function ($scope, newsService) {
    newsService.success(function (data) {
        $scope.listAnnouncements= data;
    });
});

