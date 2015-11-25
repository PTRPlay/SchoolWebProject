myApp.factory('SubjectModalService', ['$http', 'ModalService', function ($http, ModalService) {

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
                                $http.post("api/subjects", result);
                                window.location.reload("/home");
                            }
                            else {
                                $http.post("api/subjects/", result);
                                window.location.reload("/home");
                            }
                        }

                    });
                });
        }
    }
}]);