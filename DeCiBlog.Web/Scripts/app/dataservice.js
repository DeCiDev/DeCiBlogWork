define('dataservice',
    [
        'dataservice.blogentry',
        'dataservice.lookup'
    ],
    function (blogentry, lookup) {
        return {
            blogentry: blogentry,
            lookup: lookup
        };
    });