function BillingApprovalList() {
    self = this;

    self.init = function () {
        self.initButtons();
        self.initDateRange();
        self.initSel2Category();
        self.setPatientSelect2();
        self.SetUpTable();
        self.setRowClickEvent(self);
    }

    self.initDateRange = function () {
        $("#requestdaterange").unbind().daterangepicker({
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
        var registrationno = $("#registrationno").select2('val');

        $.ajax({
            url: base.ApplicationBasePath() + "/api/approvalrequest/" + startdate + "/" + enddate + "/" + categoryid + "/" + registrationno,
            success: function (data) {
                console.log(data);
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
                            data: null, title: "", width: "1%", searchable: false, orderable: true, class: "text-vertical-middle padding-4 text-center details-control", render: function (data) {
                                return "<a class='fa fa-minus-circle text-success' style='cursor:pointer; font-size:17px;display:none;'/>" + "<a class='fa fa-plus-circle' style='cursor:pointer; font-size:17px;'/>" ;
                            }

                        },
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
                            data: "id", title: "Action", width: "6%", searchable: false, orderable: false, class: "padding-4"
                            , render: function (nrow, display, data, tblsettings) {

                                if (data.requestStatusId == 1) {
                                    return '<button title="DELETE" class="btndeleterequest btn btn-default fa fa-trash text-maroon" data-requestid ="' + data.id + '"></button>';
                                    //'<button title="EDIT" class="viewrequest btn btn-default fa fa-pencil text-navy" style="margin-right:3px;"data-requestid ="' + data.id + '"></button>' +
                                        
                                } else {
                                    return "";
                                }

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

        $("body").on("click", "#gocreatenew", function () {
            loadViewAjax("/file/approvalrequest/create", 'Create Approval Request');
        });


        $("body").on("click", "#btnfindrequest", function () {
            self.SetUpTable();
        });

        $("body").on("click", ".btndeleterequest", function () {
            var table = $('#data-items').DataTable();
            var row = $(this).closest('tr');
            var data = table.row(row).data();

            swal({
                title: 'Confirmation',
                html: 'Are you sure you want to delete this request',
                showCancelButton: true,
                cancelButtonText: 'No',
                confirmButtonText: 'Yes',
                showLoaderOnConfirm: true,
                preConfirm: function () {
                    return new Promise(function (resolve, reject) {
                        self.DeleteRequest(data.id, reject).then(function (data) {
                            resolve();
                            table.row(row).remove().draw();
                        });
                    })
                },
            }).then((result) => {
                if (result.value) {
                    swal('Notification', 'Successfully deleted request', 'success', 3000);
                } else {
                 
                    return;
                }
            });
        });


    };

    self.setPatientSelect2 = function () {
        $("#registrationno").unbind().select2({
            placeholder: "Search Patient",
            minimumInputLength: -1,
            allowClear: true,
            ajax: {
                url: base.ApplicationBasePath() + "/api/patient/pagedsearch/",
                dataType: 'json',
                data: function (params) {
                    return {
                        pagesize: 10,
                        page: params.page || 1,
                        term: params.term
                    };
                },
                quietMillis: 250,
                processResults: function (result, params) {

                    params.page = params.page || 1;

                    var mapped = $.map(result.data, function (item) {
                        return {
                            id: item.registrationNo,
                            text: item.pin + " - " + item.name,
                            doctorid: item.doctorId,
                            contactno: item.contactNo,
                            insurancecardno: item.insuranceCardNo,
                            companyid: item.companyId,
                            gradeid: item.gradeId,
                            categoryid: item.categoryId
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
            }
        });

    }

    self.setRowClickEvent = function (_self) {
        $('#data-items tbody').unbind().on('click', 'td.details-control', function () {
            var table = $('#data-items').DataTable();
            var tr = $(this).closest('tr');
            var row = table.row(tr);
            var rowdata = row.data();

            if (row.child.isShown()) {
                // This row is already open - close it
                row.child.hide();
                tr.removeClass('shown');
                $(this).find("a.fa-minus-circle").hide();
                $(this).find("a.fa-plus-circle").show();
            }
            else {
                // Open this row
                $(this).find("a.fa-minus-circle").show();
                $(this).find("a.fa-plus-circle").hide();
                row.child(_self.FormatRequestItems(rowdata.items)).show();
                tr.addClass('shown');
            }
        });

    };

    self.FormatRequestItems = function (items) {
        var requestitems = "<header style='margin-left:5%; margin-top:10px;color: black;font-weight: 500;font-size: 12px;'> REQUESTED ITEM(S) </header>";
        requestitems += "<table class='table orderdetails table-bordered' style='width:90%;margin-left:5%; margin-top:5px;'>"
            + "<thead>"
            + "<tr>"
            + "<th>Item Name</th>"
            + "<th>Price</th>"
            + "<th>Quantity</th>"
            + "<th>Amount</th>"
            + "<th>Approved Qty</th>"
            + "<th>Approved Amt</th>"
            + "<th>Status</th>"
            + "</tr>"
            + "</thead>"
            + "<tbody>"

        $.each(items, function (i, item) {
            requestitems += "<tr>";
            requestitems += "<td>" + item.itemName + "</td>"
                + "<td class='text-right'>" + parseFloat(item.price).toFixed(2)  + "</td>"
                + "<td>" + item.requestedQuantity + "</td>"
                + "<td class='text-right'>" + parseFloat(item.requestedAmount).toFixed(2) + "</td>"
                + "<td >" + item.approvedQuantity + "</td>"
                + "<td class='text-right'>" + parseFloat(item.approvedAmount).toFixed(2) + "</td>"
                + "<td>" + item.itemRequestStatus + "</td>"
            requestitems += "</tr>";
        });

        requestitems += "</tr></tbody></table>";

        return requestitems;
    }

    self.DeleteRequest = function (id, reject) {

        return new Promise(function (resolve) {

            $.ajax({
                url: base.ApplicationBasePath() + "/api/approvalrequest/delete/" + id,
                type: "PUT",
                contentType: "application/json",
                dataType: "json",
                data: base.GetStation().Id,
                success: function (response) {
                    resolve(response);
                }, error: function (e) {
                    reject("Request submission failed");
                }
            })
        });
    }
  
}