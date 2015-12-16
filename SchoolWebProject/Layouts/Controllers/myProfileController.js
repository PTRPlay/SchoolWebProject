myApp.controller('myProfileController', function ($scope, currentUser, myProfileService) {
    
    $scope.user = JSON.parse(currentUser);

    $scope.getUserData = function () {
        myProfileService.getUser($scope.user.Id).success(function (data) {
            $scope.userData = data;
        })
    };

    $scope.userData;

});