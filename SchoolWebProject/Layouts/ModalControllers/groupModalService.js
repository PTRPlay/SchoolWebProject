myApp.factory('GroupModalService', ['$http', 'ModalService', function ($http, ModalService) {

    return {
        showGroupEditPage: function (group)
        {
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
                .then(function (modal)
                {
                    modal.element.modal();
                    modal.close.then(function (result)
                    {
                        if (result != null)
                        {
                            if (result.id == null)
                            {
                                $http.post("api/groups", result);
                                window.location.reload("/home");
                            }
                            else
                            {
                                $http.post("api/groups/" + result.id, result);
                                window.location.reload("/home");
                            }
                        }

                    });
                });
        },

        showGroupDeleteModal: function (id)
        {
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
                .then(function (modal)
                {
                    modal.element.modal();
                    modal.close.then(function (result)
                    {
                        if (result.id != null)
                        {
                            $http.delete("api/groups/" + result.id);
                            window.location.reload("/home");
                        }
                    });
                });
        }
    }
}]);