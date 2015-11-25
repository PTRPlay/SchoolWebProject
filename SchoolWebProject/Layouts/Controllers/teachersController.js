myApp.controller('teachersController', ['$scope', '$http', 'teachers', 'categories', 'uiGridConstants',  function ($scope, $http, teachers, categories, uiGridConstants) {

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
        teachers.success(function (data) {
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
   },

   {
       enableFiltering: false,
       field: 'LastName',
       displayName:'Прізвище'

   },
   {
       enableFiltering: false,
       field: 'FirstName',
       displayName: 'Ім`я'
   },   
   {
       enableFiltering:false,
       field: "MiddleName",
       displayName:'По батькові'
   },
   {
       enableFiltering:true,
       field: "Category.Name",
       displayName:'Категорія',
       filter: {
           type: uiGridConstants.filter.SELECT,
           selectOptions: categoriesOptions
       },
   },

   {
       enableFiltering: true,
       field: "Subjects[0].Name",
       displayName: 'Предмет',
       filter: {
           type: uiGridConstants.filter.SELECT,
           selectOptions: subjectsOptions
       },
       enableCellEdit: true,
       editableCellTemplate: 'ui-grid/dropdownEditor',
       editDropdownValueLabel: 'value',
       editDropdownOptionsArray: $scope.getSubjects($scope.getCurrentFocus)
       },


   {
       field: "Profile",
       displayName: 'Профіль',
       cellTemplate: '<div><a ng-href="#/teacher/{{row.entity.Id}}" style="width: 70px;"><img src="/Layouts/Images/user.png"></a></div>',
       width: "80", 
       enableFiltering: false,
       enableCellEditOnFocus:false,
       enableSorting: false 
   },

        ],
        onRegisterApi: function (gridApi) {
            $scope.grid2Api = gridApi;
        }
    };

    teachers.success(function (data) {
        $scope.teachersGrid.data = data;
    })
    $scope.toggleFiltering = function(){
        $scope.gridOptions.enableFiltering = !$scope.gridOptions.enableFiltering;
        $scope.gridApi.core.notifyDataChange(uiGridConstants.dataChange.COLUMN);
        
    };
}])