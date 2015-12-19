myApp.controller('pupilsController', ['$scope', 'pupilsService', 'uiGridConstants', 'PupilsModalService', 'permissionService', function ($scope, pupilsService, uiGridConstants, PupilsModalService, permissionService) {
    $scope.pupilsGrid = {
        enableSorting: true,
        enableFiltering: true,
        enablePaginationControls: true,
        paginationPageSizes: [25, 50, 75],
        paginationPageSize: 25,
        useExternalPagination: true,
        useExternalSorting: true,
        useExternalFiltering: true,

        columnDefs: [
   {
       field: "№ ",
       cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
       width: "50",
       enableSorting: false,
       enableFiltering: false,
       enableHiding: false,
       enableColumnMenu: false
   },
   {
       name: "Прізвище",
       field: "LastName",
       enableFiltering: true,
       width: "*",
       enableHiding: false,
       enableColumnMenu: false,
       sort: {
           direction: uiGridConstants.ASC,
           priority: 1
       },
       sortingAlgorithm: function (a, b) {
           return a.localeCompare(b)
       }
   },
   {
       name: "Ім'я",
       field: "FirstName",
       width: "*",
       enableFiltering: true,
       enableFiltering: false,
       enableHiding: false,
       enableColumnMenu: false
   },
   {
       name: "По-батькові",
       field: "MiddleName",
       width: "*",
       enableSorting: true,
       enableFiltering: false,
       enableHiding: false,
       enableColumnMenu: false
   },
    {
        name: "Клас",
        field: "GroupName",
        width: "*",
        enableSorting: false,
        enableFiltering: false,
        enableHiding: false,
        enableColumnMenu: false
    },
   {
       name: "Телефон",
       field: "PhoneNumber",
       width: "*",
       enableFiltering: false,
       enableSorting: false,
       enableHiding: false,
       enableColumnMenu: false
   },
   {
       name: "Адреса",
       field: "Address",
       width: "*",
       enableFiltering: false,
       enableSorting: false,
       visible: false
   },
   {
       field: "Email",
       width: "*",
       enableFiltering: false,
       enableSorting: false,
       visible: false
   },
   {
       name: "Опції",
       field: "Profile",
       cellTemplate: '<div><a title="Профіль {{row.entity.LastName}} {{row.entity.FirstName}}" ng-href="#/pupil/{{row.entity.Id}}"><img src="/Layouts/Images/user.png"></a>  ' +
           '<a title="Видалити {{row.entity.LastName}} {{row.entity.FirstName}}" href="" ng-click="grid.appScope.deletePupil(row.entity.Id, row.entity.LastName)"><img src="/Layouts/Images/remove.png"></a></div>',
       width: "70",
       enableFiltering: false,
       enableSorting: false,
       enableHiding: false,
       enableColumnMenu: false
   },

        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;

            $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                if (sortColumns.length == 0) {
                    paginationOptions.sort = null;
                } else {
                    paginationOptions.sort = null;
                    paginationOptions.sort = sortColumns[0].sort.direction;
                }
                var sortColumnName = sortColumns[0].field;

                var filter = grid.columns[1].filters[0].term;

                getPage(filter, sortColumnName);
            });

            $scope.gridApi.core.on.filterChanged($scope, function () {
                var filter = gridApi.grid.columns[1].filters[0].term;
                setTimeout(function () {
                    getPage(filter);
                }, 2000);
                
            });

            $scope.gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                paginationOptions.pageNumber = newPage;
                paginationOptions.pageSize = pageSize;

                var filter = gridApi.grid.columns[1].filters[0].term;
                getPage(filter);
            });
        }
    };

    var paginationOptions = {
        pageNumber: 1,
        pageSize: 25,
        sort: null
    };

    $scope.showPupils = function () {
        return permissionService.showPupils();
    };

    $scope.addPupil = function () {
        PupilsModalService.showPupilsEditPage();
    };

    $scope.editPupil = function (value) {
        PupilsModalService.showPupilsEditPage(value);
    };

    $scope.deletePupil = function (id, lastName) {
        var val = { id: id, lastName: lastName };
        PupilsModalService.showPupilsDeleteModal(val);
    };

    var getPage = function (filter, sortColumn) {
        var pageNumb = paginationOptions.pageNumber;
        var sortOpt = 'LastName';
        if (sortColumn) {
            sortOpt = sortColumn;
        }
        //generating error
        //var x = n + 1;

        switch (paginationOptions.sort) {
            case uiGridConstants.ASC:
                sortOpt = sortOpt + ' ASC';
                break;

            case uiGridConstants.DESC:
                sortOpt = sortOpt + ' DESC';
                break;

            default:
                sortOpt = sortOpt + ' ASC';
                break;
        }

        function GetGroupData() {
            for (i = 0; i < $scope.pupilsGrid.data.length; i++) {
                $scope.pupilsGrid.data[i]["GroupName"] = $scope.pupilsGrid.data[i].GroupNumber + "-" + $scope.pupilsGrid.data[i].GroupLetter;
            }
        }

        pupilsService.getPage(pageNumb, paginationOptions.pageSize, sortOpt, filter)
            .success(function (data) {
                $scope.pupilsGrid.totalItems = data.PageCount;
                $scope.pupilsGrid.data = data.Pupils;
                GetGroupData();
            });
    }
    getPage();
}
]);


