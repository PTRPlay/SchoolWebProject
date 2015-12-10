myApp.controller('newsController', function ($scope, newsService, testFromIndex) {
    $scope.listAnnouncements = [];
    console.log('test value from Index page: ' + testFromIndex); // todo remove afterwards
    newsService.getNews().success(function (data) {
        $scope.listAnnouncements = data;
    });
    $scope.activeIndex;
    $scope.showDetail = function (index) {
        $scope.activeIndex = index;
    };

    $scope.isShowing = function (index) {
        return $scope.activeIndex == index;
    };

});


