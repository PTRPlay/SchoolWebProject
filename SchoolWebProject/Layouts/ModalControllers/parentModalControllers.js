myApp.controller('parentAddController', ['$scope', '$element', 'title', 'close', 'Parent', 'pupilsService', function ($scope, $element, title, close, Parent, pupilsService) {
    $scope.parent = null;
    var getPupils = function (parent) {
        var pupils = [];
        for (var i = 0; i < parent.Pupils.length; ++i) {
            var pupil = {
                id: parent.Pupils[i].Id,
                firstName: parent.Pupils[i].FirstName,
                middleName: parent.Pupils[i].MiddleName,
                lastName: parent.Pupils[i].LastName,
            };
            pupils.push(pupil);
        }
        return pupils;
    }
    if (Parent != null) {
        $scope.parent = {
            id: Parent.Id,
            img: Parent.Img,
            firstName: Parent.FirstName,
            middleName: Parent.MiddleName,
            lastName: Parent.LastName,
            phoneNumber: Parent.PhoneNumber,
            address: Parent.Address,
            email: Parent.Email,
            pupils: getPupils(Parent)
        };
    }
    else {
        $scope.parent = {
            id: null,
            img: null,
            firstName: null,
            middleName: null,
            lastName: null,
            phoneNumber: null,
            address: null,
            email: null,
            pupils: []
        };
    }
    pupilsService.getPupil().success(function (data) {
        $scope.pupils = data;
        for (var i = 0; i < $scope.pupils.length; ++i) {
            for (var j = 0; j < $scope.parent.pupils.length; ++j) {
                if ($scope.pupils[i].Id == $scope.parent.pupils[j].id) {
                    $scope.pupils.splice(i, 1);
                }
            }
        }
    });
    $scope.SelectedPupil;
    $scope.AddPupil = function () {
        var pupil = {
            id: $scope.SelectedPupil.originalObject.Id,
            firstName: $scope.SelectedPupil.originalObject.FirstName,
            middleName: $scope.SelectedPupil.originalObject.MiddleName,
            lastName: $scope.SelectedPupil.originalObject.LastName
        }
        $scope.parent.pupils.push(pupil);
        for (var i = 0; i < $scope.pupils.length; ++i) {
            if ($scope.pupils[i].Id == pupil.id) {
                $scope.pupils.splice(i, 1);
            }
        }
    }
    $scope.close = function () {
        $element.modal('hide');
        close({
            id: $scope.parent.id,
            firstName: $scope.parent.firstName,
            lastName: $scope.parent.lastName,
            middleName: $scope.parent.middleName,
            phoneNumber: $scope.parent.phoneNumber,
            address: $scope.parent.address,
            email: $scope.parent.email,
            pupils: $scope.parent.pupils
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');
        close(null, 500);
    }
}]);

myApp.controller("parentDeleteController", ['$scope', '$element', 'title', 'close', 'ParentId', function ($scope, $element, title, close, ParentId) {
    $scope.parentId = null;
    $scope.IsFormValid = true;
    if (ParentId != null) {
        $scope.parentId = ParentId;
    }

    $scope.close = function () {
        $element.modal('hide');
        close({
            id: $scope.parentId,
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');
        close(null, 500);
    }
}]);