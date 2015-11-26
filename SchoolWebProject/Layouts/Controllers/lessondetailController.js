﻿myApp.controller('lessondetailController', ['$scope', '$rootScope', 'lessonDetailService', '$http', function ($scope, $rootScope, lessonDetailService, $http) {
    $rootScope.showHomeTask = false;
    $scope.getLessonDetails = function (id) {
        $rootScope.showHomeTask = true;
        var data = lessonDetailService.getLessonDetails(id).success(function (data) {
            $rootScope.lessonDetail = {
                id: data.Id,
                date: data.Date,
                hometask: data.HomeTask,
                theme: data.Theme
            };
        });
    }
    $scope.close = function () {
        $rootScope.showHomeTask = false;
    }
    $scope.change = function () {
        console.log("Update");
        $http.post("api/lessonDetail" + "/" + $rootScope.lessonDetail.id, $rootScope.lessonDetail);
        //window.location.reload("/home");
    }
    $scope.changedDetail = false;
    $scope.isChangedDetail = function () {
        $scope.changedDetail = true;
    }
}])