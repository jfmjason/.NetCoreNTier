function ReleaseProcess() {
    self = this;

    self.init = function () {
        self.initButtons();
        self.initDateRange();

    }

    self.initDateRange = function () {
        $("#releasedaterange").daterangepicker({
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


    self.initButtons = function () {
        $("body").off("click");

        $("body").on("click", "#btnprocessreport", function () {
            var daterange = $("#releasedaterange").data('daterangepicker');
            var fromdate = moment(daterange.startDate).format("DD-MMM-YYYY");
            var todate = moment(daterange.endDate).format("DD-MMM-YYYY");
            var pdfsrc = base.ApplicationBasePath()+"/reports/ReleaseProcessToPDF?from=" + fromdate + "&to=" + todate;

            var iframe = window.frames['reportframe'];
            iframe.src = base.ApplicationBasePath() + base.ReportPreviewUri + encodeURIComponent(pdfsrc);
  
        });

    };



}