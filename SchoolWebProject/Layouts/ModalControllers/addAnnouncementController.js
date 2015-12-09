myApp.controller("announcementAddController", ['$scope', '$element', 'title', 'close', 'Announcement', function ($scope, $element, title, close, Announcement) {
    $scope.announcement = null;
    $scope.IsFormValid = true;

    if (Announcement != null) {
        var dateParsed;
        if (Announcement.DataPublished != null) {
            var dateParsed = Announcement.DataPublished.split('.');
        }
        $scope.announcement = {
            id: Announcement.Id,
            image: Announcement.Image,
            title: Announcement.Title,
            message: Announcement.Message,
            messageDetails: Announcement.MessageDetails,
            dataPublished: dateParsed != null ? new Date(dateParsed[2], dateParsed[1], dateParsed[0]) : new Date(),
        };
    }
    else {
        $scope.announcement = {
            id: null,
            image: null,
            title: null,
            message: null,
            messageDetails: null,
            dataPublished: new Date(),
        };
    }

     $scope.close = function () {
        $element.modal('hide');
        close({
            cancelled: false,
            id: $scope.announcement.id,
            image: $scope.announcement.image != null ? $scope.announcement.image.base64 : null,
            title: $scope.announcement.title,
            message: $scope.announcement.message,
            messageDetails: $scope.announcement.messageDetails,
            dataPublished: $scope.announcement.dataPublished,
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');

        close(null, 500);
    }
}]);