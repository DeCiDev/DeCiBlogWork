define('vm',
[
        'vm.blogentry',
        'vm.blogentries',
        'vm.categories',
        'vm.shell',
        'vm.links'
],
    function (blogentry, blogentries, categories, shell, links) {
        return {
            blogentry: blogentry,
            blogentries: blogentries,
            categories: categories,
            shell: shell,
            links: links
        };
    });