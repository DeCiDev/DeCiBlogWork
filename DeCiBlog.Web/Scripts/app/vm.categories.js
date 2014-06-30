define('vm.categories',
    ['ko', 'underscore', 'datacontext', 'config', 'router', 'messenger', 'sort'],
    function (ko, _, datacontext, config, router, messenger, sort) {
        var
            categories = ko.observableArray(),
            tmplName = 'categories.view',

            activate = function (routeData, callback) {
                messenger.publish.viewModelActivated({ canleaveCallback: canLeave });
                refresh(callback);
            },

            canLeave = function () {
                return true;
            },

            dataOptions = function (force) {
                return {
                    results: categories,
                    sortFunction: sort.categoriesSort,
                    forceRefresh: force
                };
            },

            forceRefreshCmd = ko.asyncCommand({
                execute: function (complete) {
                    $.when(datacontext.categories.getData(dataOptions(true)))
                        .always(complete);
                }
            }),

            getCategories = function (callback) {
                datacontext.categories.getData({
                    results: categories,
                    sortFunction: sort.categoriesSort
                });
                if (_.isFunction(callback)) { callback(); }
            },

            gotoDetails = function (selectedCategorie) {
                if (selectedCategorie && selectedCategorie.id()) {
                    router.navigateTo(config.hashes.categories + '/' + selectedCategorie.id());
                }
            },

            refresh = function (callback) {
                getCategories(callback);
            },

            init = function () {
                activate();
            };

        init();

        return {
            activate: activate,
            canLeave: canLeave,
            forceRefreshCmd: forceRefreshCmd,
            gotoDetails: gotoDetails,
            categories: categories,
            tmplName: tmplName
        };
    });