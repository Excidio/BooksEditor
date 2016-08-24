var MainViewModel = function () {
    var self = this;

    self.Books = ko.observableArray([]);

    var sortOptions = [
        {
            Name: "Header",
            Value: "Header",
            Sort: function (left, right) { return CompareCaseInsensitive(left.Header(), right.Header()); }
        },
        {
            Name: "Publishing year",
            Value: "PublishingYear",
            Sort: function (left, right) { return left.PublishingYear() < right.PublishingYear(); }
        }
    ];

    self.Sorter = new KnockoutSorter(sortOptions, self.Books);

    self.SelectedBook = ko.observable();

    self.AddBook = function () {
        var book = new BookViewModel();
        self.Books.push(book);
        self.SelectedBook(book);
    };

    self.EditForm = function (book) { self.SelectedBook(book); };

    self.SaveBook = function () {
        var book = self.SelectedBook();
        if (book.Errors().length === 0) {
            book.GeneralErrors.removeAll();
            $.ajax({
                url: "api/Book/Post",
                type: "POST",
                data: ko.toJSON(book),
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    book.Id = result.Id;
                    alert("Book: " + book.Header() + " has been saved.");
                },
                statusCode: {
                    400: function (result) {
                        book.SetErrors(result);
                    },
                    500: function (result) {
                        book.GeneralErrors.push(result.statusText + ". Please contact with developers.");
                    }
                }
            });
        } else {
            book.Errors.showAllMessages();
        }
    };

    self.RemoveBook = function (book) {
        var header = book.Header();
        if (confirm("Are you sure you want to remove book: " + header + "?")) {
            $.ajax({
                url: "api/Book/Remove?Id=" + book.Id(),
                type: "DELETE",
                success: function () {
                    alert("Book: " + header + " has been removed.");
                    self.Books.remove(book);
                    self.SelectedBook(null);
                }
            });
        }
    };

    self.imageUpload = function (data, e) {
        var file = e.target.files[0];
        var reader = new FileReader();

        reader.onloadend = function () {
            data.Image(reader.result);
        };

        if (file) {
            reader.readAsDataURL(file);
        }
    };

    self.loadBooks = function () {
        $.ajax({
            url: "api/Book/GetAll",
            type: "GET"
        })
            .done(function (data) {
                var mappedBooks = $.map(data, function (item) { return new BookViewModel(item); });
                self.Books(mappedBooks);
            })
            .error(function () {
                alert("An error occurred when tried to load a books. Please contact with developers.");
            });
    };

    //$.getJSON("/tasks", function (allData) {
    //    var mappedTasks = $.map(allData, function (item) { return new Task(item) });
    //    self.tasks(mappedTasks);
    //});

    self.loadBooks();
};