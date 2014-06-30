define('vm.links',
    ['ko', 'underscore', 'datacontext', 'config', 'router', 'messenger', 'sort'],
    function (ko, _, datacontext, config, router, messenger, sort) {
        var
            links = ko.observableArray(),
            tmplName = 'links.view',

            activate = function (routeData, callback) {
                messenger.publish.viewModelActivated({ canleaveCallback: canLeave });
                refresh(callback);
            },

            canLeave = function () {
                return true;
            },

            dataOptions = function (force) {
                return {
                    results: links,
                    sortFunction: sort.linksSort,
                    forceRefresh: force
                };
            },

            forceRefreshCmd = ko.asyncCommand({
                execute: function (complete) {
                    $.when(datacontext.links.getData(dataOptions(true)))
                        .always(complete);
                }
            }),

            getLinks = function (callback) {
                datacontext.links.getData({
                    results: links,
                    sortFunction: sort.linksSort
                });
                if (_.isFunction(callback)) { callback(); }
            },

            gotoDetails = function (selectedLink) {
                if (selectedLink && selectedLink.id()) {
                    router.navigateTo(config.hashes.links + '/' + selectedLink.id());
                }
            },

            refresh = function (callback) {
                getLinks(callback);
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
            links: links,
            tmplName: tmplName
        };
    });