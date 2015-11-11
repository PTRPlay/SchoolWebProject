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
                            $http.post("api/pupil", result);
                        }
                    });
                });
        },
        showPupilsDeleteModal: function (user) {
            ModalService.showModal({
                templateUrl: "Layouts/PupilsDeleteTemplate.html",
                controller: "pupilDeleteController",
                inputs: {
                    title: "Учень",
                    Pupil: user
                }
            })
                .then(function (modal) {
                    modal.element.modal();
                    modal.close.then(function (result) {
                        if (result != null) {
                            $http.post("api/pupil", result);
                        }
                    });
                });
        },

        showWithBonus: function (name) {
            alert("Go to hell " + name);
        }
    }
}]);