myApp.factory('journalService', ['$http', function ($http) {
    return {
        getPage: function (groupId, subjectId) {
            console.log('From service: ' + groupId, subjectId);
            return $http.get('api/journal/' + groupId + '/' + subjectId)
            .success(function (data) {
                return data.get;
            })
            .error(function (data) {
                return data;
            })
        },
        editMark: function (markId, newValue, PupilId, LessonDetailId) {
            $http.post('/api/mark', { id: markId, value: newValue, PupilId: PupilId,LessonDetailId:LessonDetailId }).success(function (data) {
                return data.get;
            })
        }
    }
}]);