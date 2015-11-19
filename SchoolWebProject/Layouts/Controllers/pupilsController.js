myApp.controller('pupilsController', ['$scope', 'pupils', 'uiGridConstants', 'PupilsModalService', function ($scope, pupils, uiGridConstants, PupilsModalService) {
    $scope.text = "List of pupils:";

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
       name: "LastName",
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
       field: "FirstName",
       width: "*",
       enableSorting:false,
       enableFiltering: false
   },
   {
       field: "PhoneNumber",
       width: "*",
       enableFiltering: false,
       enableSorting: false
   },
   {
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
       field: "Profile",
       cellTemplate: '<div><a ng-href="#/pupil/{{row.entity.Id}}" style="width: 70px;">Profile</a></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
   },
   {
       field: "Delete",
       cellTemplate: '<div><button ng-click="grid.appScope.deletePupil(row.entity.Id, row.entity.LastName)" style="width: 70px;">Delete</button></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
   }
     ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;

            $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                console.log('sorting changed!!');
                if (sortColumns.length == 0) {
                    paginationOptions.sort = null;
                } else {
                    paginationOptions.sort = sortColumns[0].sort.direction;
                }
                var grid = this.grid;
                var val = '';
                val = grid.columns[1].filters[0].term;
                getPage(val);
            });

            $scope.gridApi.core.on.filterChanged( $scope, function() {
                var grid = this.grid;
                var val = '';
                val = grid.columns[1].filters[0].term;
                    getPage(val);
            });

            $scope.gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                paginationOptions.pageNumber = newPage;
                paginationOptions.pageSize = pageSize;

                var grid = this.grid;
                var val = '';
                val = grid.columns[1].filters[0].term;
                getPage(val);
            });
        }
    };

    var paginationOptions = {
        pageNumber: 1,
        pageSize: 25,
        sort: null
    };

    $scope.editHandler = function (value) {
        PupilsModalService.showPupilsEditPage();
    };

    $scope.deletePupil = function (id, lastName) {
        var val = {id: id, lastName: lastName};
        PupilsModalService.showPupilsDeleteModal(val);
    };

    var getPage = function (filter) {
        var pageNumb = paginationOptions.pageNumber;
        var sortDir = '';
        switch (paginationOptions.sort) {
            case uiGridConstants.ASC:
                sortDir = 'asc';
                break;

            case uiGridConstants.DESC:
                sortDir = 'desc';
                break;

            default:
                sortDir = 'asc';
                break;
        }

        pupils.getPage(pageNumb, paginationOptions.pageSize, sortDir, filter)
            .success(function (data) {
            $scope.pupilsGrid.totalItems = data.PageCount;
            $scope.pupilsGrid.data = data.Pupils;
        });
    }
    getPage();
}
]);


