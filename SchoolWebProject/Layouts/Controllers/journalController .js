//Define a custom filter to search only visible columns (used with grid 3)
myApp.filter('visibleColumns', function () {
    return function (data, grid, query) {

        matches = [];

        //no filter defined so bail
        if (query === undefined || query === '') {
            return data;
        }

        query = query.toLowerCase();

        //loop through data items and visible fields searching for match
        for (var i = 0; i < data.length; i++) {
            for (var j = 0; j < grid.columnDefs.length; j++) {

                var dataItem = data[i];
                var fieldName = grid.columnDefs[j]['field'];

                //as soon as search term is found, add to match and move to next dataItem
                if (dataItem[fieldName].toString().toLowerCase().indexOf(query) > -1) {
                    matches.push(dataItem);
                    break;
                }
            }
        }
        return matches;
    }
});

myApp.controller('journalController', ['$scope','$filter','$http', 'markService', 'uiGridConstants', function ($scope,$filter,$http, markService, uiGridConstants) {
   
    $scope.subjectsOptions = [];
    $http.get("api/subjects/").success(function (data) {
        for (i = 0; i < data.length; i++) {
            $scope.subjectsOptions[i] = ({ value: data[i].Name, label: data[i].Name });
        }
    });
    
    $scope.subjects = [
                           { value: '1', label: 'Фізика' },
                           { value: '2', label: 'Геометрія' },
                           { value: '3', label: 'Хімія' },
                           { value: '4', label: 'Історія' },
                           { value: '5', label: 'Математика' },
    ];

    $scope.groups = [
                          { value: '1', label: '1a' },
                          { value: '2', label: '2a' },
                          { value: '3', label: '3a' },
                          { value: '4', label: '4a' },
                          { value: '5', label: '5a' },
                          { value: '6', label: '6a' },
                          { value: '7', label: '7a' },
                          { value: '8', label: '8a' },
                          { value: '9', label: '9a' },
                          { value: '10', label: '10a' },
    ];
   
    


   /* $scope.journalGrid = {
       
       columnDefs : [
  {
      field: "№ ",
      cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
      width: "50",
      pinnedLeft: true,
      enableCellEdit: false,
      enableFiltering: false,
  },
   {
       name: "First Name",
       field: 'Pupil.FirstName',
       width: 100,
       pinnedLeft: true,
       
       enableCellEdit: false
   },
       {
           name: "Last Name",
           field: 'Pupil.LastName',
           width: 100,
           pinnedLeft: true,
           enableSorting: true,
           enableCellEdit: false
       },
        
   
   {
       name: 'Group',
       displayName: "Group",
       field: 'Pupil.GroupId',
       width: 200,
       enableSorting: false,
       enableCellEdit: false,
       //visible:false,
       type: 'number',
      

   },
  /* {
       name: 'Date1',
       field: 'Value',
       width: 200,
       enableSorting: true,
       enableFiltering: false,
       enableCellEdit: false,
       order: 210
   }, {
       name: 'Date2',
       field: 'Value',
       width: 200,
       enableSorting: true,
       enableFiltering: false,
       enableCellEdit: false
   }

        ],

        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        }

    };*/

    $scope.filterText;

    $scope.journalGrid = { columnDefs: [{ field: 'Pupil.FirstName' }, { field: 'Pupil.LastName' }, { field: 'Pupil.GroupId' }] };

    $scope.refreshData = function () {
        $scope.journalGrid.data = $filter('filter')($scope.Data, $scope.filterText, undefined);
    };
    markService.success(function (data1) {
        $scope.Data = data1;
    });
    
}])