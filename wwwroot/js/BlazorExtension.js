var BlazorExtension = BlazorExtension || {};
BlazorExtension.getBoundingClientRect = function (element) {
    if (element !== undefined && element !== null)
        return element.getBoundingClientRect();

};
BlazorExtension.focusElement = (element) => {
    if (element) {
        element.focus();
    }
};
BlazorExtension.selectText = (element) => {
    if (element) {
        var barcode = element.value;
        element.setSelectionRange(0, barcode.length);
    }
};