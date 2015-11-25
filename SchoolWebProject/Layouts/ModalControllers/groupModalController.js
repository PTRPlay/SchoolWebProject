myApp.controller("groupAddController", ['$scope', '$element', 'title', 'close', 'Group',
    function ($scope, $element, title, close, Group) {
        $scope.group = null;
        $scope.IsFormValid = true;
        if (Group != null) {
            $scope.group =
            {
                id: Group.Id,
                nameNumber: Group.nameNumber,
                nameLetter: Group.nameLetter
            };
        }
        else {
            $scope.group =
            {
                id: null,
                nameNumber: null,
                nameLetter: null
            };
        }

        $scope.close = function () {
            $element.modal('hide');
            close(
            {
                id: $scope.group.id,
                nameNumber: $scope.group.nameNumber,
                nameLetter: $scope.group.nameLetter
            }, 500);

        };

        $scope.cancel = function () {
            $element.modal('hide');

            close(null, 500);
        }
    }]);

myApp.controller("groupDeleteController", ['$scope', '$element', 'title', 'close', 'GroupId',
    function ($scope, $element, title, close, GroupId) {
        $scope.groupId = null;
        if (GroupId != null) {
            $scope.groupId =
            {
                id: GroupId.id,
                nameNumber: GroupId.nameNumber,
                nameLetter: GroupId.nameLetter
            };
        }
        else {
            $scope.groupId =
            {
                id: null,
                nameNumber: null,
                nameLetter: null
            };
        };

        $scope.close = function () {
            $element.modal('hide');
            close(
            {
                id: $scope.groupId.id,
                nameNumber: $scope.groupId.nameNumber,
                nameLetter: $scope.groupId.nameLetter
            }, 500);
        };

        $scope.cancel = function () {
            $element.modal('hide');
            close(null, 500);
        }
    }]);