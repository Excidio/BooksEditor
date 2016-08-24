ko.observable.fn.appendError = function (error) {
    var thisError = this.error();
    if (thisError) {
        this.setError(thisError + ". " + error);
    } else {
        this.setError(error);
    };
};

function CompareCaseInsensitive(left, right) {
    if (left == null) {
        return right == null;
    } else if (right == null) {
        return false;
    }

    return left.toUpperCase() <= right.toUpperCase();
}