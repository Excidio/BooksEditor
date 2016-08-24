var AuthorViewModel = function(data) {
    var self = this;

    self.Id = ko.observable(data && data.Id);
    self.FirstName = ko.observable(data && data.FirstName).extend({ required: true, maxLength: 20 });
    self.LastName = ko.observable(data && data.LastName).extend({ /*required: true, maxLength: 20*/ });

    self.Errors = ko.validation.group(self);

    return self;
}