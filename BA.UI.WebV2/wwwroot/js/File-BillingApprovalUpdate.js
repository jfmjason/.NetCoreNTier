function BillingApprovalUpdate() {
    self = this;
    self.TargetRow = null;

    self.init = function () {
        self.initButtons(self);
        self.GetApprovalRequestDetail();
        self.initItemRequestStatus();
    }
  
    self.SetUpTable = function (data) {

        $("#dtrequestitems").DataTable({
                    data: data,
                    destroy: true,
                    searching:false,
                    dom: 'bfrip',

                    lengthMenu: [15, 30, 50] ,
                    columns: [
                       
                        {
                            data: null, title: "#", searchable: true, orderable: true, class: "text-vertical-middle padding-4 text-center text-navy padding-4"
                            , render: function (nrow, display, data, tblsettings) {
                                return "<b>" + (parseInt(tblsettings.row) + 1) +"</b>";
                            }

                        },
                        { data: "itemName", title: "Item", width: "32%", searchable: true, orderable: true, class: "text-vertical-middle padding-4"},
                        { data: "unitName", title: "Unit", width: "8%", searchable: true, orderable: true, class: "text-vertical-middle padding-4" },
                        { data: "approvedQuantity", title: "Apr. Qty", width: "8%", searchable: true, orderable: true, class: "text-vertical-middle text-center padding-4" },
                        {
                            data: "approvedAmount", title: "Apr. Amt", width: "8%", searchable: true, orderable: true, class: "text-vertical-middle text-right td-decimal padding-4",
                            render: function (data) {
                                return parseFloat(data).toFixed(2);
                            }
                        },
                        { data: "requestedQuantity", title: "Req. Qty", width: "8", searchable: true, orderable: true, class: "text-vertical-middle text-center padding-4" },
                        {
                            data: "requestedAmount", title: "Req. Amt", width: "8%", searchable: true, orderable: true, class: "text-vertical-middle text-right td-decimal padding-4",
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
                        {
                            data: null, title: "Action", width: "10%", searchable: true, orderable: false, class: "text-vertical-middle padding-4 text-center",
                            render: function (data) {

                                return '<a class="btn btn-sm btn-default editpopup" > <i class="fa fa-edit text-navy"></i></a>';
                            }
                        },
                        
                    
                    ]
                });
    }

    self.initButtons = function (_self) {
        $("body").off("click");
        $("body").on("click", "#btnupdaterequest", function () {

            self.Update();
       
        });

        $("body").on("click", ".editpopup", function () {
            $("#modaledititem").modal('show');

            var itemDT = $("#dtrequestitems").DataTable();
            var rowElem = $(this).closest('tr');
            var data = itemDT.row($(rowElem)).data();

            _self.TargetRow = rowElem;

            $("#sel2itemstatus").val(data.itemRequestStatusId).trigger('change');
            $("#approvedquantity").val(data.approvedQuantity);
            $("#approvedamount").val(data.approvedAmount);
            $("#itemremarks").val(data.remarks);
            $("#approvalno").val(data.approvalNo);

        });

        $("body").on("click", "#btnupdaterowdata", function () {
            var itemDT = $("#dtrequestitems").DataTable();
            var data = itemDT.row($(_self.TargetRow)).data();

            data.remarks = $("#itemremarks").val();
            data.approvalNo = $("#approvalno").val();
            data.itemRequestStatusId = $("#sel2itemstatus").select2('data')[0].id;
            data.itemRequestStatus = $("#sel2itemstatus").select2('data')[0].text;
            data.approvedQuantity = $("#approvedquantity").val();
            data.approvedAmount = $("#approvedamount").val();

            itemDT.row($(_self.TargetRow)).data(data);

            $("#modaledititem").modal('hide');

        });

        $("body").on("click", "#backtolist", function () {
            loadViewAjax('/file/approvalrequest','Approval Request');
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
                console.log(data.clincalData);
                if ((data.processById == 0 && data.requestStatusId != 3)  || (data.processById == $("#currentuserid").val() && data.requestStatusId == 2)) {
                    $("#btnupdaterequest").show();
                } else {
                    $("#btnupdaterequest").hide();
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

    self.initItemRequestStatus = function () {
        $.ajax({
            url: base.ApplicationBasePath() +"/api/ApprovalRequestItemStatus",
            type: "GET",
            success: function (data) {
                mappedData = $.map(data, function (item) {
                    return {
                        id: item.id,
                        text: item.name
                    }
                });

                $("#sel2itemstatus").select2({ data: mappedData });

            }, error: function (data) {
                console.log(data);

            }
        });

    }

    self.Update = function () {

        var requestid = $("#requestid").html();;
        var url = base.ApplicationBasePath()+"/api/approvalrequest/" + requestid;

        var tableobj = $("#dtrequestitems").DataTable();
        var model = {};

        model.Id = requestid;
        model.requestItems = [];
        model.stationId = base.GetStation().Id;

        tableobj.rows().eq(0).each(function (index) {
            var row = tableobj.row(index);
            model.requestItems.push(row.data());
          
        });
        console.log(model.requestItems);
     
        $.ajax({
            url: url,
            type: "PUT",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(model),
            success: function (data) {
                self.GetApprovalRequestDetail();

                swal('Notification', 'Successfully updated', 'success', 3000);
            }, error: function (data) {
                swal('Notification', 'Cannot update', 'error', 3000);
                console.log(data);
            }
        });

    }

}