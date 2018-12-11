function RptReleaseProcessList() {
    self = this;

    self.init = function () {
        self.initButtons();
        self.initDateRange();
        self.initSelect2();

        self.getReleases().then(function (data) {
            self.SetUpTable(data);
        });
    }

    self.initDateRange = function () {
        $("#releasedaterange").unbind().daterangepicker({
            startDate: moment(),
            endDate: moment(),
            dateLimit: { days: 60 },
            showDropdowns: true,
            showWeekNumbers: true,
            buttonClasses: ['btn btn-default'],
            applyClass: 'btn-small btn-primary',
            cancelClass: 'btn-small',

            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract('days', 1), moment().subtract('days', 1)],
                'Last 7 Days': [moment().subtract('days', 6), moment()],
                'Last 30 Days': [moment().subtract('days', 29), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
            },
            locale: {
                format: 'MMM DD, YYYY',
            }
        });
    }
    self.initSelect2 = function () {
        $("#releaseby").unbind().select2({
            placeholder: "Search Employee",
            minimumInputLength: -1,
            allowClear: true,
            ajax: {
                url: base.ApplicationBasePath() + "/api/employee/pagedsearch",
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
                            text: item.employeeNo + " - " + item.name
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
    }

    self.SetUpTable = function (data) {

        $("#data-releases").DataTable({
                    data: data,
                    destroy: true,
                    language: {
                        search: "Filter : ",
                        searchPlaceholder: "Type here..."
                    },
                    dom: 'bfrip',

                    lengthMenu: [15, 30, 50] ,
                    columns: [
                       
                        {
                            data: "referenceNo", title: "Ref.#", width: "5%", searchable: true, orderable: true, class:"text-vertical-middle padding-4 text-navy", render: function (data) {
                                return "<b>"+data +"</b>";
                            }
                           
                        },
                        { data: "pin", title: "PIN", width: "7%", searchable: true, orderable: true, class: "text-vertical-middle padding-4"},
                        { data: "releaseDate", title: "Release Date", searchable: true, orderable: true, class: "text-vertical-middle padding-4" },
                        { data: "processOwner", title: "Former Process Owner", searchable: true, orderable: true, class: "text-vertical-middle padding-4"},
                        { data: "transferTo", title: "Transferred To", searchable: true, orderable: true, class: "text-vertical-middle padding-4" },
                        { data: "releaseby", title: "Release By",  searchable: false, orderable: true, class: "text-vertical-middle padding-4" },
                        { data: "remarks", title: "Remarks", searchable: true, orderable: true, class:"padding-4 text-vertical-middle"}
                    ]
                });
    
    }

    self.initButtons = function () {
        $("body").off("click");

        $("body").on("click", "#btnfindrelease", function () {
            self.getReleases().then(function (data) {
                self.SetUpTable(data);
            });
           
        });
    };

    self.getReleases = function () {

        return new Promise(function (resolve) {
            var daterange = $("#releasedaterange").data('daterangepicker');
            var startdate = moment(daterange.startDate).format("DD-MMM-YYYY");
            var enddate = moment(daterange.endDate).format("DD-MMM-YYYY");
            var releaseby = $("#releaseby").select2('val');
            $.get(base.ApplicationBasePath() + "/api/releaseapproval/" + startdate + "/" + enddate + "/" + releaseby).done(function (data) {
                resolve(data);
            });
        });
    };

}