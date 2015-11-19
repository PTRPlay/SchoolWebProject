myApp.factory('PupilsModalService', ['$http', 'ModalService', function ($http, ModalService) {
 
    return {
        showPupilsEditPage: function (user) {
            ModalService.showModal({
                templateUrl: "Layouts/PupilAddTemplate.html",
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
                                $http.post("api/pupils", result);
                                window.location.reload("/home");
                            }
                            else {
                                $http.post("api/pupils/" + result.id, result);
                                window.location.reload("/home");
                            }
                        }

                    });
                });
        },

        showPupilsDeleteModal: function (id) {
            ModalService.showModal({
                templateUrl: "Layouts/PupilsDeleteTemplate.html",
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
                                $http.delete("api/pupils/" + result.id);
                                window.location.reload("/home");
                            }
                    });
                });
        }
    }
}]);