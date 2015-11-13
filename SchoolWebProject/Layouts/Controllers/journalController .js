

myApp.controller('journalController', ['$scope', 'markService', 'uiGridConstants', function ($scope, markService, uiGridConstants) {
    $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
        if (col.filters[0].term) {
            return 'header-filtered';
        } else {
            return '';
        }
    };

    $scope.choosenSubject;

    $scope.subjects = [
                           { value: '1', label: 'Фізика' },
                           { value: '2', label: 'Геометрія' },
                           { value: '3', label: 'Хімія' },
                           { value: '4', label: 'Історія' },
                           { value: '5', label: 'Математика' },
    ];

   
    


    $scope.journalGrid = {
        showGridFooter: true,
        enableFiltering: true,
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
       enableFiltering: false,
       enableCellEdit: false
   },
       {
           name: "Last Name",
           field: 'Pupil.LastName',
           width: 100,
           pinnedLeft: true,
           enableSorting: true,
           enableFiltering: false,
           enableCellEdit: false
       },
        
   {
       name: 'Subject',
       displayName: "Subject",
       field: 'LessonDetail.ScheduleId',
       width: 200,
       enableSorting: false,
       enableCellEdit: false,
       enableFiltering: true

   },
   {
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

    };

    markService.success(function (data1) {
        $scope.journalGrid.data = data1;
    });
    
}])