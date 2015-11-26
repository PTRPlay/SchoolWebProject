myApp.controller('diaryController', function ($scope, diaryService) {
    $scope.weeks = 0;
        $scope.IdUser = window.currentUser.Id;
 //   $scope.IdUser = 56;
    $scope.millisInDay = 1000 * 60 * 60 * 24;

    $scope.fillHtml = function (week) {
        $scope.currentdate = new Date(+new Date + 7 * week * $scope.millisInDay);
        $scope.currentday = $scope.currentdate.getDay();
        $scope.mondayDate = new Date($scope.currentdate);
        $scope.mondayDate.setDate($scope.currentdate.getDate() - $scope.currentday + 1);
        $scope.mondayDateMonth = $scope.mondayDate.getMonth() + 1;
        $scope.stringdate = $scope.mondayDate.getFullYear() + '-' + $scope.mondayDateMonth + '-' + $scope.mondayDate.getDate();

        diaryService.getDiary($scope.IdUser, $scope.stringdate).success(function (data) {
            $scope.diary = data;
        });

    }

    $scope.isShowing = function (item, index) {
        return item == index;
    };

    $scope.isCurrentDate = function (index) {
        $scope.curdate = new Date();
        return $scope.sameDay($scope.curdate, $scope.getDayByIndex(index));
    };

    $scope.getDayByIndex = function (index) {
        $scope.date = new Date(+$scope.mondayDate + (index - 1) * $scope.millisInDay);
        return $scope.date;
    };

    $scope.showPrevious = function () {
        $scope.weeks = $scope.weeks - 1;
        $scope.fillHtml($scope.weeks);
    };

    $scope.showNext = function () {
        $scope.weeks = $scope.weeks + 1;
        $scope.fillHtml($scope.weeks);
    };

    $scope.showCurrent = function () {
        $scope.weeks = 0;
        $scope.fillHtml($scope.weeks);
    };

    $scope.sameDay = function (d1, d2) {
        return d1.getFullYear() === d2.getFullYear()
          && d1.getDate() === d2.getDate()
          && d1.getMonth() === d2.getMonth();
    }

});