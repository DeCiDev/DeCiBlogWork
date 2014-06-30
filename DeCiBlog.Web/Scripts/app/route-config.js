define('route-config',
    ['config', 'router', 'vm'],
    function (config, router, vm) {
        var
            logger = config.logger,
            
            register = function() {

                var routeData = [

                    // Blogentries routes
                    {
                        view: config.viewIds.blogentries,
                        routes: [
                            {
                                isDefault: true,
                                route: config.hashes.blogentries,
                                title: 'Blogeinträge',
                                callback: vm.blogentries.activate,
                                group: '.route-top'
                            },{
                                route: config.hashes.entriesByDate + '/:date',
                                title: 'Blogeinträge',
                                callback: vm.favorites.activate,
                                group: '.route-left'
                            }
                        ]
                    },


                    // Blogentry details routes
                    {
                        view: config.viewIds.blogentries,
                        route: config.hashes.blogentries + '/:id',
                        title: 'Blogeintrag',
                        callback: vm.session.activate,
                        group: '.route-left'
                    },

                    // Invalid routes
                    {
                        view: '',
                        route: /.*/,
                        title: '',
                        callback: function() {
                            logger.error(config.toasts.invalidRoute);
                        }
                    }
                ];

                for (var i = 0; i < routeData.length; i++) {
                    router.register(routeData[i]);
                }

                // Crank up the router
                router.run();
            };
            

        return {
            register: register
        };
    });