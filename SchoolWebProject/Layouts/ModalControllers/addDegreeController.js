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
       enableCellEdit: true,
       field: 'Name',
       displayName: 'Категорія'

   },

    {
       field: "Save",
       cellTemplate: '<div><button ng-click="grid.appScope.editTeacherCategory(row.entity.Id, row.entity.Name)" style="width: 80px;">Save</button></div>',
       width: "80",
       enableFiltering: false,
       enableCellEdit: false,
       enableSorting: false
    },

    {
       field: "Delete",
       cellTemplate: '<div><button ng-click="grid.appScope.deleteTeacherCategory(row.entity.Id)" style="width: 80px;">Delete</button></div>',
       width: "80",
       enableFiltering: false,
       enableCellEdit: false,
       enableSorting: false
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

    $scope.deleteTeacherCategory = function (id) {
        if (id != null) {
            $http.delete("api/teachercategory/" + id);
        window.location.reload("/");
        }
    };

    $scope.editTeacherCategory = function (id, result) {
        var editedTeacherCategory ={id : id, name : result}
        $http.post("api/teachercategory/" + id, editedTeacherCategory);
        window.location.reload("/");
        }

}]);