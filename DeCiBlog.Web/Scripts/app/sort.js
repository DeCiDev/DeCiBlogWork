define('sort', [], function () {

    var
        blogentriesSort = function(entryA, entryB) {
            if (entryA.creationdate() === entryB.creationdate()) {
                return entryA.title() > entryA.title() ? 1 : -1;
            } else {
                return entryA.creationdate() > entryB.creationdate() ? 1 : -1;
            }
        },

        categoriesSort = function(categoryA, categoryB) {
            return categoryA.name() > categoryB.name() ? 1 : -1;
        },

        linksSort = function(linkA, linkB) {
            return linkA.name() > linkB.name() ? 1 : -1;
        };


    return {
        blogentriesSort: blogentriesSort,
        categoriesSort: categoriesSort,
        linksSort: linksSort
    };
});