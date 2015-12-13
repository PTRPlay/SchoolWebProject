myApp.factory('SubjectModalService', ['$http', 'ModalService', '$state', '$stateParams', function ($http, ModalService, $state, $stateParams) {

    return {
        showSubjectEditPage: function (subject) {
            ModalService.showModal(
                {
                    templateUrl: "Layouts/PartialView/SubjectAddTemplate.html",
                    controller: "subjectAddController",
                    inputs:
                        {
                            title: "Subject",
                            Subject: subject
                        }
                })
                .then(function (modal) {
                    modal.element.modal();
                    modal.close.then(function (result) {
                        if (result != null) {
                            if (result.id == null) {
                                $http.post("api/subjects", result)
                                    .success(function () {
                                        $state.go('subjects', { start: $stateParams.start }, { reload: true });
                                });
                            }
                            else {
                                $http.post("api/subjects/"+result.id, result)
                                    .success(function () {
                                        $state.go('subjects', { start: $stateParams.start }, { reload: true });
                                    });
                            }
                        }

                    });
                });
        }
    }
}]);