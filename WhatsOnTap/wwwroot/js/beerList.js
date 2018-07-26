function initializeToolTipAndPopover() {
    $('[data-toggle="popover"]').popover()
    .popover({html:true})
    $('[data-toggle="tooltip"]').tooltip()
}

$(function () {
    initializeToolTipAndPopover();
})
