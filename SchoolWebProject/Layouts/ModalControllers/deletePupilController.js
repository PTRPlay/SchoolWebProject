myApp.controller("pupilDeleteController", ['$scope', '$element', 'title', 'close', 'PupilId', function ($scope, $element, title, close, PupilId) {
    $scope.pupilId = null;
    if (PupilId != null) {
        $scope.pupilId = {
            id: PupilId.id,
            lastName: PupilId.lastName
        };
    }
    else {
        $scope.pupilId = {
            id: null,
            lastName: null
        };
    };

    $scope.close = function () {
        $element.modal('hide');
        close({
            id: $scope.pupilId.id,
            lastName: $scope.pupilId.lastName
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');
        close(null, 500);
    }
}]);