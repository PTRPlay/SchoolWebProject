myApp.factory('ParentsModalService', ['$http', 'ModalService', function ($http, ModalService) {
    return {
        showParentAddPage: function (user) {
            ModalService.showModal({
                templateUrl: 'Layouts/PartialView/ParentAddTemplate.html',
                controller: 'parentAddController',
                inputs: {
                    title: "Батько",
                    Parent: user
                }
            }).then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result != null) {
                        if (result.id == null) {
                            $http.post("api/parents", result);
                            window.location.reload("/home");
                        }
                        else {
                            $http.post("api/parents/" + result.id, result);
                            window.location.reload("/home");
                        }
                        window.location.assign("#/parents")
                    }
                })
            });
        },

        showParentsDeleteModal: function (id) {
        ModalService.showModal({
            templateUrl: "Layouts/PartialView/ParentDeleteTemplate.html",
            controller: "parentDeleteController",
            inputs: {
                title: "Delete",
                ParentId: id
            }
        })
            .then(function (modal) {
                modal.element.modal();
                modal.close.then(function (result) {
                    if (result.id != null) {
                        $http.delete("api/parents/" + result.id);
                        window.location.reload("/home");
                    }
                });
            });
    }
    }
}]);