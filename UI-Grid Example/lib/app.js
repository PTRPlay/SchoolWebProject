var app = angular.module('app', ['ngAnimate', 'ngTouch', 'ui.grid', 'ui.grid.moveColumns']);

app.controller('MainCtrl', ['$scope', '$http', 'uiGridConstants', function ($scope, $http, uiGridConstants) {
    $scope.topMovies = [
        {
            name: "The Shawshank Redemption",
            year: 1994,
            rating: 9.2
        },
        {
            name: "The Godfather",
            year: 1972,
            rating: 9.2
        },
        {
            name: "The Godfather: Part II",
            year: 1974,
            rating: 9.0
        },
        {
            name: "The Dark Knight",
            year: 2008,
            rating: 8.9
        },
        {
            name: "12 Angry Men",
            year: 1957,
            rating: 8.9
        }
    ];

    //show a text after clicking on a button
    $scope.someProp = 'abc',
$scope.showMe = function () {
    alert($scope.someProp);
};

    $scope.hideGrid = true;

    $scope.gridOptions = {
        showGridFooter: true,
        showColumnFooter: true,
        enableSorting: true,
        enableFiltering: true,

        columnDefs: [
      {
          field: 'name',
          headerCellClass: $scope.highlightFilteredHeader,
          sort: {
              direction: uiGridConstants.ASC,
              priority: 1
          }
      },
     {
         field: 'gender',
         enableFiltering: false
     },
     {
         field: 'email'
     },
     {
         field: 'phone'
     },
     {
         field: 'age', filters: [
        {
            condition: uiGridConstants.filter.GREATER_THAN,
            placeholder: 'greater than'
        }],
         aggregationType: uiGridConstants.aggregationTypes.avg, aggregationHideLabel: true,
         headerCellClass: $scope.highlightFilteredHeader
     },
      // no filter input
      { field: 'company', enableSorting: false },
      //button
      {
          name: 'Button',
          cellTemplate: '<button class="btn primary" ng-click="grid.appScope.showMe()">Click Me</button>',
      }
        ],
        onRegisterApi: function (gridApi) {
            $scope.grid1Api = gridApi;
        }
    };

    $scope.text = "List of top ranked movies";

    //marks column header as header-filtered class
    $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
        if (col.filters[0].term) {
            return 'header-filtered';
        } else {
            return '';
        }
    };


    $http.get('https://cdn.rawgit.com/angular-ui/ui-grid.info/gh-pages/data/500_complex.json')
     .success(function (data) {
         $scope.gridOptions.data = data;

     });
}]);