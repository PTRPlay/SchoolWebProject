myApp.controller('FilterScheduleController',['$scope', '$element', 'title', 'close', function ($scope, $element, title, close) {
$scope.teacherName = null;
$scope.close = function () {
    $element.modal('hide');
    close({
        cancelled: false,
        teacher: $scope.teacherName
    }, 500);
};

$scope.cancel = function () {
    $element.modal('hide');

    close(null, 500);
}

}]);