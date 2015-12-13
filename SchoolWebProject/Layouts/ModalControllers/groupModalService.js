myApp.factory('GroupModalService', ['$http', 'ModalService', '$state', '$stateParams', function ($http, ModalService, $state, $stateParams) {
    return {
        showGroupEditPage: function (group) {
            ModalService.showModal(
                {
                    templateUrl: "Layouts/PartialView/GroupAddTemplate.html",
                    controller: "groupAddController",
                    inputs:
                        {
                            title: "Group",
                            Group: group
                        }
                })
                .then(function (modal) {
                    modal.element.modal();
                    modal.close.then(function (result)
                    {
                        if (result != null)
                        {
                            if (result.id == null)
                            {
                                $http.post("api/groups", result)
                                    .success(function () {
                                        $state.go('groups', { start: $stateParams.start }, { reload: true });
                                    });
                            }
                            else
                            {
                                $http.post("api/groups", result)
                                    .success(function () {
                                        $state.go('groups', { start: $stateParams.start }, { reload: true });
                                    });
                            }
                        }

                    });
                });
        },

        showGroupDeleteModal: function (id) {
            ModalService.showModal(
                {
                    templateUrl: "Layouts/PartialView/GroupDeleteTemplate.html",
                    controller: "groupDeleteController",
                    inputs:
                        {
                            title: "Delete",
                            GroupId: id
                        }
                })
                .then(function (modal) {
                    modal.element.modal();
                    modal.close.then(function (result) {
                        if (result.id != null) {
                            $http.delete("api/groups/" + result.id)
                                .success(function () {
                                    $state.go('groups', { start: $stateParams.start }, { reload: true });
                                });
                        }
                    });
                });
        }
    }
}]);