function KnockoutSorter(sortOptions, records) {
    var self = this;

    self.Records = records;

    self.SortOptions = ko.observableArray(sortOptions);
    self.SortDirections = ko.observableArray([
        {
            Name: "Asc",
            Value: "Asc",
            Sort: false
        },
        {
            Name: "Desc",
            Value: "Desc",
            Sort: true
        }
    ]);

    self.CurrentSortOption = ko.observable(GetSortValueFromCookie(self.SortOptions(), "SortOption"));
    self.CurrentSortDirection = ko.observable(GetSortValueFromCookie(self.SortDirections(), "SortDirection"));

    self.CurrentSortOption.subscribe(function (val) {
        $.cookie("SortOption", val.Value, { expires: 10 });
    }, self);

    self.CurrentSortDirection.subscribe(function (val) {
        $.cookie("SortDirection", val.Value, { expires: 10 });
    }, self);

    self.OrderedRecords = ko.computed(function () {
        var recordsValues = self.Records();
        var sortOption = self.CurrentSortOption();
        var sortDirection = self.CurrentSortDirection();

        if (sortOption == null || sortDirection == null) {
            return recordsValues;
        }

        var sortedRecords = recordsValues.slice(0, recordsValues.length);
        SortArray(sortedRecords, sortDirection.Sort, sortOption.Sort);

        return sortedRecords;
    }).extend({ throttle: 5 });

    function SortArray(array, direction, comparison) {
        if (array == null) {
            return [];
        }

        for (var oIndex = 0; oIndex < array.length; oIndex++) {
            var oItem = array[oIndex];
            for (var iIndex = oIndex + 1; iIndex < array.length; iIndex++) {
                var iItem = array[iIndex];
                var isOrdered = comparison(oItem, iItem);
                if (isOrdered === direction) {
                    array[iIndex] = oItem;
                    array[oIndex] = iItem;
                    oItem = iItem;
                }
            }
        }

        return array;
    }

    function GetSortValueFromCookie(options, cookieName) {
        var result;
        var cookieValue = $.cookie(cookieName);
        if (cookieValue) {
            options.forEach(function (e) {
                if (e.Value === cookieValue) {
                    result = e;
                }
            });
        }

        return result || options[0];
    }
};