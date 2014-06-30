define('vm.blogentry',
    ['ko', 'datacontext', 'config', 'router', 'messenger', 'sort'],
    function (ko, datacontext, config, router, messenger, sort) {

        var
            currentBlogentryId = ko.observable(),
            logger = config.logger,
            links = ko.observableArray(),
            blogentry = ko.observable(),
            categories = ko.observableArray(),
            //validationErrors = ko.observableArray([]),

            validationErrors = ko.computed(function () {
                // We don;t have a blogentry early on. So we return an empty [].
                // Once we get a blogentry, we want to point to its validation errors.
                var valArray = blogentry() ? ko.validation.group(blogentry())() : [];
                return valArray;
            }),

            isDirty = ko.computed(function () {
                return false;
            }),

            isValid = ko.computed(function () {
                return validationErrors().length === 0;
            }),

            activate = function (routeData, callback) {
                messenger.publish.viewModelActivated({ canleaveCallback: canLeave });
                currentBlogentryId(routeData.id);
                getLinks();
                getCategories();
                getBlogentry(callback);
            },

            cancelCmd = ko.asyncCommand({
                execute: function (complete) {
                    var callback = function () {
                        complete();
                        logger.success(config.toasts.retreivedData);
                    };
                    getBlogentry(callback, true);
                },
                canExecute: function (isExecuting) {
                    return !isExecuting && isDirty();
                }
            }),

            goBackCmd = ko.asyncCommand({
                execute: function (complete) {
                    router.navigateBack();
                    complete();
                },
                canExecute: function (isExecuting) {
                    return !isExecuting && !isDirty();
                }
            }),

            canLeave = function () {
                return !isDirty() && isValid();
            },

            getBlogentry = function (completeCallback, forceRefresh) {
                var callback = function () {
                    if (completeCallback) { completeCallback(); }
                };

                datacontext.blogentrys.getFullBlogentryById(
                    currentBlogentryId(), {
                        success: function (s) {
                            blogentry(s);
                            callback();
                        },
                        error: callback
                    },
                    forceRefresh
                );
            },

            getLinks = function () {
                if (!links().length) {
                    datacontext.links.getData({
                        results: links,
                        sortFunction: sort.linksSort
                    });
                }
            },

            getCategories = function () {
                if (!categories().length) {
                    datacontext.categories.getData({
                        results: categories,
                        sortFunction: sort.timeslotSort
                    });
                }
            },

            saveCmd = ko.asyncCommand({
                execute: function (complete) {
                        $.when(datacontext.blogentries.updateData(blogentry()))
                            .always(complete);
                        return;
                },
                canExecute: function (isExecuting) {
                    return !isExecuting && isDirty() && isValid();
                }
            }),


            tmplName = function () {
                return 'blogentry.edit';
            };

        return {
            activate: activate,
            cancelCmd: cancelCmd,
            canLeave: canLeave,
            goBackCmd: goBackCmd,
            isDirty: isDirty,
            isValid: isValid,
            links: links,
            blogentry: blogentry,
            saveCmd: saveCmd,
            categories: categories,
            tmplName: tmplName
        };
    });