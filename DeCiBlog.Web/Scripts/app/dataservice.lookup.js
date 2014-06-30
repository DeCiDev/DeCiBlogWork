define('dataservice.lookup',
    ['amplify'],
    function (amplify) {
        var
            init = function () {

                amplify.request.define('lookups', 'ajax', {
                    url: '/api/lookups/all',
                    dataType: 'json',
                    type: 'GET'
                    //cache:
                }),

                amplify.request.define('tags', 'ajax', {
                    url: '/api/lookups/tags',
                    dataType: 'json',
                    type: 'GET'
                    //cache:
                }),

                amplify.request.define('links', 'ajax', {
                    url: '/api/lookups/links',
                    dataType: 'json',
                    type: 'GET'
                    //cache:
                }),

                amplify.request.define('categories', 'ajax', {
                    url: '/api/lookups/categories',
                    dataType: 'json',
                    type: 'GET'
                    //cache:
                });
            },

            getLookups = function (callbacks) {
                return amplify.request({
                    resourceId: 'lookups',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },

            getTags = function (callbacks) {
                return amplify.request({
                    resourceId: 'tags',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },

            getLinks = function (callbacks) {
                return amplify.request({
                    resourceId: 'links',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },

            getCategories = function (callbacks) {
                return amplify.request({
                    resourceId: 'categories',
                    success: callbacks.success,
                    error: callbacks.error
                });
            };

        init();

        return {
            getLookups: getLookups,
            getTags: getTags,
            getLinks: getLinks,
            getCategories: getCategories
        };
    });