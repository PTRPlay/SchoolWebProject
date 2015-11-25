myApp.controller('groupsController', ['$scope', 'groups', 'uiGridConstants', 'GroupModalService',
    function ($scope, groups, uiGridConstants, GroupModalService) {
        $scope.text = "All Groups:";

        $scope.groupsGrid =
            {
                showGridFooter: true,
                columnDefs: [
           {
               displayName: "No",
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
               field: 'NameLetter',
               width: "50"
           },
           {
               field: "TeacherName",
               sortingAlgorithm: function (a, b) {
                   return a.localeCompare(b)
               }
           },
           {
               field: "PupilsAmount",
               type: 'number',
               width: "150"
           },
           {
               field: "Details",
               cellTemplate: '<div><a class="btn btn-default btn-sm" ng-href="#/group/{{row.entity.Id}}" style=" width: 70px;" ><img src="/Layouts/Images/group.png"></a></div>',
               width: "80",
               enableFiltering: false,
               enableSorting: false
           },
           {
               field: "Edit",
               cellTemplate: '<div><button class="btn btn-default btn-sm" ng-click="grid.appScope.editGroup(row.entity)" style=" width: 70px; " ><img src="/Layouts/Images/edit.png"></button></div>',
               width: "80",
               enableFiltering: false,
               enableSorting: false
           },
           {
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