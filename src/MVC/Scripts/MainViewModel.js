var MainViewModel = function () {
    var self = this;

    self.books = ko.observableArray([]);

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

    self.sorter = new KnockoutSorter(sortOptions, self.books);

    self.selectedBook = ko.observable();

    self.AddBook = function () {
        var book = new BookViewModel();
        self.books.push(book);
        self.selectedBook(book);
    };

    self.EditForm = function (book) { self.selectedBook(book); };

    self.RemoveBook = function (book) {
        var header = book.Header();
        if (confirm("Are you sure you want to remove book: " + header + "?")) {
            $.ajax({
                url: "api/Book/Remove?Id=" + book.Id(),
                type: "DELETE",
                success: function () {
                    alert("Book: " + header + " has been removed.");
                    self.books.remove(book);
                    self.selectedBook(null);
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
                self.books(mappedBooks);
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