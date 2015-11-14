myApp.controller('pupilsController', ['$scope', 'pupils', 'uiGridConstants', 'PupilsModalService', function ($scope, pupils, uiGridConstants, PupilsModalService) {
    $scope.text = "List of pupils:";
    
    $scope.pupilsGrid = {
        //showGridFooter: true,
        enableSorting: true,
        enableFiltering: true,
        enablePaginationControls: true,
        paginationPageSizes: [25, 50, 75],
        paginationPageSize: 25,
        useExternalPagination: true,
        useExternalSorting: true,

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
       //cellTemplate: '<div><button ng-click="grid.appScope.editHandler(row.entity.Id)" style="width: 70px;">Edit</button></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
   },
   {
       field: "Delete",
       cellTemplate: '<div><button ng-click="grid.appScope.deleteHandler(row.entity.LastName)" style="width: 70px;">Delete</button></div>',
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
                getPage();
            });
            gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                paginationOptions.pageNumber = newPage;
                paginationOptions.pageSize = pageSize;
                getPage();
            });
        }
    };

    var paginationOptions = {
        pageNumber: 1,
        pageSize: 25,
        sort: null
    };

    $scope.editHandler = function (value) {
        //alert('Editing ' + value + ' !');
        PupilsModalService.showPupilsEditPage();
    };

    $scope.deleteHandler = function (value) {
        //alert('Wanna delete ' + value + ' ?');
        PupilsModalService.showPupilsDeleteModal();
    };

    var getPage = function () {
        var sortDir = '';
        var pageNumb = paginationOptions.pageNumber;
        $scope.pupilsGrid.totalItems = 99;
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
        pupils.getPage(pageNumb, paginationOptions.pageSize, sortDir).success(function (data) {
           
            $scope.pupilsGrid.data = data;
        });
    }
    getPage();
}
]);


