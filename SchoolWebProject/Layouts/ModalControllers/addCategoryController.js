myApp.controller("categoryAddController", ['$scope', '$element', '$http', 'title', 'close', 'Category', function ($scope, $element, $http, title, close, Category) {
    $scope.category = null;
    $scope.IsFormValid = true;
    if (Category != null) {

        $scope.category = {
            id: Category.Id,
            name: Category.Name,
        };
    }
    else {
        $scope.category = {
            Id: null,
            Name: null
        };
    }

    $scope.close = function () {
        $element.modal('hide');
        close({
            cancelled: false,
            id: $scope.category.id,
            name: $scope.category.name,
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');

        close(null, 500);
    }

    $scope.categoriesGrid = {
        showGridFooter: true,
        enableFiltering: true,
        enableCellEditOnFocus: true,
        columnDefs: [
   {
       field: "№ ",
       cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
       width: "35",
       enableSorting: false,
       enableFiltering: false,
       enableCellEdit: false,
   },

   {
       enableFiltering: false,
       enableCellEdit: false,
       field: 'Name',
       displayName: 'Категорія'

   }

        ],
        onRegisterApi: function (gridApi) {
            $scope.grid1Api = gridApi;
        }
    };

    $http.get("api/teachercategory").success(function (data) {
        $scope.categoriesGrid.data = data;
        //return data;
    })

    $scope.currentFocused = "";
    $scope.getCurrentFocus = function () {
        var rowCol = $scope.grid1Api.cellNav.getFocusedCell();
        if (rowCol !== null) {
            $scope.currentFocused = rowCol.row.entity.Id;
            alert($scope.currentFocused);
        }
        
    }

}]);