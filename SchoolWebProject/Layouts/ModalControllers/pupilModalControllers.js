myApp.controller("pupilAddController", ['$scope', '$element', 'title', 'close', 'Pupil', function ($scope, $element, title, close, Pupil) {
    $scope.pupil = null;
    $scope.IsFormValid = true;
    if (Pupil != null) {
        $scope.pupil = {
            id: Pupil.Id,
            img: Pupil.Img,
            firstName: Pupil.FirstName,
            middleName: Pupil.MiddleName,
            lastName: Pupil.LastName,
            phoneNumber: Pupil.PhoneNumber,
            address: Pupil.Address,
            email: Pupil.Email,
            group: {
                id: Pupil.Group.Id,
                nameNumber: Pupil.Group.NameNumber,
                nameLetter: Pupil.Group.NameLetter
            }
        };
    }
    else {
        $scope.pupil = {
            id: null,
            img: null,
            firstName: null,
            middleName: null,
            lastName: null,
            phoneNumber: null,
            address: null,
            email: null,
            //groupNumber: null,
            //groupLetter: null
           group:null
        };
    }
    
    $scope.close = function () {
        $element.modal('hide');
        close({
            id: $scope.pupil.id,
            firstName: $scope.pupil.firstName,
            lastName: $scope.pupil.lastName,
            middleName: $scope.pupil.middleName,
            phoneNumber: $scope.pupil.phoneNumber,
            address: $scope.pupil.address,
            email: $scope.pupil.email,
            group: $scope.pupil.group
        }, 500);
       
    };

    $scope.cancel = function () {
        $element.modal('hide');

        close(null, 500);
    }
}]);

myApp.controller("pupilDeleteController", ['$scope', '$element', 'title', 'close', 'PupilId', function ($scope, $element, title, close, PupilId) {
    $scope.pupilId = null;
    $scope.IsFormValid = true;
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