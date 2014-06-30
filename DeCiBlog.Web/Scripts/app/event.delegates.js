define('event.delegates',
    ['jquery', 'ko', 'config'],
    function ($, ko, config) {
        var
            blogentrySelector = '.blogentry',

            bindEventToList = function(rootSelector, selector, callback, eventName) {
                var eName = eventName || 'click';
                $(rootSelector).on(eName, selector, function() {
                    //var context = ko.contextFor(this);
                    //var session = context.$data;
                    var entry = ko.dataFor(this);
                    callback(entry);
                    return false;
                });
            },


            blogentriesListItem = function(callback, eventName) {
                bindEventToList(config.viewIds.blogentries, blogentrySelector, callback, eventName);
            };
            
        return {
            blogentriesListItem: blogentriesListItem
        };
    });

