myApp.controller('announcementModalService', ['$scope', 'ModalService', '$http', '$state', '$stateParams',  function ($scope, ModalService, $http, $state, $stateParams) {
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
                        $http.post("api/announcements", result)
                            .success(function () {
                                $state.go('newsAdminService', { start: $stateParams.start }, { reload: true });
                            });
                    }
                    else {
                        $http.post("api/announcements/" + result.id, result)
                            .success(function () {
                                $state.go('newsAdminService', { start: $stateParams.start }, { reload: true });
                            });
                    }
                }
            });
        });

    };

    $scope.showAnnouncementDeletePage = function (id) {
        ModalService.showModal({
            templateUrl: "Layouts/PartialView/AnnouncementDeleteTemplate.html",
            controller: "announcementDeleteController",
            inputs: {
                title: "Delete",
                AnnouncementId: id
                
            }
        })
            .then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result.id != null) {
                        $http.delete("api/announcements/" + result.id)
                            .success(function () {
                                $state.go('newsAdminService', { start: $stateParams.start }, { reload: true });
                            });
                    }
                });
            });
    }

}]);