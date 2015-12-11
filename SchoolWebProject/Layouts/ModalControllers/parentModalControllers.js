myApp.controller('parentAddController', ['$scope', '$element', 'title', 'close', 'Parent', function ($scope, $element, title, close, Parent) {
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
            pupils: null
        };
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