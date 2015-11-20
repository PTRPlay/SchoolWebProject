myApp.controller("degreeAddController", ['$scope', '$element', '$http', 'title', 'close', 'Degree', function ($scope, $element, $http, title, close, Degree) {
    $scope.degree = null;
    $scope.IsFormValid = true;
    if (Degree != null) {

        $scope.degree = {
            id: Degree.Id,
            name: Degree.Name,
        };
    }
    else {
        $scope.degree = {
            Id: null,
            Name: null
        };
    }

    $scope.close = function () {
        $element.modal('hide');
        close({
            cancelled: false,
            id: $scope.degree.id,
            name: $scope.degree.name,
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
       cellTemplate: '<div><button ng-click="grid.appScope.editTeacherDegree(row.entity.Id, row.entity.Name)" style="width: 80px;">Save</button></div>',
       width: "80",
       enableFiltering: false,
       enableCellEdit: false,
       enableSorting: false
    },

    {
       field: "Delete",
       cellTemplate: '<div><button ng-click="grid.appScope.deleteTeacherDegree(row.entity.Id)" style="width: 80px;">Delete</button></div>',
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

    $http.get("api/teacherdegree").success(function (data) {
        $scope.categoriesGrid.data = data;
        //return data;
    })

    $scope.deleteTeacherDegree = function (id) {
        if (id != null) {
            $http.delete("api/teacherdegree/" + id);
        $scope.gridApi.core.refresh();
            window.location.reload("/");
        }
    };

    $scope.editTeacherDegree = function (id, result) {
        var editedTeacherDegree ={id : id, name : result}
        $http.post("api/teacherdegree/" + id, editedTeacherDegree);
        $scope.gridApi.core.refresh();
                window.location.reload("/");
        }



    $scope.currentFocused = "";
    $scope.getCurrentFocus = function () {
        var rowCol = $scope.grid1Api.cellNav.getFocusedCell();
        if (rowCol !== null) {
            $scope.currentFocused = rowCol.row.entity.Id;
            alert($scope.currentFocused);
        }
        
    }

}]);