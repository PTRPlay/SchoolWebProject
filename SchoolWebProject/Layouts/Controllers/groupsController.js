myApp.controller('groupsController', ['$scope', 'groups', 'uiGridConstants', 'GroupModalService',
    function ($scope, groups, uiGridConstants, GroupModalService) {
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
                   }
           },
           {
               name: 'Літера',
               field: 'NameLetter',
               width: "50"
           },
           {
               name: "Класний керівник",
               field: "TeacherName",
               sortingAlgorithm: function (a, b) {
                   return a.localeCompare(b)
               }
           },
           {
               name: "Кількість учнів",
               field: "PupilsAmount",
               type: 'number',
               width: "150"
           },
           {
               name: "Деталі",
               field: "Details",
               cellTemplate: '<div><a class="btn btn-default btn-sm" ng-href="#/group/{{row.entity.Id}}" style=" width: 70px;" ><img src="/Layouts/Images/group.png"></a></div>',
               width: "80",
               enableFiltering: false,
               enableSorting: false
           },
           {
               name: "Редагування",
               field: "Edit",
               cellTemplate: '<div><button class="btn btn-default btn-sm" ng-click="grid.appScope.editGroup(row.entity)" style=" width: 70px; " ><img src="/Layouts/Images/edit.png"></button></div>',
               width: "80",
               enableFiltering: false,
               enableSorting: false
           },
           {
               name: "Видалити",
               field: "Delete",
               cellTemplate: '<div><button class="btn btn-default btn-sm" ng-click="grid.appScope.deleteGroup(row.entity.Id, row.entity.NameNumber, row.entity.NameLetter)" style=" width: 70px;" ><img src="/Layouts/Images/remove.png"></button></div>',
               width: "80",
               enableFiltering: false,
               enableSorting: false
           }
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

        groups.success(function (data) {
            $scope.groupsGrid.data = data;
        });
    }

]);