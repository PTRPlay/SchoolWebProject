myApp.controller('groupsController', ['$scope', 'groupsService', 'uiGridConstants', 'GroupModalService',
    function ($scope, groupsService, uiGridConstants, GroupModalService) {
        $scope.text = "Список класів";

        $scope.groupsGrid =
            {
                showGridFooter: true,
                columnDefs: [
           {
               displayName: "№",
               field: 'NameNumber',
               width: "50",
               type: 'number',
               sort:
                   {
                       direction: uiGridConstants.ASC,
                       priority: 1
                   },
               enableHiding: false,
               enableColumnMenu: false
           },
           {
               name: ' ',
               field: 'NameLetter',
               width: "50",
               enableHiding: false,
               enableColumnMenu: false
           },
           {
               name: "Класний керівник",
               field: "TeacherName",
               sortingAlgorithm: function (a, b) {
                   return a.localeCompare(b)
               },
               enableHiding: false,
               enableColumnMenu: false
           },
           {
               name: "Кількість учнів",
               field: "PupilsAmount",
               type: 'number',
               width: "150",
               enableHiding: false,
               enableColumnMenu: false
           },
           {
               name: "Опції",
               field: "Details",
               cellTemplate: '<div>&nbsp <a title="Деталі про {{row.entity.NameNumber}}-{{row.entity.NameLetter}}" ng-href="#/group/{{row.entity.Id}}"><img src="/Layouts/Images/group.png"></a> &nbsp ' +
                             '<a title="Редагувати {{row.entity.NameNumber}}-{{row.entity.NameLetter}}" href="" ng-click="grid.appScope.editGroup(row.entity)" ><img src="/Layouts/Images/edit.png"></a> &nbsp ' +
                             '<a title="Видалити {{row.entity.NameNumber}}-{{row.entity.NameLetter}}" href="" ng-click="grid.appScope.deleteGroup(row.entity.Id, row.entity.NameNumber, row.entity.NameLetter)" ><img src="/Layouts/Images/remove.png"></a>&nbsp</div>',
               width: "120",
               enableFiltering: false,
               enableSorting: false,
               enableHiding: false,
               enableColumnMenu: false

           },
                ],
                onRegisterApi: function (gridApi) {
                    $scope.grid2Api = gridApi;
                }
            };

        $scope.addGroup = function () {
            GroupModalService.showGroupEditPage();
        };

        $scope.editGroup = function (value) {
            GroupModalService.showGroupEditPage(value);
        };

        $scope.deleteGroup = function (id, nameNumber, nameLetter) {
            var val = { id: id, nameNumber: nameNumber, nameLetter: nameLetter };
            GroupModalService.showGroupDeleteModal(val);
        };

        groupsService.getGroups()
            .success(function (data) {
            $scope.groupsGrid.data = data;
        });
    }

]);