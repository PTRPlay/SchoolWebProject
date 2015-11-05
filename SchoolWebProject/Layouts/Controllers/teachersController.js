myApp.controller('teachersController', ['$scope', 'teachers', function ($scope, teachers) {
    teachers.success(function (data) {
        $scope.teachers = data;
<<<<<<< HEAD:SchoolWebProject/Layouts/Controllers/teacherController.js
    });
}
]);
=======

    });
}]);
>>>>>>> f09ae0da4506b80da934c1ee301feaaab328e6c1:SchoolWebProject/Layouts/Controllers/teachersController.js
