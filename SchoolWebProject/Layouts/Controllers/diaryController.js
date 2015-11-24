myApp.controller('diaryController', function ($scope, diaryService) {
    $scope.weeks = 0;
    $scope.IdUser = 56;
    $scope.days = ['Понеділок', 'Вівторок', 'Середа', 'Четвер', 'Пятниця'];
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
        $scope.curdatemonth = $scope.curdate.getMonth() + 1;
        $scope.scurdate = $scope.curdate.getDate() + '.' + $scope.curdatemonth + '.' + $scope.curdate.getFullYear();
        return $scope.scurdate == $scope.getDayByIndex(index);
    };

    $scope.getDayByIndex = function (index) {
        $scope.date = new Date();
        $scope.date.setDate($scope.mondayDate.getDate() - 1 + index);
        $scope.month = $scope.date.getMonth() + 1;
        $scope.sdate = $scope.date.getDate() + '.' + $scope.month + '.' + $scope.date.getFullYear();
        return $scope.sdate;
    };

    $scope.showPrevious = function () {
        $scope.weeks = $scope.weeks - 1;
        $scope.fillHtml($scope.weeks);
    };

    $scope.showNext = function () {
        $scope.weeks = $scope.weeks + 1;
        $scope.fillHtml($scope.weeks);
    };

});