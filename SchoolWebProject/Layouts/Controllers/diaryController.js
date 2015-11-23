myApp.controller('diaryController', function ($scope, diaryService) {

    $scope.IdUser = 55;

    $scope.currentdate = new Date();
    $scope.currentday = $scope.currentdate.getDay();
    $scope.days = ['Понеділок', 'Вівторок', 'Середа', 'Четвер', 'Пятниця'];

    $scope.mondayDate = new Date($scope.currentdate);
    $scope.mondayDate.setDate($scope.currentdate.getDate() - $scope.currentday + 1);
    $scope.mondayDateMonth = $scope.mondayDate.getMonth() + 1;
    $scope.stringdate = $scope.mondayDate.getFullYear() + '-' + $scope.mondayDateMonth + '-' + $scope.mondayDate.getDate();
   // $scope.stringdate = '2015-11-16';

    diaryService.getDiary($scope.IdUser, $scope.stringdate).success(function (data) {
        $scope.diary = data;
    });

    $scope.isShowing = function (item, index) {
        return item == index;
    };

    $scope.getCurrentDay = function (index) {
        $scope.date = new Date();
        $scope.date.setDate($scope.mondayDate.getDate() - 1 + index);
        $scope.month = $scope.date.getMonth() + 1;
        $scope.sdate = $scope.date.getDate() + '.' + $scope.month + '.' + $scope.date.getFullYear();
        return $scope.sdate;
    };

});