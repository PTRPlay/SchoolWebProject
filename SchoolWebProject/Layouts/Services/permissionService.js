myApp.factory('permissionService', ['$location', 'currentUser', function ($location, currentUser) {

    return {
        redirection: '/permissionerror',

        user: JSON.parse(currentUser),

        showAddNews: function () {
            if (this.user.Role == "Admin" || this.user.Role == "Teacher") {
                return true;
            } else {
                return false;
            }
        },

        isValidRoleForChooseGroupsForJournal: function(){
            if (this.user.Role == 'Admin' || this.user.Role == 'Teacher'){
                return true;
            }
            else return false;
        },

        isValidRoleForEditMark: function (LessonDetailTeacherId) {
            if (this.user.Role == "Admin" || this.user.Id == LessonDetailTeacherId) {
                return true;
            }
            else return false;
        },

        showGroups: function () {
            if (this.user.Role == "Pupil" || this.user.Role == "Parent") {
                $location.path(this.redirection);
            } else {
                return true;
            }
        },

        showPupils: function () {
            if (this.user.Role == "Pupil" || this.user.Role == "Parent") {
                $location.path(this.redirection);
            } else {
                return true;
            }
        },

        showParents: function () {
            if (this.user.Role == "Parent") {
                $location.path(this.redirection);
            } else {
                return true;
            }
        },

        showParentsGrid: function () {
            if (this.user.Role == "Parent" || this.user.Role == "Pupil") {
                $location.path(this.redirection);
            } else {
                return true;
            }
        },


        showTeachers: function () {
            if (this.user.Role == "Pupil") {
                $location.path(this.redirection);
            } else {
                return true;
            }
        },

        showAddEditTeacher: function () {
            if (this.user.Role == "Admin") {
                return true;
            } else {
                return false;
            }
        },

        showEditSchedule: function () {
            if (this.user.Role == "Admin" || this.user.Role == "Teacher") {
                return true;
            } else {
                return false;
            }
        },

        fileSchedule: function () {
            if (this.user.Role == "Admin") {
                return true;
            } else {
                return false;
            }
        }
    }
}])