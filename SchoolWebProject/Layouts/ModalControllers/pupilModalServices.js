myApp.factory('PupilsModalService', ['$http', 'ModalService', '$state', '$stateParams', function ($http, ModalService, $state, $stateParams) {
 
    return {
        showPupilsEditPage: function (user) {
            ModalService.showModal({
                templateUrl: "Layouts/PartialView/PupilAddTemplate.html",
                controller: "pupilAddController",
                inputs: {
                    title: "Учень",
                    Pupil: user
                }
            })
                .then(function (modal) {
                    modal.element.modal();
                    modal.close.then(function (result) {
                        if (result != null) {
                            if (result.id == null) {
                                $http.post("api/pupils", result)
                                .success(function () {
                                    $state.go('pupils', { start: $stateParams.start }, { reload: true });
                                });
                            }
                            else {
                                $http.post("api/pupils/" + result.id, result)
                                .success(function () {
                                    $state.go('pupils', { start: $stateParams.start }, { reload: true });
                                });
                            }
                        }

                    });
                });
        },

        showPupilsDeleteModal: function (id) {
            ModalService.showModal({
                templateUrl: "Layouts/PartialView/PupilsDeleteTemplate.html",
                controller: "pupilDeleteController",
                inputs: {
                    title: "Delete",
                    PupilId: id
                }
            })
                .then(function (modal) {
                    modal.element.modal();
                    modal.close.then(function (result) {
                        if (result.id != null) {
                                $http.delete("api/pupils/" + result.id)
                                .success(function () {
                                    $state.go('pupils', { start: $stateParams.start }, { reload: true });
                                });
                            }
                    });
                });
        }
    }
}]);