
function AddDependentRow() {
    var tempIndex = 0;
    $("input[id*='dependents']").each(function (i, el) {
        if (tempIndex < i) {
            tempIndex = i;
        }
    });
    var template = $('#RowTemplate');
    var insertItem = template.clone(false);
    insertItem.find('input')
        .each(function () {
            this.id = this.id.replace('REPLACE_ID', tempIndex);
            this.name = this.name.replace('REPLACE_ID', tempIndex);
        });
    insertItem.show();
    $('#DependentsBlock').append(insertItem.contents());
}