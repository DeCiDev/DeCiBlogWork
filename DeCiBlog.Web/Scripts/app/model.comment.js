define('model.comment',
    ['ko'],
    function (ko) {
        var Comment = function () {
            var self = this;
            self.id = ko.observable();
            self.name = ko.observable();
            self.created = ko.observable();
            self.userid = ko.observable();
            self.user = ko.observable();
            self.blogentryid = ko.observable();
            self.blogentry = ko.observable();
            return self;
        };

        return Comment;
    });
