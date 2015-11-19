myApp.controller('journalController', ['$scope', 'journalService', 'subjects', 'groups', 'uiGridConstants', function ($scope, journalService, subjects, groups, uiGridConstants) {
    

    $scope.chosenSubject = null;
    $scope.chosenGroup = null;

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
            name: "Учень",
            field: "name",
            width: "200",
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
            name: Pupil.LastName + ' ' + Pupil.FirstName
        });
    }

    var fillPupils = function () {
        for (var i = 0; i < $scope.data.Pupils.length; ++i) {
            AddPupil($scope.data.Pupils[i]);
        }
        for (var i = 0; i < pupilsMarks.length; ++i) {
            for (var j = 0; j < $scope.data.LessonDetails.length; ++j) {
                pupilsMarks[i][$scope.data.LessonDetails[j].Date.toString()] = null;
            }
        }
    }

    var getDateByLessonDetailId = function (id) {
        for (var i = 0; i < $scope.data.LessonDetails.length; ++i) {
            if (id == $scope.data.LessonDetails[i].Id) {
                return $scope.data.LessonDetails[i].Date.toString();
            }
        }
        return null;
    }

    var fillMarks = function () {
        fillPupils();
        for (var i = 0; i < pupilsMarks.length; ++i) {
            for (var j = 0; j < $scope.data.Marks.length; ++j) {
                if ($scope.data.Marks[j].PupilId == pupilsMarks[i].id) {
                    pupilsMarks[i][getDateByLessonDetailId($scope.data.Marks[j].LessonDetailId)] = $scope.data.Marks[j].Value;
                }
            }
        }
    }
    $scope.GetJournalPage = function (chosenSubject, chosenGroup) {
        if (chosenGroup != null && chosenSubject != null)
            journalService.getPage(chosenSubject, chosenGroup).success(function (data) {
                pupilsMarks = [];
                $scope.data = data;
                fillMarks();
                for (var i = 0; i < $scope.data.LessonDetails.length; ++i) {
                    var date = $scope.data.LessonDetails[i].Date.toString();
                    $scope.journalGrid.columnDefs.push({
                        name: date.slice(5,10),
                        field: date,
                        width: "*",
                        pinnedLeft: false,
                        enableCellEdit: false,
                        enableFiltering: false
                    });
                }
                $scope.journalGrid.data = pupilsMarks;
            });
    }

    subjects.success(function (data) {
        $scope.subjectsOptions = data;
    });

    groups.success(function (data) {
        $scope.groupsOptions = data;
    });
}])