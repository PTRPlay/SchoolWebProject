﻿myApp.controller("pupilAddController", ['$scope', '$element', 'title', 'close', 'Pupil', function ($scope, $element, title, close, Pupil) {
    $scope.pupil = null;
    $scope.IsFormValid = true;
    if (Pupil != null) {
        $scope.pupil = {
            id: Pupil.Id,
            img: Pupil.Img,
            firstName: Pupil.FirstName,
            middleName: Pupil.MiddleName,
            lastName: Pupil.LastName,
            phoneNumber: Pupil.PhoneNumber
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
            id: $scope.pupil.id,
            firstName: $scope.pupil.firstName,
            lastName: $scope.pupil.lastName,
            middleName: $scope.pupil.middleName,
            phoneNumber: null,
        }, 500);
       
    };

    $scope.cancel = function () {
        $element.modal('hide');
        console.log("cancelled!!");

        close(null, 500);
    }
}]);