myApp.controller('pupilsController', ['$scope', 'pupils', 'uiGridConstants', function ($scope, pupils, uiGridConstants) {
    $scope.text = "List of pupils:";
    
    $scope.pupilsGrid = {
        //showGridFooter: true,
        enableSorting: true,
        enableFiltering: true,
        enablePaginationControls: true,
        paginationPageSizes: [25, 50, 75],
        paginationPageSize: 25,
        useExternalPagination: true,

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
       field: "Edit",
       cellTemplate: '<div><button ng-click="grid.appScope.editHandler(row.entity.LastName)" style="width: 70px;">Edit</button></div>',
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
            $scope.grid1Api = gridApi;
            gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                paginationOptions.pageNumber = newPage;
                paginationOptions.pageSize = pageSize;
                getPage();
            });
        }
    };
    
    var getPage = function () {
        var url;
        url = 'api/pupils';
    };

    var paginationOptions = {
        pageNumber: 1,
        pageSize: 25,
        sort: null
    };

    $scope.editHandler = function (value) {
        alert('Editing ' + value + ' !');
    };

    $scope.deleteHandler = function (value) {
        alert('Wanna delete ' + value + ' ?');
    };

    var getPage = function () {
        pupils.success(function (data) {
            $scope.pupilsGrid.totalItems = 99;
            var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
            $scope.pupilsGrid.data = data.slice(firstRow, firstRow + paginationOptions.pageSize);;
        });
    }
    getPage();
}
]);
