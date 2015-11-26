myApp.controller('teachersController', ['$scope', '$http', 'teachersService', 'categories', 'uiGridConstants', function ($scope, $http, teachersService, categories, uiGridConstants) {

    var id, value,label;
    var categoriesOptions = [];
    $http.get("api/teachercategory/").success(function (data) {
        for (i = 0; i < data.length; i++) {
            categoriesOptions[i]=({ value: data[i].Name, label: data[i].Name });
        }
    });

    var subjectsOptions= [];
    $http.get("api/subjects/").success(function (data) {
        for (i = 0; i < data.length; i++) {
            subjectsOptions[i] = ({ value: data[i].Name, label: data[i].Name });
        }
    });

    var categoriesOptions2 = [];

    $scope.getSubjects = function (Id) {
        teachersService.getTeachers()
            .success(function (data) {
            for (i = 0; i < data[Id].Subjects.length; i++) {
                categoriesOptions2[i] = ({ id: i, value: data[Id].Subjects[i].Name });
            }
            return data
        })
        return categoriesOptions2
    };


    $scope.getCurrentFocus = function () {
        var rowCol = $scope.gridApi.cellNav.getFocusedCell();
        return rowCol;
    }


    $scope.teachersGrid = {
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
       enableHiding: false,
       enableColumnMenu: false
   },

   {
       enableFiltering: false,
       field: 'LastName',
       displayName: 'Прізвище',
       enableHiding: false

   },
   {
       enableFiltering: false,
       field: 'FirstName',
       displayName: 'Ім`я',
       enableHiding: false
   },   
   {
       enableFiltering:false,
       field: "MiddleName",
       displayName: 'По батькові',
       enableHiding: false
   },
   {
       enableFiltering:true,
       field: "Category.Name",
       displayName:'Категорія',
       filter: {
           type: uiGridConstants.filter.SELECT,
           selectOptions: categoriesOptions
       },
       enableHiding: false
   },

   {
       enableFiltering: true,
       field: "Subjects[0].Name",
       cellTemplate: '<select  class="form-control" id="subject" ng-model="teachers.Subjects"><option ng-repeat="subject in row.entity.Subjects" value="" value="{{subject.Name}}" selected>{{subject.Name}}</option></select>',
       displayName: 'Предмет',
       filter: {
           type: uiGridConstants.filter.SELECT,
           selectOptions: subjectsOptions
       },
       enableCellEdit: false,
       enableHiding: false,
       },



   {
       field: "Profile",
       displayName: 'Профіль',
       cellTemplate: '<div><a title="Профіль {{row.entity.LastName}} {{row.entity.FirstName}}" ng-href="#/teacher/{{row.entity.Id}}" style="width: 70px;"><img src="/Layouts/Images/user.png"></a></div>',
       width: "30", 
       enableFiltering: false,
       enableCellEditOnFocus:false,
       enableSorting: false,
       enableHiding: false,
       enableColumnMenu: false
   },

        ],
        onRegisterApi: function (gridApi) {
            $scope.grid2Api = gridApi;
        }
    };

    teachersService.getTeachers()
        .success(function (data) {
        $scope.teachersGrid.data = data;
    })
    $scope.toggleFiltering = function(){
        $scope.gridOptions.enableFiltering = !$scope.gridOptions.enableFiltering;
        $scope.gridApi.core.notifyDataChange(uiGridConstants.dataChange.COLUMN);
        
    };
}])