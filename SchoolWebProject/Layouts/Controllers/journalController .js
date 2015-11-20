myApp.controller('journalController', ['$scope', 'journalService', 'subjects', 'groups', 'uiGridConstants', function ($scope, journalService, subjects, groups, uiGridConstants) {
    

    $scope.chosenSubject = null;
    $scope.chosenGroup = null;
    $scope.lessonDetail = {
        date: "some",
        theme: null,
        hometask: null,
        showHomeTask: false
    };
    $scope.showHomeTask = false;
    $scope.getLessonDetails = function (date) {
        alert(date);
        $scope.showHomeTask = true;
        $scope.lessonDetail.date = date;
    }

    $scope.journalGrid = {
        showGridFooter: true,
        columnDefs: [],
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
                $scope.journalGrid.columnDefs = [{
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
        }];
                pupilsMarks = [];
                $scope.data = data;
                fillMarks();
                for (var i = 0; i < $scope.data.LessonDetails.length; ++i) {
                    var arrdate = $scope.data.LessonDetails[i].Date.toString().slice(5, 10).split("-");
                    var date = arrdate[1] + "/" + arrdate[0];
                    $scope.journalGrid.columnDefs.push({
                        name: date,
                        headerCellTemplate: '<div ng-controller="journalController" class="ui-grid-header-cell" ng-click="getLessonDetails(col.field)">{{col.name}}</div>',
                        field: $scope.data.LessonDetails[i].Date.toString(),
                        width: "*",
                        pinnedLeft: false,
                        enableCellEdit: false,
                        enableFiltering: false,
                        enableSorting: false
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