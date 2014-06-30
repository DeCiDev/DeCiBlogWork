define('model',
    [
        'model.blogentry',
        'model.category',
        'model.link'
    ],
    function (blogentry, category, link) {
        var
            model = {
                Blogentry: blogentry,
                Category: category,
                Link: link
            };

        model.setDataContext = function (dc) {
            // Model's that have navigation properties 
            // need a reference to the datacontext.
            model.Blogentry.datacontext(dc);
        };

        return model;
    });