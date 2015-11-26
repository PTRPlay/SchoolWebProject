﻿myApp.controller('newsController', function ($scope, newsService) {
    $scope.listAnnouncements = [];
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


