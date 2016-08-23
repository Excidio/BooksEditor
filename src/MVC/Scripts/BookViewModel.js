﻿var BookViewModel = function (data) {
    var GetAuthors = function () {

        var mappedBooks;
        if (data) {
            mappedBooks = $.map(data.Authors, function (item) { return new AuthorViewModel(item); });
        }

        return ko.observableArray(mappedBooks || []);
    }

    var self = this;
    self.Id = ko.observable(data && data.Id);
    self.Header = ko.observable(data && data.Header).extend({ required: true, maxLength: 30 });
    self.NumberOfPages = ko.observable(data && data.NumberOfPages).extend({ required: true, min: 0, max: 10000 });
    self.PublishingHouse = ko.observable(data && data.PublishingHouse).extend({ maxLength: 30 });
    self.PublishingYear = ko.observable(data && data.PublishingYear).extend({ required: true, min: 0 });
    self.ISBN = ko.observable(data && data.ISBN).extend({ required: true });
    self.Image = ko.observable(data && data.Image);

    self.Authors = GetAuthors().extend({ minLength: 1 }),
        self.addAuthor = function () {
            self.Authors.push(new AuthorViewModel());
        }

    self.removeAuthor = function (author) {
        self.Authors.remove(author);
    },
        self.saveBook = function () {
            if (self.errors().length === 0) {
                self.generalErrors.removeAll();
                $.ajax({
                    url: "api/Book/Post",
                    type: "POST",
                    data: ko.toJSON(self),
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        self.Id = result.Id;
                    },
                    statusCode: {
                        400: function (result) {
                            if (typeof result.responseJSON.ModelState !== "undefined") {
                                $.each(result.responseJSON.ModelState,
                                    function (key, errors) {
                                        $.each(errors,
                                            function (index, error) {
                                                switch (key) {
                                                    case "model.Header":
                                                        self.Header.appendError(error);
                                                        break;
                                                    case "model.NumberOfPages":
                                                        self.NumberOfPages.appendError(error);
                                                        break;
                                                    case "model.PublishingHouse":
                                                        self.PublishingHouse.appendError(error);
                                                        break;
                                                    case "model.PublishingYear":
                                                        self.PublishingYear.appendError(error);
                                                        break;
                                                    case "model.ISBN":
                                                        self.ISBN.appendError(error);
                                                        break;
                                                        //case "model.Author":
                                                        //    self.ISBN.appendError(error);
                                                        //    break;
                                                    default:
                                                        self.generalErrors.push(error);
                                                        break;
                                                };
                                            });
                                    });
                            } else {
                                self.generalErrors.push(result.responseJSON.Message);
                            };
                        },
                        500: function (result) {
                            self.generalErrors.push(result.statusText + '. Please contact with developers.');
                        }
                    }
                });
            } else {
                self.errors.showAllMessages();
            }
        };

    self.errors = ko.validation.group(self, { deep: true, live: true });
    self.generalErrors = ko.observableArray([]);

    return self;
}