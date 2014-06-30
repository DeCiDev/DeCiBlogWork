define('vm.blogentries',
    ['jquery', 'underscore', 'ko', 'datacontext', 'router', 'sort', 'event.delegates', 'utils', 'messenger', 'config'],
    function ($, _, ko, datacontext, router, sort, eventDelegates, utils, messenger, config) {
        var
            isRefreshing = false,
            blogentryTemplate = 'blogentries.view',
            blogentries = ko.observableArray(),
            categories = ko.observableArray(),
            links = ko.observableArray(),

            activate = function (routeData, callback) {
                messenger.publish.viewModelActivated({ canleaveCallback: canLeave });
                getCategories();
                getLinks();
                getBlogentries(callback);
            },

            canLeave = function () {
                return true;
            },

            dataOptions = function (force) {
                return {
                    results: blogentries,
                    sortFunction: sort.blogentriesSort,
                    forceRefresh: force
                };
            },

            forceRefreshCmd = ko.asyncCommand({
                execute: function (complete) {
                    $.when(datacontext.blogentries.getData(dataOptions(true)))
                        .always(complete);
                }
            }),

            getBlogentries = function (callback) {
                if (!isRefreshing) {
                    isRefreshing = true;
                    $.when(datacontext.blogentries.getData(dataOptions(false)))
                        .always(utils.invokeFunctionIfExists(callback));
                    isRefreshing = false;
                }

            },

            getCategories = function () {
                if (!categories().length) {
                    datacontext.categories.getData({
                        results: categories,
                        sortFunction: sort.categoriesSort
                    });
                }
            },

            getLinks = function () {
                if (!links().length) {
                    datacontext.links.getData({
                        results: links,
                        sortFunction: sort.linksSort
                    });
                }
            },

            gotoDetails = function (selectedBlogentry) {
                if (selectedBlogentry && selectedBlogentry.id()) {
                    router.navigateTo(config.hashes.blogentries + '/' + selectedBlogentry.id());
                }
            },

            init = function () {
                // Bind jQuery delegated events
                eventDelegates.blogentriesListItem(gotoDetails);
                activate();
            };

        init();

        return {
            activate: activate,
            canLeave: canLeave,
            forceRefreshCmd: forceRefreshCmd,
            blogentries: blogentries,
            categories: categories,
            blogentryTemplate: blogentryTemplate,
            links: links
        };
    });