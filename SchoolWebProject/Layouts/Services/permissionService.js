myApp.factory('permissionService', ['$location', function ($location) {

    return {
     redirection : '/permissionerror',

     showAddNews : function () {
            if (window.currentUser.Role == "Admin" || window.currentUser.Role == "Teacher") {
                return true;
            } else {
                return false;
            }
        },

    showGroups : function () {
        if (window.currentUser.Role == "Pupil" || window.currentUser.Role == "Parent") {
            $location.path(this.redirection);
        } else {
            return true;
        }
    },

    showPupils : function () { 
        if (window.currentUser.Role == "Pupil" || window.currentUser.Role == "Parent") {
            $location.path(this.redirection);
        } else {
            return true;
        }
    },

    showParents : function () { 
        if (window.currentUser.Role == "Parent") {
            $location.path(this.redirection);
        } else {
            return true;
        }
    },

    showParentsGrid: function () { 
        if (window.currentUser.Role == "Parent" || window.currentUser.Role == "Pupil") {
            $location.path(this.redirection);
        } else {
            return true;
        }
    },


    showTeachers : function () { 
        if (window.currentUser.Role == "Pupil") {
            $location.path(this.redirection);
        } else {
            return true;
        }
    },

    showAddEditTeacher : function () { 
        if (window.currentUser.Role == "Admin") {
            return true;
        } else {
            return false;
        }
    },

    showEditSchedule : function () { 
        if (window.currentUser.Role == "Admin" || window.currentUser.Role == "Teacher") {
            return true;
        } else {
            return false;
        }
    },

    fileSchedule : function () { 
        if (window.currentUser.Role == "Admin") {
            return true;
        } else {
            return false;
        }
    }
}
}])