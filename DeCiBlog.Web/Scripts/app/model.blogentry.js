define('model.blogentry',
    ['ko', 'config'],
    function (ko, config) {
    	var Blogentry = function () {
    		var self = this;
    		self.id = ko.observable();
    		self.title = ko.observable().extend({ required: true });
    		self.text = ko.observable().extend({ required: true });
    		self.categories = ko.observable();
    		self.comments = ko.observable();
    		self.links = ko.observable();
    		self.creationdate = ko.observable();
    		self.creatorid = ko.observable();
    		self.creator = ko.observable();
    		self.tags = ko.observable();

    		self.entrieHash = ko.computed(function () {
    			return config.hashes.blogentries + '/' + self.id();
    		});

    		self.tagsFormatted = ko.computed({
    			read: function () {
    				var text = self.tags();
    				return text ? text.replace(/\|/g, ', ') : text;
    			},

    			write: function (value) {
    				self.tags(value.replace(/\, /g, '|'));
    			}
    		}),

    		self.dirtyFlag = new ko.DirtyFlag([
                self.title,
                self.text,
				self.categories,
				self.comments,
				self.links,
                self.creationdate,
                self.creatorid,
                self.creator,
                self.tags]);
    		return self;
    	};

    	Blogentry.Nullo = new Blogentry()
            .id(0)
            .title('kein Blogeintrag')
            .text('')
            .categories([])
            .comments([])
            .links([])
            .creationdate(new Date(1900, 1, 1, 1, 0, 0, 0))
            .creatorid(0)
            .creator('{}')
            .tags('');

        Blogentry.Nullo.isNullo = true;
        Blogentry.Nullo.dirtyFlag().reset();

    	var _dc = null;
    	// Static member, no access to instances of Blogentry
    	Blogentry.datacontext = function (dc) {
    		if (dc) { _dc = dc; }
    		return _dc;
    	};


    	return Blogentry;
    });