//
define('dataservice.blogentry',
    ['amplify'],
    function (amplify) {
        var
            init = function () {

                amplify.request.define('blogentries', 'ajax', {
                    url: '/api/blogentries',
                    dataType: 'json',
                    type: 'GET'
                });


                amplify.request.define('blogentry', 'ajax', {
                    url: '/api/blogentries/{id}',
                    dataType: 'json',
                    type: 'GET'
                });

                amplify.request.define('entryUpdate', 'ajax', {
                    url: '/api/blogentries',
                    dataType: 'json',
                    type: 'PUT',
                    contentType: 'application/json; charset=utf-8'
                });
            },

            getBlogentries = function (callbacks) {
                return amplify.request({
                    resourceId: 'blogentries',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },

            getBlogEntry = function (callbacks, id) {
                return amplify.request({
                    resourceId: 'blogentry',
                    data: { id: id },
                    success: callbacks.success,
                    error: callbacks.error
                });
            },

            updateBlogEntry = function (callbacks, data) {
                return amplify.request({
                    resourceId: 'entryUpdate',
                    data: data,
                    success: callbacks.success,
                    error: callbacks.error
                });
            };

        init();

        return {
            getBlogentries: getBlogentries,
            getBlogEntry: getBlogEntry,
            updateBlogEntry: updateBlogEntry
        };
    });