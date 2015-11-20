myApp.controller('pupilsController', ['$scope', 'pupils', 'uiGridConstants', 'PupilsModalService', function ($scope, pupils, uiGridConstants, PupilsModalService) {
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
   },
   {
       name: "Прізвище",
       field: "LastName",
       width: "*",
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
       //enableSorting:false,
       enableFiltering: false
   },
   {
       name: "Телефон",
       field: "PhoneNumber",
       width: "*",
       enableFiltering: false,
       enableSorting: false
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
       name: "Профіль",
       field: "Profile",
       cellTemplate: '<div><a ng-href="#/pupil/{{row.entity.Id}}" style="width: 70px;">Профіль</a></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
   },
   {
       name: "Видалити",
       field: "Delete",
       cellTemplate: '<div><button ng-click="grid.appScope.deletePupil(row.entity.Id, row.entity.LastName)" style="width: 70px;">Видалити</button></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
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

            $scope.gridApi.core.on.filterChanged( $scope, function() {
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

    $scope.addPupil = function () {
        PupilsModalService.showPupilsEditPage();
    };

    $scope.editPupil = function (value) {
        PupilsModalService.showPupilsEditPage(value);
    };

    $scope.deletePupil = function (id, lastName) {
        var val = {id: id, lastName: lastName};
        PupilsModalService.showPupilsDeleteModal(val);
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
        

        pupils.getPage(pageNumb, paginationOptions.pageSize, sortOpt, filter)
            .success(function (data) {
            $scope.pupilsGrid.totalItems = data.PageCount;
            $scope.pupilsGrid.data = data.Pupils;
        });
    }
    getPage();
}
]);


