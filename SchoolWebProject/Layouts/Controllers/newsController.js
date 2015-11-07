myApp.controller('newsController', function ($scope, newsService) {
    newsService.success(function (data) {
        $scope.listAnnouncements= data;
    });
});

myApp.controller('newsDetailController', function ($scope, newsDetailService) {
    newsDetailService.success(function (data) {
        $scope.announcement = data;        
    });
});