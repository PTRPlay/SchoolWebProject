myApp.controller("pupilAddController", ['$scope', '$element', 'title', 'close', 'Pupil', function ($scope, $element, title, close, Pupil) {
    $scope.pupil = null;
    if (Pupil != null) {
        $scope.pupil = {
            id: Pupil.id,
            img: Pupil.img,
            firstName: Pupil.firstName,
            middleName: Pupil.middleName,
            lastName: Pupil.lastName,
            phoneNumber: Pupil.phoneNumber
        };
    }
    else {
        $scope.pupil = {
            id: null,
            img: null,
            firstName: null,
            middleName: null,
            lastName: null,
            phoneNumber: null
        };
    }
   
    $scope.close = function () {
        $element.modal('hide');
        close({
            firstName: $scope.pupil.firstName,
            lastName: $scope.pupil.lastName
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');

        close({
            firstName: $scope.pupil.firstName,
            lastName: $scope.pupil.lastName
        }, 500);
    }
}]);