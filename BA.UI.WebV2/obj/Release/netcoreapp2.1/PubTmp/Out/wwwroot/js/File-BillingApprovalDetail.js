function BillingApprovalDetail() {
    self = this;

    self.init = function () {
        self.initButtons();
        self.GetApprovalRequestDetail();
    }
  
    self.SetUpTable = function (data) {

        $("#dtrequestitems").DataTable({
                    data: data,
                    destroy: true,
                    searching:false,
                    dom: 'bfrip',

                    lengthMenu: [15, 30, 50] ,
                    columns: [
                       
                      
                        { data: "itemName", title: "Item", width: "27%", searchable: true, orderable: true, class: "text-vertical-middle"},
                        { data: "unitName", title: "Unit", width: "8%", searchable: true, orderable: true, class: "text-vertical-middle" },
                        { data: "approvedQuantity", title: "Apr. Qty", width: "8%", searchable: true, orderable: true, class: "text-vertical-middle text-center" },
                        {
                            data: "approvedAmount", title: "Apr. Amt", width: "8%", searchable: true, orderable: true, class: "text-vertical-middle text-right td-decimal",
                            render: function (data) {
                                return parseInt(data.toFixed(2).split('.')[0]).toLocaleString('en') + "." + data.toFixed(2).split('.')[1];
                            }
                        },
                        { data: "requestedQuantity", title: "Req. Qty", width: "8", searchable: true, orderable: true, class: "text-vertical-middle text-center" },
                        {
                            data: "requestedAmount", title: "Req. Amt", width: "8%", searchable: true, orderable: true, class: "text-vertical-middle text-right td-decimal",
                            render: function (data) {

                                return parseInt(data.toFixed(2).split('.')[0]).toLocaleString('en') + "." + data.toFixed(2).split('.')[1];
                            }

                        },
                        {
                            data: "itemRequestStatus", title: "Status", width: "13%", searchable: true, orderable: true, class: "text-vertical-middle padding-4"
                            , render: function (nrow, display, data, tblsettings) {
                                var legendcss = "";
                                if (data.itemRequestStatusId == 1) {
                                    legendcss = "bg-yellow";
                                }
                                else if (data.itemRequestStatusId == 2) {
                                    legendcss = "bg-blue";
                                }
                                else if (data.itemRequestStatusId == 4) {
                                    legendcss = "bg-teal";
                                }

                                else if (data.itemRequestStatusId == 3  || data.itemRequestStatusId == 5) {
                                    legendcss = "bg-green";
                                }

                                else if (data.itemRequestStatusId == 6) {
                                    legendcss = "bg-red";
                                } else {
                                    legendcss = "bg-gray";
                                }

                                return "<span class='label " + legendcss + " ' style='padding:4px;'>" + data.itemRequestStatus + "</span>";
                            }

                        },
                        { data: "remarks", title: "Remarks", width: "20%", searchable: true, orderable: false, class: "text-vertical-middle" },
                        
                    
                    ]
                });

         //$("#data-items_filter label").append("<button id='btnClearFilter' class='btn btn-sm btn-default' style='margin-left:10px;'><i class='fa fa-eraser'/> Clear </button>");
         //$("#data-items_filter label").append("<button id='btnRefresh' class='btn btn-sm btn-primary' style='margin-left:10px;'><i class='fa fa-refresh '/> Refresh </button>");
    }

    self.initButtons = function () {
        $("body").off("click");
        $("body").on("click", "#btnprocessrequest", function () {
            $.ajax({
                url: "/file/approvalrequest/update/" + $("#requestid").html(),
                success: function (data) {
                    $("#renderbodycontent").html(data);
                }, error: function (data) {
                    $("#renderbodycontent").html("<h1> NOT FOUND</h1>");
                    $("#renderbodycontent").append(data);
                }
            });
       
        });

        $("body").on("click", "#backtolist", function () {
            loadViewAjax('/file/approvalrequest', 'Approval Request');
        });

    };

    self.GetApprovalRequestDetail = function () {
        $.ajax({
            url: base.ApplicationBasePath() +"/api/approvalrequest/" + $("#requestid").html(),
            type:"GET",
            success: function (data) {

                $("#patientname").html(data.patientName);
                $("#pin").html(data.pin);
                $("#category").html(data.categoryName);
                $("#company").html(data.companyName);
                $("#grade").html(data.gradeName);
                $("#createddate").html(moment(data.requestDate).format("DD-MMM-YYYY h:mm A"));
                $("#processby").html(data.processBy);
                $("#textclinicaldata").html(data.clincalData);
 
                if ((data.processById == 0 && data.requestStatusId != 3)  || (data.processById == $("#currentuserid").val() && data.requestStatusId == 2)) {
                    $("#btnprocessrequest").show();
                } else {
                    $("#btnprocessrequest").hide();
                }

                $("#requeststatus").html(data.requestStatus);
                $("#requeststatus").removeClass("label-warning");
                $("#requeststatus").removeClass("label-primary");
                $("#requeststatus").removeClass("label-success");

                if (data.requestStatusId == 1) {
                    $("#requeststatus").addClass("label-warning");
                  
                } else if (data.requestStatusId == 2) {
                    $("#requeststatus").addClass("label-primary");
                } else {
                    $("#requeststatus").addClass("label-success");
                }


                self.SetUpTable(data.requestItems);
            }, error: function (data) {
                console.log(data);
                $("#patientname").html("N/A");
                $("#pin").html("N/A");
                $("#category").html("N/A");
                $("#company").html("N/A");
                $("#grade").html("N/A");
                $("#createddate").html("N/A");
                $("#processby").html("N/A");
                $("#btnprocessrequest").hide();
                $("#requeststatus").html("");
                self.SetUpTable([]);
            }
        });
    }

}