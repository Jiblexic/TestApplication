QUnit.extend(QUnit, {

    stringformat: function (str, col) {
        col = typeof col === 'object' ? col : Array.prototype.slice.call(arguments, 1);

        return str.replace(/\{\{|\}\}|\{(\w+)\}/g, function (m, n) {
            if (m == '{{') { return '{'; }
            if (m == '}}') { return '}'; }
            return col[n];
        });
    },

    okAsync: function (condition, action) {
        if (!condition) {
            start();
        }
        ok(condition, action);
    }
});