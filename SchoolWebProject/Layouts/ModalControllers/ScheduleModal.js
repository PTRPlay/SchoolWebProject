﻿myApp.controller('ScheduleModal', ['$scope', 'ModalService', '$http','schedule',function ($scope, ModalService, $http,schedule) {
    $scope.schedule = null;
    $scope.modifiedSchedule = null;
    $scope.filterTeacherName = null;
    schedule.success(
        function (data){
            $scope.schedule = data;
        }
        );
    $scope.showShceduleModal = function (url) {
        ModalService.showModal({
            templateUrl: url,
            controller: "FilterScheduleController",
            inputs: {
                title: "Schedule",
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (result != null) {
                    //$scope.modifiedSchedule = modifiedScheduleFunc($scope.schedule, result.teacher);
                    $scope.filterTeacherName = result.teacher;
                }
            });
        });
    };

    function modifiedScheduleFunc() {
        var result = [];
        for (var i = 0; i < $scope.schedule.length; ++i) {
            if ($scope.schedule[i].Teacher.LastName.indexOf($scope.filterTeacherName) >= 0) {
                result.push(mas[i]);
            }
        }
        return result;
    }

}]);