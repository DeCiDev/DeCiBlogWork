define('binder',
    ['jquery', 'ko', 'config', 'vm'],
    function ($, ko, config, vm) {
        var
            ids = config.viewIds,

            bind = function () {
                ko.applyBindings(vm.blogentries, getView(ids.blogentries));
                ko.applyBindings(vm.categories, getView(ids.categories));
                ko.applyBindings(vm.blogentry, getView(ids.blogentry));
                ko.applyBindings(vm.category, getView(ids.category));
                ko.applyBindings(vm.shell, getView(ids.shellLeft));
            },

            getView = function (viewName) {
                return $(viewName).get(0);
            };

        return {
            bind: bind
        };
    });