define('model.category',
    ['ko'],
    function (ko) {
        var
            Category = function () {
                var self = this;
                self.id = ko.observable();
                self.name = ko.observable();
                self.description = ko.observable();
                self.blogentries = ko.observable();
                self.parent = ko.observable();
                self.children = ko.observable();

                self.dirtyFlag = new ko.DirtyFlag([
                                self.name,
                                self.description,
                                self.categories,
                                self.blogentries,
                                self.parent,
                                self.children]);

                self.isNullo = false;

                return self;
            };


        Category.Nullo = new Category()
            .id(0)
            .name('Keine vorhanden')
            .description('')
            .blogentries([])
            .parent('{}')
            .children([]);


        Category.Nullo.isNullo = true;
        Category.Nullo.dirtyFlag().reset();

        var _dc = null;

        // static member
        Category.datacontext = function (dc) {
            if (dc) { _dc = dc; }
            return _dc;
        };

        return Category;
    });
