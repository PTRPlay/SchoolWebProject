myApp.factory('ParentsModalService', ['$http', '$state','$stateParams', 'ModalService', function ($http, $state, $stateParams, ModalService) {
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
                            $http.post("api/parents", result).success(function () {
                                $state.go('parents', { start: $stateParams.start }, { reload: true });
                            });
                        }
                        else {
                            $http.post("api/parents/" + result.id, result).success(function () {
                                $state.go('parents', { start: $stateParams.start }, { reload: true });
                            });
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
                        $http.delete("api/parents/" + result.id)
                            .success(function () {
                            $state.go('parents', { start: $stateParams.start }, { reload: true });
                        });
                    }
                });
            });
    }
    }
}]);