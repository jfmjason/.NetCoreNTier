var base = this;

const toast = swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000
});

var spinOpts = {
    lines: 13, // The number of lines to draw
    length: 10, // The length of each line
    width: 10, // The line thickness
    radius: 20, // The radius of the inner circle
    scale: 1, // Scales overall size of the spinner
    corners: 1, // Corner roundness (0..1)
    color: '#3c8dbc', // CSS color or array of colors
    fadeColor: 'transparent', // CSS color or array of colors
    speed: 1, // Rounds per second
    rotate: 0, // The rotation offset
    animation: 'spinner-line-fade-quick', // The CSS animation name for the lines
    direction: 1, // 1: clockwise, -1: counterclockwise
    zIndex: 2e9, // The z-index (defaults to 2000000000)
    className: 'spinner', // The CSS class to assign to the spinner
    top: '50%', // Top position relative to parent
    left: '50%', // Left position relative to parent
    shadow: '0 0 1px transparent', // Box-shadow for the lines
    position: 'absolute' // Element positioning
};

var _spinner;


base.GetStation = function () {

    if (localStorage["Station"] != undefined) {

        return JSON.parse(localStorage["Station"]);
    }
    return null;
}

base.SetStation = function () {

    swal({
        title: "SET LOCATION",
        html: "<div class ='form-group'>"
            + "<div class ='col-md-12' >"
            + "<label class='pull-left text-gray-darker' style='font-size:14px;'>Station <i class='fa fa-map-marker text-red text-bold' style='font-size:15px;'></i></label>"
            + "<select id='selsetstation' class='input input-sm form-control'> </select> "
            + "</div> "
            + "</div> ",
        allowOutsideClick: false,
        onOpen: function(){
            var station = base.GetStation();

            $('#selsetstation').select2({
                placeholder: "Search Station",
                placeholder: "Search Station",
                minimumInputLength: -1,
                dropdownCssClass: "swalsel2",
                allowClear: true,
                ajax: {
                    url: base.ApplicationBasePath()+"/api/station/pagedsearch",
                    dataType: 'json',
                    quietMillis: 250,
                    data: function (params) {
                        return {
                            pagesize: 30,
                            page: params.page || 1,
                            term: params.term
                        };
                    },
                    processResults: function (result, params) {

                        params.page = params.page || 1;

                        var mapped = $.map(result.data, function (item) {
                            return {
                                id: item.id,
                                text: item.name
                            };

                        });
                        return {
                            results: mapped,
                            pagination: {
                                more: (params.page * 30) < result.recordcount
                            }
                        };
                    },
                    cache: true
                },
            });

            if (station != null) {
                $('#selsetstation').append('<option value="' + station.Id + '" selected="selected">' + station.Name +'</option> ');
            }

        },
        allowOutsideClick: false

    }).then(function (result) {
        
    if (result.value) {
        
        var station = $('#selsetstation').select2('data')[0];

        if (station !== undefined) {
            localStorage.setItem("Station", JSON.stringify({ Id: station.id, Name: station.text }));

            $("#stationfooter").html(station.text);
        } else {

            localStorage.removeItem("Station");
            $("#stationfooter").html("Not set");
        }
    }
});
}

base.ApplicationBasePath = function() {
    return $("#baseinput").data("apprelativepath");
}

base.ReportPreviewUri =  "/reports/printpreview?uri=";

function loadViewAjax(uri, pagetitle) {
    $.ajax({
        url: base.ApplicationBasePath() +uri,
        beforeSend: function () {
            _spinner.spin($("#renderbodycontent")[0]);
        },
        success: function (response) {
            $("#renderbodycontent").html(response);
            $("#renderbodycontent").scrollTop();

            window.history.pushState({ "html": response, "pageTitle": pagetitle }, "", base.ApplicationBasePath() +uri);

        },
        error: function (xhr, status, error) {

            window.history.pushState({ "html": xhr.responseText, "pageTitle": pagetitle }, "", base.ApplicationBasePath() +uri);
            var htmltext = "";

            console.log(xhr.getAllResponseHeaders());
            console.log({ xhr: xhr, status: status, error: error });

            var header = ' <section class="content-header bg-white">'
                + '    <h1 class="text-maroon">'
                + xhr.statusText.toUpperCase() + ' ' + xhr.status
                + '    </h1>'
                + ' </section>';

            htmltext = xhr.responseText;
            if ($.trim(xhr.responseText) == "" && xhr.status == 404) {
                htmltext = "No webpage was found for the web address : <span class='text-blue'>" + window.location.href + "</span>";
            }


            var body = ' <section class="content-body bg-white">'
                + '<div class="row" style="min-height:700px; font-size:14px;">'
                + '<div class="col-md-12">'
                + '<div class="col-md-12">'
                + '<hr/>'
                + '<header class="text-gray-darker text-bold" style="font-size:20px;">Details</header>'
                + '<p  class="text-gray-darker top-20">' + htmltext + '</p>'
                + '</div>'
                + '</div>'
                + '</div>'
                + ' </section>';

            $("#renderbodycontent").html('');
            $("#renderbodycontent").append(header);
            $("#renderbodycontent").append(body);


        },
        complete: function () {
            _spinner.stop();
        }
    });

}

window.onpopstate = function (e) {
    if (e.state) {
        document.getElementById("renderbodycontent").innerHTML = e.state.html;
        document.title = e.state.pageTitle;
    }
};

$(document).ready(function () {
    $("li.treeview").click(function () {
        if ($(this).hasClass("staticmenu")) {
            loadViewAjax($(this).find("a").data('url'), "Home");
        }

        $(".treeview").removeClass("active");
        $(this).addClass("active");
    })

    $("ul.treeview-menu li a").click(function () {
        $("ul.treeview-menu li a").removeClass("text-aqua");
        $(this).addClass("text-aqua");
        
        loadViewAjax($(this).data('url'), $(this).data("pagename"));
    })

    $("#sidebar-search").keyup(function () {
    
        if ($(this).val().trim().length > 0) {
            var searchterm = $(this).val();

            var searchedElem = $('.treeview-menu li').filter(function () {
                return $(this).text().toLowerCase().indexOf(searchterm.toLowerCase()) > -1;
            })

            var excludedElem = $('.treeview-menu li').filter(function () {
                return $(this).text().toLowerCase().indexOf(searchterm.toLowerCase()) == -1;
            })
            debugger
            $(excludedElem).closest("li.treeview")
                .removeClass("active")
                .removeClass("menu-open");
            $(excludedElem).closest("ul.treeview-menu")
                .hide();
            $(excludedElem).hide();

            
            $(searchedElem).closest("li.treeview")
                .addClass("active")
                .addClass("menu-open");
            $(excludedElem).closest("ul.treeview-menu")
                .show();

            $(searchedElem).show();

            //}
        } else {
            $("li.treeview.menu-open li").show();
            $("li.treeview.menu-open ul.treeview-menu").hide();
            $("li.treeview")
                .removeClass("active")
                .removeClass("menu-open");
        }
    })

})

$(window).on("load", function () {

    _spinner = new Spinner(spinOpts);

    if (base.GetStation() == null) {
        base.SetStation();
    } else {
        $("#stationfooter").html(base.GetStation().Name);
    }

});

