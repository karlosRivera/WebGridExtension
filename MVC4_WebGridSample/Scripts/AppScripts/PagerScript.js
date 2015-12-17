function getParameterByName(url, name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(url);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function setArrowImages() {

    $('table th').each(function () {

        //get direction value
        var direction = getParameterByName($(this).find('a').attr('href'), 'sortdir');
        var header = $(this).find('a[href*="sortdir"]');
        header.html(header.html() + ' <i class="fa fa-sort pull-right" />');

        if (gridSort == getParameterByName($(this).find('a').attr('href'), 'sort')) {
            //alert(gridSort);

            switch (gridSort) {
                case 'ID': if (gridSortDir.toLowerCase() == "asc") { $(this).find('i').removeAttr('class').addClass('fa fa-sort-asc pull-right') } else { $(this).find('i').removeAttr('class').addClass('fa fa-sort-desc pull-right') }; break;
                case 'FirstName': if (gridSortDir.toLowerCase() == "asc") { $(this).find('i').removeAttr('class').addClass('fa fa-sort-asc pull-right') } else { $(this).find('i').removeAttr('class').addClass('fa fa-sort-desc pull-right') }; break;
                case 'LastName': if (gridSortDir.toLowerCase() == "asc") { $(this).find('i').removeAttr('class').addClass('fa fa-sort-asc pull-right') } else { $(this).find('i').removeAttr('class').addClass('fa fa-sort-desc pull-right') }; break;
                case 'IsActive': if (gridSortDir.toLowerCase() == "asc") { $(this).find('i').removeAttr('class').addClass('fa fa-sort-asc pull-right') } else { $(this).find('i').removeAttr('class').addClass('fa fa-sort-desc pull-right') }; break;
                default:
            }
        }

    });
};


$(function () {

    $('#gridPager ul').addClass('pagination');
    $('tfoot').hide();

    $('#PageSize').change(function () {

        $('#frmDetails').submit()
        return false;

    });

    $('#SearchText').change(function () {

        $('#frmDetails').submit()
        return false;

    });

    $('#gridPager a').click(function (e) {

        var form = $('#frmDetails');
        form.attr("action", this.href);
        $(this).attr("href", "javascript:");
        form.submit();

    });

    $('th a').click(function () {

        var form = $('#frmDetails');
        form.attr("action", this.href);
        $(this).attr("href", "javascript:");
        form.submit();

    });

    setArrowImages();

});