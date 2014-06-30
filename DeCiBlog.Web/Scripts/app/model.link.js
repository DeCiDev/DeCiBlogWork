define('model.link',
    ['ko', 'config'],
    function (ko, config) {
        var
            urlRegEx = /\b((?:[a-z][\w-]+:(?:\/{1,3}|[a-z0-9%])|www\d{0,3}[.]|[a-z0-9.\-]+[.][a-z]{2,4}\/)(?:[^\s()<>]+|\(([^\s()<>]+|(\([^\s()<>]+\)))*\))+(?:\(([^\s()<>]+|(\([^\s()<>]+\)))*\)|[^\s`!()\[\]{};:'".,<>?«»“”‘’]))/i,

            Link = function () {
                var self = this;
                self.id = ko.observable();
                self.name = ko.observable().extend({ required: true });
                self.description = ko.observable();
                self.url = ko.observable().extend({
                    pattern: {
                        message: 'Keine gültige url',
                        params: urlRegEx
                    }
                });
                self.blogentries = ko.observable();

                self.linkHash = ko.computed(function () {
                    return config.hashes.links + '/' + self.id();
                });

                self.isNullo = false;

                self.dirtyFlag = new ko.DirtyFlag([
                    self.name,
                    self.description,
                    self.url]);


                return self;
            };

        Link.Nullo = new Link()
            .id(0)
            .name('Ist kein Link')
            .description('')
            .url('')
            .blogentries([]);

        Link.Nullo.isNullo = true;
        Link.Nullo.dirtyFlag().reset();

        var _dc = null;
        // static member
        Link.datacontext = function (dc) {
            if (dc) { _dc = dc; }
            return _dc;
        };

        return Link;
    });
