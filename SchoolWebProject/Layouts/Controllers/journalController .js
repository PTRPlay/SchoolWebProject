

myApp.controller('journalController', ['$scope', 'markService','subjects','groups', 'uiGridConstants', function ($scope, markService,subjects,groups, uiGridConstants) {
    
   
    $scope.chosenSubject=null;
    $scope.chosenGroup=null;

    $scope.journalGrid = {
        showGridFooter: true,
        enableFiltering: true,
        columnDefs: [
   {
       field: "№ ",
       cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
       width: "50",
       pinnedLeft: true,
       enableCellEdit: false,
       enableFiltering: false,
   },
   {
       field: "firstName",
       width: "100",
       pinnedLeft: false,
       enableCellEdit: false,
       enableFiltering: false
   }

        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        }

    };

    var pupilsMarks = [];

    var AddPupil = function (Pupil) {
        pupilsMarks.push({
            id: Pupil.Id,
            firstName: Pupil.FirstName,
            lastName: Pupil.LastName
        });
    }

    var fillPupils = function () {
        for (var i = 0; i < data.Pupils.length; ++i) {
            AddPupil(data.Pupils[i]);
        }
        for (var i = 0; i < pupilsMarks.length; ++i){
            for (var j = 0; j < data.LessonDetails.length; ++j){
                pupilsMarks[i][data.LessonDetails[j].Date.toString()] = null;
            }
        }
    }

    var fillMarks = function () {
        fillPupils();
        for (var i = 0; i < pupilsMarks.length; ++i) {
            for (var j = 0; j < data.Marks.length; ++j) {
                if (data.Marks.Pupil.FirstName == pupilsMarks[i].firstName && data.Marks.Pupil.LastName == pupilsMarks[i].LastName) {
                    pupilsMarks[i][data.Marks.LessonDetail.Date.toString()] = data.Marks.Value;
                }
            }
        }
    }

    fillMarks();

    $scope.GetJournalPage = function (chosenSubject,chosenGroup)
    {
        if (chosenGroup != null && chosenSubject != null)
            markService.getPage(chosenSubject, chosenGroup).success(function (data) {
                $scope.data = data;
            });
    }

    subjects.success(function (data) {
        $scope.subjectsOptions = data;
    });

    groups.success(function (data) {
        $scope.groupsOptions = data;
    });
}])