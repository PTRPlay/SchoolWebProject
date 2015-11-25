myApp.controller("subjectAddController", ['$scope', '$element', 'title', 'close', 'Subject',
    function ($scope, $element, title, close, Subject) {
        $scope.subject = null;
        $scope.IsFormValid = true;
        if (Subject != null) {
            $scope.subject =
            {
                id: Subject.Id,
                name: Subject.name
            };
        }
        else {
            $scope.subject =
            {
                id: null,
                name: null
            };
        }

        $scope.close = function () {
            $element.modal('hide');
            close(
            {
                id: $scope.subject.id,
                nameNumber: $scope.subject.name
            }, 500);

        };

        $scope.cancel = function () {
            $element.modal('hide');

            close(null, 500);
        }
    }]);