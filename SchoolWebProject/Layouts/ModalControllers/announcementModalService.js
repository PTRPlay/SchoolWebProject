myApp.controller('announcementModalService', ['$scope', 'ModalService', '$http', function ($scope, ModalService, $http) {
    $scope.showAnnouncementEditPage = function (announcement) {
        ModalService.showModal({
            templateUrl: "Layouts/PartialView/AnnouncementAddTemplate.html",
            controller: "announcementAddController",
            inputs: {
                title: "Announcement",
                Announcement: announcement
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (result != null) {
                    if (result.id == null) {
                        $http.post("api/announcements", result);
                        window.location.reload("/home");
                    }
                    else {
                        $http.post("api/announcements/" + result.id, result);
                        window.location.reload("/home");
                    }
                }
            });
        });
    };

}]);