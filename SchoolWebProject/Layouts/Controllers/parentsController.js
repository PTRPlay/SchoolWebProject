myApp.controller('parentsController', ['$scope', 'parentsService', 'uiGridConstants', 'ParentsModalService', 'permissionService', function ($scope, parentsService, uiGridConstants, ParentsModalService, permissionService) {
    $scope.parentsGrid = {
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
                field: '№',
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
                cellTemplate: '<div><a title="Профіль {{row.entity.LastName}} {{row.entity.FirstName}}" ng-href="#/parent/{{row.entity.Id}}"><img src="/Layouts/Images/user.png"></a>  ' +
                    '<a title="Видалити {{row.entity.LastName}} {{row.entity.FirstName}}" href="" ng-click="grid.appScope.deleteParent(row.entity.Id)"><img src="/Layouts/Images/remove.png"></a></div>',
                width: "70",
                enableFiltering: false,
                enableSorting: false,
                enableHiding: false,
                enableColumnMenu: false
            }
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
                getPage(filter);
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
    $scope.editParents = function (value) {
        ParentsModalService.showParentAddPage(value);
    };
    $scope.addParent = function () {
        ParentsModalService.showParentAddPage();
    };

    $scope.showParentsGrid = function () {
        return permissionService.showParentsGrid();
    };

    $scope.deleteParent = function (id) {
        ParentsModalService.showParentsDeleteModal(id);
    };
    var getPage = function (filter, sortColumn) {
        var pageNumb = paginationOptions.pageNumber;
        var sortOpt = 'LastName';
        if (sortColumn) {
            sortOpt = sortColumn;
        }
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


        parentsService.getPage(pageNumb, paginationOptions.pageSize, sortOpt, filter)
            .success(function (data) {
                $scope.parentsGrid.totalItems = data.PageCount;
                $scope.parentsGrid.data = data.Parents;
            });
    }
    getPage();
}]);