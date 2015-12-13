myApp.controller("degreeAddController", ['$scope', '$element', '$http', '$state','$stateParams','title', 'close', 'Degree', function ($scope, $element, $http, $state, $stateParams, title, close, Degree) {
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
       field: "Опції",
       cellTemplate: '<div><a title="Зберегти зміни" href="#/teachers" ng-click="grid.appScope.editTeacherDegree(row.entity.Id, row.entity.Name)" >   <img src="Layouts/Images/ok.png"></a>' +
           '<a title="Видалити звання {{row.enity.Name}}" href="#/teachers" ng-click="grid.appScope.deleteTeacherDegree(row.entity.Id)">   <img src="Layouts/Images/remove.png"></a></div>',
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
            $http.delete("api/teacherdegree/" + id)
                .success(function () {
                $state.go('teachers', { start: $stateParams.start }, { reload: true });
            });
            $scope.gridApi.core.refresh();

        }
    };

    $scope.editTeacherDegree = function (id, result) {
        var editedTeacherDegree ={id : id, name : result}
        $http.post("api/teacherdegree/" + id, editedTeacherDegree)
                .success(function () {
                    $state.go('teachers', { start: $stateParams.start }, { reload: true });
                });
        $scope.gridApi.core.refresh();
        }

}]);