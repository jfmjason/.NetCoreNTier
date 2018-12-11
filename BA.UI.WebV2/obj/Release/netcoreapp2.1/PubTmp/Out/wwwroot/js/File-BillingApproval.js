function BillingApproval() {
    self = this;

    self.init = function () {
        self.initButtons();
        self.initDateRange();
        self.initSel2Category();
        self.SetUpTable();
    }

    self.initDateRange = function () {
        $("#requestdaterange").daterangepicker({
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

    self.initSel2Category = function () {
        $("#sel2category").unbind().select2({
            minimumInputLength: -1,
            placeholder: "Search category ...",
            allowClear:true,
            ajax: {
                url: function (query) {
                    return base.ApplicationBasePath() +"/api/category/search/" + query.term + "/" + 20;
                },
                contentType: "application/json",
                dataType: 'json',
                type: "GET",
                quietMillis: 50,
                processResults: function (data) {
                    console.log(data);
                    return {
                        results: $.map(data, function (item) {
                            return {
                                text: item.name,
                                id: item.id
                            }
                        })
                    };
                }
            }
        });



    }

    self.SetUpTable = function () {

        var daterange = $("#requestdaterange").data('daterangepicker');
        var startdate = moment(daterange.startDate).format("DD-MMM-YYYY");
        var enddate = moment(daterange.endDate).format("DD-MMM-YYYY");
        var categoryid = $("#sel2category").select2('val');

        $.ajax({
            url: base.ApplicationBasePath() +"/api/approvalrequest/" + startdate + "/" + enddate + "/" + categoryid ,
            success: function (data) {
                $("#data-items").DataTable({
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
                            data: "id", title: "Ref.#", width: "5%", searchable: true, orderable: true, class:"text-vertical-middle padding-4 text-navy", render: function (data) {
                                return "<b>"+data +"</b>";
                            }
                           
                        },
                        { data: "pin", title: "PIN", width: "7%", searchable: true, orderable: true, class: "text-vertical-middle padding-4"},
                        { data: "insuranceCardNo", title: "Med. Id Number", width: "8%", searchable: true, orderable: true, class: "text-vertical-middle padding-4" },
                        {
                            data: "requestDate", title: "Date", width: "9%", searchable: true, orderable: true, class: "text-vertical-middle padding-4",
                            render: function (nrow, display, data, tblsettings) {
                                return moment(data).format("DD-MMM-YYYY hh:mm A");
                        }},
                        { data: "doctorCode", title: "Doctor", width: "5%", searchable: true, orderable: true, class: "text-vertical-middle padding-4"},
                        {
                            data: "categoryName", title: "Category", width: "4%", searchable: true, orderable: true, class: "text-vertical-middle padding-4", render: function (data) {
                               
                                return '<span  class="text-ellipsis" style= "width:80px;">' + data+ '</span>';
                                
                            }
                        },
                        {
                            data: "requeststatusId", title: "Status", width: "5%", searchable: false, orderable: true, class: "text-vertical-middle padding-4"
                            , render: function (nrow, display, data, tblsettings) {
                                if (data.requestStatusId == 1) {
                                    return '<span class="label label-warning padding-top-5 padding-bottom-5" >' + data.requestStatus + '</span>';
                                } else if (data.requestStatusId == 2) {
                                    return '<span class="label label-primary  padding-top-5 padding-bottom-5" >' + data.requestStatus + '</span>';
                                } else {
                                    return '<span class="label label-success  padding-top-5 padding-bottom-5" >' + data.requestStatus + '</span>';
                                }
                            }
                        },
                        {
                            data: "processBy", title: "Process Owner", width: "18%", searchable: true, orderable: true, class:"padding-4 text-vertical-middle"
                            , render: function (nrow, display, data, tblsettings) {

                               var htmlnode = "";
                                
                                if (data.processBy != null) { 
                                    htmlnode += '<span class="text-ellipsis" style= "width:200px;padding-top:5px;"><i class="fa fa-lock text-gray"></i> ' + data.processBy + '</span > ';
                                }   
                                if (data.requestStatusId != 3) {
                                    htmlnode += '<button class="pull-right processrequest btn btn-default btn-sm text-navy" data-requestid ="' + data.id + '"><i class="fa fa-check-square-o" ></i> Process</button>'
                                }
                                return htmlnode;
                            }
                        },
                        {
                            data: "id", title: "Action", width: "6%", searchable: false, orderable: false, class: "padding-4"
                            , render: function (nrow, display, data, tblsettings) {

                                return '<button class="viewrequest btn btn-default fa fa-search-plus text-navy" style="margin-right:3px;"data-requestid ="' + data.id + '"></button>'
                                    + '<button class="viewrequestwindow btn btn-default fa fa-clone text-maroon" data-requestid ="' + data.id + '"></button>';

                            }
                        }
                    ]
                });

                $("#data-items_filter label").append("<button id='btnClearFilter' class='btn btn-sm btn-default' style='margin-left:10px;'><i class='fa fa-eraser'/> Clear </button>");
                $("#data-items_filter label").append("<button id='btnRefresh' class='btn btn-sm btn-primary' style='margin-left:10px;'><i class='fa fa-refresh '/> Refresh </button>");

            }
        });
    }

    self.initButtons = function () {
        $("body").off("click");

        $("body").on("click", "#btnClearFilter", function () {
            $("#data-items_filter input").val('').trigger("keyup");
       
        });

        $("body").on("click", "#btnRefresh", function () {
            self.SetUpTable();
        });


        $("body").on("click", ".processrequest", function () {
             loadViewAjax("/file/approvalrequest/update/" + $(this).data("requestid"), 'Update Request');
        });

        $("body").on("click", ".viewrequest", function () {
            loadViewAjax("/file/approvalrequest/" + $(this).data("requestid"), 'Request Detail');
        });

        $("body").on("click", ".viewrequestwindow", function () {
            var url = base.ApplicationBasePath()+"/file/approvalrequest/"+$(this).data("requestid");

            window.open(url, '_blank'); 
        });

        $("body").on("click", "#btnfindrequest", function () {
            self.SetUpTable();
        });
    };


  
}