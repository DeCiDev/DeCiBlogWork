define('config',
    ['toastr', 'infuser', 'ko'],
    function (toastr, infuser, ko) {

        var
            // properties
            //-----------------
            
            currentUserId = 2, // Dennis Cisowski
            currentUser = ko.observable(),
            hashes = {
                blogentries: '#/blogentries',
                entriesByDate: '#/blogentries/date',
                categories: '#/categories',
                links: '#/links'
            },
            logger = toastr, // use toastr for the logger
            messages = {
                viewModelActivated: 'viewmodel-activation'
            },
            stateKeys = {
                lastView: 'state.active-hash'
            },
            storeExpirationMs = (1000 * 60 * 60 * 24), // 1 day
            //storeExpirationMs = (1000 * 5), // 5 seconds
            throttle = 400,
            title = 'DeCi Blog > ',
            toastrTimeout = 2000,

           
            viewIds = {
                blogentry: '#blogentry-view',
                blogentries: '#blogentries-view',
                category: '#category-view',
                categories: '#categories-view',
                link: '#link-view',
                links: '#links-view',
                shellLeft: '#shellLeft-view'
            },
            
            toasts = {
                changesPending: 'Bitte speichern oder verwerfen Sie die Eingabe, bevor Sie die Seite verlassen.',
                errorSavingData: 'Daten konnten nicht gespeichert werden. Bitte ggf. Protokolle prüfen.',
                errorGettingData: 'Daten konnten nicht geholt werden. Bitte ggf. Protokolle prüfen.',
                invalidRoute: 'Navigation nicht möglich, evtl falsche route',
                retreivedData: 'Daten erfolgreich geholt.',
                savedData: 'Daten erfolgreich gespeichert'
            },

            // methods
            //-----------------

            dataserviceInit = function () { },

            validationInit = function () {
                ko.validation.configure({
                    registerExtenders: true,    //default is true
                    messagesOnModified: true,   //default is true
                    insertMessages: true,       //default is true
                    parseInputAttributes: true, //default is false
                    writeInputAttributes: true, //default is false
                    messageTemplate: null,      //default is null
                    decorateElement: true       //default is false. Applies the .validationElement CSS class
                });
            },

            configureExternalTemplates = function () {
                infuser.defaults.templatePrefix = "_";
                infuser.defaults.templateSuffix = ".tmpl.html";
                infuser.defaults.templateUrl = "/Tmpl";
            },

            init = function () {
                dataserviceInit();

                toastr.options.timeOut = toastrTimeout;
                configureExternalTemplates();
                validationInit();
            };

        init();

        return {
            currentUserId: currentUserId,
            currentUser: currentUser,
            dataserviceInit: dataserviceInit,
            hashes: hashes,
            logger: logger,
            messages: messages,
            stateKeys: stateKeys,
            storeExpirationMs: storeExpirationMs,
            throttle: throttle,
            title: title,
            toasts: toasts,
            viewIds: viewIds,
            window: window
        };
    });

