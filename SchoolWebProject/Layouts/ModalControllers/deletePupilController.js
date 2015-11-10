myApp.controller("pupilDeleteController", ['$scope', '$element', 'title', 'close', 'Pupil', function ($scope, $element, title, close, Pupil) {
    $scope.pupil = null;

    $scope.close = function () {
        $element.modal('hide');
    };

    $scope.cancel = function () {
        $element.modal('hide');
    }
}]);