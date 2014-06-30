define('dataprimer',
    ['ko', 'datacontext', 'config'],
    function (ko, datacontext, config) {

        var logger = config.logger,

            fetch = function () {

                return $.Deferred(function (def) {

                    var data = {
                        blogentries: ko.observableArray(),
                        links: ko.observableArray(),
                        categories: ko.observableArray()
                    };

                    $.when(
                        datacontext.blogentries.getData({ results: data.blogentries }),
                        datacontext.links.getData({ results: data.links }),
                        datacontext.categories.getData({ results: data.categories })
                    )

                    .pipe(function () {
                        logger.success('Daten für: '
                            + '<div>' + data.blogentries().length + ' Blog-Einträge </div>'
                            + '<div>' + data.links().length + ' Blog-Roll Links </div>'
                            + '<div>' + data.categories().length + ' Kategorien </div>'
                        );
                    })

                    .fail(function () { def.reject(); })

                    .done(function () { def.resolve(); });

                }).promise();
            };

        return {
            fetch: fetch
        };
    });