define('model.mapper',
['model'],
    function (model) {
        var
            blogentry = {
                getDtoId: function (dto) { return dto.id; },
                fromDto: function(dto, item) {
                    item = item || new model.Blogentry().id(dto.id);
                    item.title(dto.title)
                        .text(dto.text)
                        .categories(dto.categories)
                        .comments(dto.comments)
                        .links(dto.links)
                        .creationdate(moment(dto.creationdate).toDate())
                        .creatorid(dto.creatorid)
                        .creator(dto.creator)
                        .tags(dto.tags);
                    item.dirtyFlag().reset();
                    return item;
                }
            },

            category = {
                getDtoId: function(dto) { return dto.id; },
                fromDto: function(dto, item) {
                    item = item || new model.Category().id(dto.id);
                    item.name(dto.name)
                        .description(dto.description)
                        .blogentries(dto.blogentries)
                        .parent(dto.parent)
                        .children(dto.children);
                    item.dirtyFlag().reset();
                    return item;
                }
            },

            comment = {
                getDtoId: function(dto) { return dto.id; },
                fromDto: function(dto, item) {
                    item = item || new model.Comment().id(dto.id);
                    item.text(dto.text)
                        .created(moment(dto.created).toDate())
                        .userid(dto.userid)
                        .user(dto.user)
                        .blogentryid(dto.blogentryid)
                        .blogentry(dto.blogentry);
                    item.dirtyFlag().reset();
                    return item;
                }
            },

            link = {
                getDtoId: function(dto) { return dto.id; },
                fromDto: function(dto, item) {
                    item = item || new model.Link().id(dto.id);
                    item.name(dto.name)
                        .description(dto.description)
                        .url(dto.url)
                        .blogentries(dto.blogentries);
                    item.dirtyFlag().reset();
                    return item;
                }
            };

        return {
            blogentry: blogentry,
            category: category,
            comment: comment,
            link: link
        };
    });