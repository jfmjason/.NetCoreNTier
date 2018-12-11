function BillingApprovalCreate() {
    self = this;

    self.init = function () {
        self.initButtons(self);
        self.initInputs();
        self.initSelect2();
        self.setTestProceduresDT([]);
    }

    self.initInputs = function () {
        $("#searchid").focus();
        $("#searchid").unbind("keyup").keyup(function (e) {
            if (e.keyCode == 13) {
                self.SearchRequest();
            }
        });

        $("#quantity").unbind("change").change(function () {
            var price = $("#price").val();
            var quantity = $(this).val();;
            var amount = (price * quantity).toFixed(2);

            $("#amount").val(amount);

            if (quantity > 0 && $("#serviceitemid").val() > 0) {
                $("#btnupdateitem").removeAttr("disabled");
                $("#btnadditem").removeAttr("disabled");
            } else {
                $("#btnupdateitem").attr("disabled", true);
                $("#btnadditem").attr("disabled", true);
            }

        });

    }

    self.initButtons = function (_self) {

        $("body").off('click');

        $("body").on("click", "#btnsearch", function () {
            self.SearchRequest();
        });

        $("body").on("click", "#btnclear", function () {
            self.Clear();
        });

        $("body").on("click", "#btnrelease", function () {
            self.Update();
        });

        $("body").on("click", "#btnadditem", function () {

            var dttable = $("#tbltestprocedures").DataTable();

            var itemdata = $("#serviceitemid").select2('data')[0];
            var unitdata = $("#unitid").select2('data')[0];
            var servicedata = $("#opipserviceid").select2('data')[0];

            dttable.row.add({
                itemId: itemdata.id,
                itemName: itemdata.text,
                price: $("#price").val(),
                quantity: $("#quantity").val(),
                amount: $("#amount").val(),
                unitId: unitdata.id,
                unitName: unitdata.text,
                serviceId: servicedata.id,
                remarks: $("#itemremarks").val(),
              

            }).draw();

            $("#modalitem").modal('hide');
        
        });

        $("body").on("click", ".removepopup", function () {

            var dttable = $("#tbltestprocedures").DataTable();
            var row = $(this).closest("tr");

            dttable.row(row).remove().draw();
        });

        $("body").on("click", ".editpopup", function () {

            var dttable = $("#tbltestprocedures").DataTable();
            var row = $(this).closest("tr");

            var rowdata = dttable.row(row).data();
            var rownumber = dttable.row(row).index();
            rowdata.rownumber = rownumber;

            _self.ShowModal(rowdata);

        });

        $("body").on("click", "#btnupdateitem", function () {

            var dttable = $("#tbltestprocedures").DataTable();
            var rownumber = $("#rownumber").val();
            var rowdata = dttable.row(rownumber).data();

            var itemdata = $("#serviceitemid").select2('data')[0];
            var unitdata = $("#unitid").select2('data')[0];
            var servicedata = $("#opipserviceid").select2('data')[0];

            rowdata.itemId = itemdata.id;
            rowdata.itemName = itemdata.text;
            rowdata.price = $("#price").val();
            rowdata.quantity = $("#quantity").val();
            rowdata.amount = $("#amount").val();
            rowdata.unitId = unitdata.id;
            rowdata.unitName = unitdata.text;
            rowdata.serviceId = servicedata.id;
            rowdata.remarks = $("#itemremarks").val();

            dttable.row(rownumber).data(rowdata).invalidate();

            $("#modalitem").modal('hide');

        });

        $("body").on("click", "#btnremoveitem", function () {

            var dttable = $("#tbltestprocedures").DataTable();
            var rownumber = $("#rownumber").val();

            dttable.row(rownumber).remove().draw();
            $("#modalitem").modal('hide');
        });

        $("body").on("click", "#createnew", function () {

            $("#ipregistrationno").val(null).trigger('change');
            $("#opregistrationno").val(null).trigger('change');

            $("#companyid").html('').select2('data', null);
            $("#categoryid").html('').select2('data',null);
            $("#gradeid").html('').select2('data', null );
            $("#doctorid").val(null).trigger('change');
            $("#contactnos").val("");
            $("#insurancecardno").val("");
            $("#authorityid").val("");

            $("#popupitemheader").html("  ADD ITEM");
            $("#serviceitemid").html('').select2('data', null);
            $("#price").val("0.00");
            $("#quantity").val(1);
            $("#amount").val("0.00");
            $("#unitid").val(73).trigger('change');
            $("#itemremarks").val("");
            $("#rownumber").val(0);

            $("#btnremoveitem").hide();
            $("#btnupdateitem").hide();
            $("#btnadditem").show();
            $("#btnadditem").attr("disabled", true);

            $("#tbltestprocedures").DataTable().clear().draw();

            stepper.reset();
        });

        $("body").on("click", "#backtolist", function () {
            loadViewAjax("/file/approvalrequest/list", 'Approval Request List');
        });
    };

    self.initSelect2 = function () {
      
        $("#categoryid").select2({ data: null });
        $("#companyid").select2({ data: null });
        $("#gradeid").select2({ data: null });

        self.setRequestTypeSelect2();
        self.setPatientTypeSelect2(self);
        self.setInPatientSelect2(self);
        self.setOutPatientSelect2(self);
        self.setDoctorSelect2(self);
        self.setUnitSelect2();
        $("#opregistrationno").parent().hide();
    }

    self.setRequestTypeSelect2 = function () {
        self.GetRequestType().then(function (data) {
            var mapped = $.map(data, function (item) {
                return {
                    id: item.id,
                    text: item.code + " - " + item.name
                };
            });
            $("#approvalrequesttypeid").select2({
                data: mapped
            });
        })
    }

    self.setPatientTypeSelect2 = function (_self) {
        self.GetPatientType().then(function (data) {
            var mapped = $.map(data, function (item) {
                return {
                    id: item.id,
                    text: item.name
                };
            });

            $("#patienttypeid").select2({
                data: mapped
            }).on("change", function (e) {
                var typeid = $(e.currentTarget).val();

                if (typeid == 1) {
                    $("#ipregistrationno").parent().show();
                    $("#opregistrationno").parent().hide();

                    $("#ipregistrationno").val(null).trigger('change');

                } else {
                    $("#ipregistrationno").parent().hide();
                    $("#opregistrationno").parent().show();
                    $("#opregistrationno").val(null).trigger('change');
                }

                $("#companyid").html('').select2({ data: null });
                $("#categoryid").html('').select2({ data: null });
                $("#gradeid").html('').select2({ data: null });
                $("#doctorid").val(null).trigger('change');
                $("#contactnos").val("");
                $("#insurancecardno").val("");
                $("#authorityid").val("");

                _self.setServicesSelect2(_self);
                $("#tbltestprocedures").DataTable().clear().draw();
            });
            _self.setServicesSelect2(_self);
        });
    }

    self.setInPatientSelect2 = function (_self) {
        self.GetCurrentInPatients().then(function (data) {
            var mapped = $.map(data, function (item) {
                return {
                    id: item.registrationNo,
                    text: item.pin + "  -  " + item.name,
                    ipid: item.ipId,
                    doctorid: item.doctorId,
                    bedtypeid: item.bedTypeId
                };
            });

            $("#ipregistrationno").select2({
                allowClear: true,
                placeholder: "Select Patient",
                data: mapped
            }).on("change", function (e) {
                $("#tbltestprocedures").DataTable().clear().draw();
                var data = $(e.currentTarget).select2('data');
             
                if (data.length > 0) {

                    data = data[0];

                    self.GetPatientByRegistrationNo(data.id).then(function (patient) {
                        
                        _self.GetCategory(patient.categoryId).then(function (item) {
                            $("#categoryid").html('').select2({ data: [{ id: item.id, text: item.name }] });
                        });
                        _self.GetCompany(patient.companyId).then(function (item) {
                            $("#companyid").html('').select2({ data: [{ id: item.id, text: item.name, tariffid: item.tariffId }] });
                        });
                        _self.GetGrade(patient.gradeId).then(function (item) {
                            $("#gradeid").html('').select2({ data: [{ id: item.id, text: item.name }] });
                        });
                        $("#contactnos").val(patient.contactNo);
                        $("#insurancecardno").val(patient.insuranceCardNo);
                    });
                } else {
                    $("#companyid").html('').select2({ data: null });
                    $("#categoryid").html('').select2({ data: null });
                    $("#gradeid").html('').select2({ data: null });
                    $("#contactnos").val("");
                    $("#insurancecardno").val("");
                    $("#authorityid").val(""); 
                }
            });

            $("#ipregistrationno").val(null).trigger('change');
        })
    }

    self.setOutPatientSelect2 = function (_self) {
        $("#opregistrationno").select2({
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
        }).on("change", function (e) {
            var data = $(e.currentTarget).select2('data');
            $("#tbltestprocedures").DataTable().clear().draw();
            if (data.length > 0) {

                data = data[0];

                _self.GetCategory(data.categoryid).then(function (item) {
                    $("#categoryid").html('').select2({ data: [{ id: item.id, text: item.name }] });
                });
                _self.GetCompany(data.companyid).then(function (item) {
                    $("#companyid").html('').select2({ data: [{ id: item.id, text: item.name, tariffid: item.tariffId }] });
                });
                _self.GetGrade(data.gradeid).then(function (item) {
                    $("#gradeid").html('').select2({ data: [{ id: item.id, text: item.name }] });
                });

                _self.GetLatestOPCompanybillDetail(data.id).then(function (item) {
                    $("#authorityid").val(item.authorityId);
                });

                if (data.doctorid > 0) {
                    self.GetEmployeeById(data.doctorid).then(function (item) {
                        var option = new Option(item.code + " - " + item.name, data.id, true, true);
                        $("#doctorid").append(option).trigger('change');

                        $("#doctorid").trigger({
                            type: 'select2:select',
                            params: {
                                data: { id: item.id, text: item.code + " - " + item.name }
                            }
                        });
                    });
                } else {
                    $("#doctorid").html('').select2('data', null);
                }

                $("#contactnos").val(data.contactno);
                $("#insurancecardno").val(data.insurancecardno);

            } else {
                $("#companyid").html('').select2({ data: null });
                $("#categoryid").html('').select2({ data: null });
                $("#gradeid").html('').select2({ data: null });
                $("#contactnos").val("");
                $("#insurancecardno").val("");
                $("#authorityid").val("");
                $("#doctorid").html('').select2('data', null);
            }
            });

    }

    self.setServiceItemsSelect2 = function (_self) {
        var url = base.ApplicationBasePath() + "/api/";
        var patientType = $("#patienttypeid").val();
        var mastertable = $("#opipserviceid").select2('data')[0].mastertable;

        if (patientType == 1)
            url += "ipbserviceitem/pagedsearch";
        else 
            url += "opbserviceitem/pagedsearch";

        $("#serviceitemid").html('').select2({
            placeholder: "Search item / procedure",
            minimumInputLength: -1,
            allowClear: true,
            ajax: {
                url: url,
                dataType: 'json',
                quietMillis: 250,
                data: function (params) {
                    return {
                        pagesize: 50,
                        page: params.page || 1,
                        term: params.term,
                        mastertable: $.trim(mastertable)
                    };
                },
                processResults: function (result, params) {

                    params.page = params.page || 1;

                    var mapped = $.map(result.data, function (item) {
                        return {
                            id: item.id,
                            text: ($.trim(item.code) == "" || $.trim(item.code) == $.trim(item.name) ? "" : "" + item.code + "   -   ") + item.name
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
        }).on("change", function (e) {
            var data = $(e.currentTarget).select2('data');
            if (data.length > 0) {
                _self.GetServicesItemPrice().then(function (data) {
                    var price = data ? data.price.toFixed(2) : "0.00";
                    var quantity = 1;
                    var amount = (price * quantity).toFixed(2);

                    $("#price").val(price);
                    $("#quantity").val(quantity);
                    $("#amount").val(amount);

                    $("#btnadditem").removeAttr("disabled");
                    $("#btnupdateitem").removeAttr("disabled");
                });
            } else {
                $("#price").val("0.00");
                $("#quantity").val(0);
                $("#amount").val("0.00");

                $("#btnadditem").attr("disabled", true);
                $("#btnupdateitem").attr("disabled", true);
            }
        });

    }

    self.setTestProceduresDT = function (data) {

        $("#tbltestprocedures").DataTable({
            data: data,
            destroy: true,
            searching: false,
            dom: 'bfrip',
            lengthMenu: [10, 25, 50 ,100],
            columns: [

                {
                    data: null, title: "#", searchable: true, orderable: true, class: "text-vertical-middle padding-4 text-center text-navy padding-4"
                    , render: function (nrow, display, data, tblsettings) {
                        return "<b>" + (parseInt(tblsettings.row) + 1) + "</b>";
                    }

                },
                { data: "itemName", title: "Item", searchable: true, orderable: true, class: "text-vertical-middle padding-4", width: "20%" },
                { data: "price", title: "Price", searchable: true, orderable: true, class: "text-vertical-middle padding-4 text-right" },
                { data: "quantity", title: "Quantity",  searchable: true, orderable: true, class: "text-vertical-middle text-center padding-4" },
                { data: "unitName", title: "Unit", searchable: true, orderable: true, class: "text-vertical-middle padding-4" },
                { data: "amount", title: "Amount", searchable: true, orderable: true, class: "text-vertical-middle text-right td-decimal padding-4 text-right" },
                {
                    data: "remarks", title: "Remarks", searchable: true, orderable: false, class: "text-vertical-middle padding-4 text-left" ,  render: function (data) {

                        return data ? data.substring(0, 30) + (data.trim().length >= 30? "...":""): "N/A";
                            
                    }
                },
              
                {
                    data: null, title: "Action",  searchable: true, orderable: false, class: "text-vertical-middle padding-4 text-center",
                    render: function (nrow, display, data, tblsettings) {

                        $(nrow).data("rownumber", tblsettings.row )

                        return '<a class="btn btn-sm btn-default editpopup" > <i class="fa fa-edit text-navy"></i></a>'
                             + '<a class="btn btn-sm btn-default removepopup" style="margin-left:5px"> <i class="fa fa-trash-o text-danger"></i></a>';
                    }
                },


            ]
        });
    };

    self.setServicesSelect2 = function (_self) {
        _self.GetServices().then(function (data) {
            var mapped = $.map(data, function (item) {
                return {
                    id: item.id,
                    text: item.name,
                    mastertable: item.masterTable,
                    pricetable: item.priceTable
                };
            });

            $("#opipserviceid").html('').select2({
                data: mapped
            }).on("change", function (e) {
                _self.setServiceItemsSelect2(_self);

                $("#price").val("0.00");
                $("#quantity").val(0);
                $("#amount").val("0.00");
            });

            _self.setServiceItemsSelect2(_self);
        });
    };

    self.setDoctorSelect2 = function (_self) {
        $("#doctorid").select2({
            placeholder: "Search Doctor",
            minimumInputLength: -1,
            allowClear: true,
            ajax: {
                url: base.ApplicationBasePath() + "/api/employee/doctor/search/",
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

    self.setUnitSelect2 = function () {
        self.GetUnits().then(function (data) {

            var mapped = $.map(data, function (item) {
                return {
                    id: item.id,
                    text: item.name
                };
            });

            $("#unitid").select2({
                data: mapped
            });

            $("#unitid").val(73).trigger('change');
        });
    };

    self.ShowModal = function (data) {

        $("#modalitem").modal('show');
        $("#btnadditem").attr('disabled', true);

        if (data) {
            $("#popupitemheader").html("  EDIT ITEM");

            var option = new Option(data.itemName, data.itemId, true, true);
            $("#opipserviceid").val(data.serviceId).trigger('change');
            $("#serviceitemid").append(option).trigger({
                type: 'select2:select',
                params: {
                    data: { id: data.itemId, text: data.itemName }
                }
            });
            $("#price").val(data.price);
            $("#quantity").val(data.quantity);
            $("#amount").val(data.amount);
            $("#unitid").val(data.unitId).trigger('change');
            $("#itemremarks").val(data.remarks);
            $("#rownumber").val(data.rownumber);

            $("#btnremoveitem").show();
            $("#btnupdateitem").show();
            $("#btnadditem").hide();
            $("#btnupdateitem").removeAttr("disabled");

        } else {
            $("#popupitemheader").html("  ADD ITEM");
            $("#serviceitemid").html('').select2('data', null);
            $("#price").val("0.00");
            $("#quantity").val(1);
            $("#amount").val("0.00");
            $("#unitid").val(73).trigger('change');
            $("#itemremarks").val("");
            $("#rownumber").val(0);

            $("#btnremoveitem").hide();
            $("#btnupdateitem").hide();
            $("#btnadditem").show();
            $("#btnadditem").attr("disabled", true);

        }
    };

    self.Clear = function () {

        $("#searchid").val("");
        $("#requesttype").val("");
        $("#processowner").val("");
        $("#status").val("");
        $("#requestid").val("");
        $(".releasedetail").hide();

        $("#assignto").val("");

        $("#assignto").val(null).trigger('change');

        $("#btnrelease").hide();
    }

    self.Update = function () {

        swal({
            title: 'Confirmation',
            html: 'Are you sure you want to release this process?',
            input: 'text',
            inputAttributes: {
                autocapitalize: 'on',
                placeholder: "Type remarks"
            },
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Yes',
            showLoaderOnConfirm: true,
            preConfirm: function (remarks) {
                return new Promise(function (resolve, reject) {

                    model = {
                        requestId: $("#requestid").val(),
                        assignToEmployeeId: $("#assignto").val(),
                        stationId: base.GetStation().Id,
                        remarks: remarks
                    }
                    $.ajax({
                        url: base.ApplicationBasePath() + "/api/approvalrequest/release/" + $("#requestid").val(),
                        type: "PUT",
                        contentType: "application/json",
                        dataType: "json",
                        data: JSON.stringify(model),
                        success: function (response) {

                            if ($("#assignto").val() == null) {
                                $("#processowner").val("");
                                $("#btnrelease").hide();
                            } else {

                                $("#processowner").val($("#assignto").select2('data')[0].text);
                            }

                            $("#assignto").val(null).trigger('change');

                            resolve(response);
                        }, error: function (e) {


                            reject("Delete failed");

                        }
                    })
                })
            },



        }).then((result) => {

            if (result.value) {
                swal('Notification', 'Successfully updated', 'success', 3000);
            } else {
                return;
            }
        });


    }

    self.SearchRequest = function () {

        if ($.trim($("#searchid").val()) != "") {
            $.ajax({
                url: base.ApplicationBasePath() + "/api/approvalrequest/" + $("#searchid").val(),
                type: "GET",
                beforeSend: function () {
                    _spinner.spin($("#releasecontent")[0]);
                },
                success: function (data) {
                    if (data.id > 0) {
                        $("#requesttype").val(data.requestType);
                        $("#processowner").val(data.processBy);
                        $("#status").val(data.requestStatus);
                        $("#requestid").val(data.id);
                        $(".releasedetail").show();

                        $("#pin").html(data.pin);
                        $("#patientname").html(data.patientName);
                        $("#insuranceno").html(data.insuranceCardNo);
                        $("#requesteddate").html(moment(data.requestDate).format("MMM DD, YYYY hh:mm A"));
                        $("#processdate").html(data.processDate !== null ? moment(data.processDate).format("MMM DD, YYYY hh:mm A") : "<label class='label label-danger'>NOT PROCESS YET</label>");
                        $("#category").html(data.categoryName);
                        $("#company").html(data.companyName);
                        $("#grade").html(data.gradeName);
                        $("#doctor").html(data.doctorCode + " - " + data.doctorName);

                        if (data.requestStatusId == 2 && data.processById > 0) {
                            $("#btnrelease").show();
                        } else {
                            $("#btnrelease").hide();
                        }

                    } else {

                        swal({ title: "Response Notification", html: "Request not found", type: "info", timer: 3000 });
                        $("#requesttype").val("");
                        $("#processowner").val("");
                        $("#status").val("");
                        $("#requestid").val("");
                        $(".releasedetail").hide();
                        $("#btnrelease").hide();
                    }

                }, error: function (xhr, status, message) {

                    console.log(xhr);
                }, complete: function () {
                    _spinner.stop();
                }
            });
        }
    };

    self.GetRequestType = function () {
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/approvalrequesttype").done(function (data) {
                resolve(data);
            });
        });
    }

    self.GetPatientType = function () {
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/patienttype").done(function (data) {
                resolve(data);
            });
        });
    }

    self.GetCurrentInPatients = function () {
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/inpatient/current").done(function (data) {
                resolve(data);
            });
        });
    }

    self.GetCompany = function (id) {
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/company/" + id).done(function (data) {
                resolve(data);
            });
        });
    }

    self.GetCategory = function (id) {
        debugger;
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/category/" + id).done(function (data) {
                resolve(data);
            });
        });
    }

    self.GetGrade = function (id) {
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/grade/" + id).done(function (data) {
                resolve(data);
            });
        });
    }

    self.GetLatestOPCompanybillDetail = function (registrationNo) {
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/OpCompanyBillDetail/latest/registrationno/" + registrationNo).done(function (data) {
                resolve(data);
            });
        });
    }

    self.GetPatientByRegistrationNo = function (registrationNo) {
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/patient/registrationno/" + registrationNo).done(function (data) {
                resolve(data);
            });
        });
    }

    self.GetEmployeeById = function (id) {
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/employee/" + id).done(function (data) {
                resolve(data);
            });
        });
    }

    self.GetServices = function () {

        var patientType = $("#patienttypeid").val();

        if (patientType == 1) {
            return new Promise(function (resolve, reject) {
                $.get(base.ApplicationBasePath() + "/api/ipbservice").done(function (data) {
                    resolve(data);
                });
            });
        } else {
            return new Promise(function (resolve, reject) {
                $.get(base.ApplicationBasePath() + "/api/opbservice").done(function (data) {
                    resolve(data);
                });
            });
        }
       
    }

    self.GetServicesItemPrice = function () {

        var patientType = $("#patienttypeid").val();

        if (patientType == 1) {
            return new Promise(function (resolve, reject) {
                debugger;
                var url = base.ApplicationBasePath() + "/api/ipbserviceitem/getprice";
                var companydata = $("#companyid").select2('data')[0]
                var servicedata = $("#opipserviceid").select2('data')[0]
                var inpatientdata = $("#ipregistrationno").select2('data')[0];
                var itemid = $("#serviceitemid").val();
                var tariffid = companydata.tariffid;
                var pricetable = servicedata.pricetable;

                url += "/item/" + itemid;
                url += "/tariff/" + tariffid;
                url += "/bedtype/" + inpatientdata.bedtypeid;
                url += "/pricetable/" + pricetable;

                $.get(url).done(function (data) {
                    resolve(data);
                });
            });
        }
        else {
            return new Promise(function (resolve, reject) {
                var url = base.ApplicationBasePath() + "/api/opbserviceitem/getprice/";
                var companydata = $("#companyid").select2('data')[0]
                var servicedata = $("#opipserviceid").select2('data')[0]
                var itemid = $("#serviceitemid").val();
                var tariffid = companydata.tariffid;
                var pricetable = servicedata.pricetable;

                url += "/item/" + itemid;
                url += "/tariff/" + tariffid;
                url += "/pricetable/" + pricetable;
 
                $.get(url).done(function (data) {
                    resolve(data);
                });
            });
        }

    }

    self.GetUnits = function () {
        return new Promise(function (resolve, reject) {
            $.get(base.ApplicationBasePath() + "/api/unit").done(function (data) {
                resolve(data);
            });
        });
     }

    self.ProceedToItem = function () {
        var validationmsg = $("<ul class='text-error'>");
        var invalidcount = 0;

        if ($("#categoryid").val() == null) {
            invalidcount++;
            validationmsg.append("<li>" + "Patient is required" + "</li>");
        }

        if ($("#doctorid").val() == null) {
            invalidcount++;
            validationmsg.append("<li>" + "Doctor is required" + "</li>");
        }

        if (invalidcount > 0) {

            swal({ type: "info", title: "STEP REQUIREMENT", html: validationmsg.html(), timer:3000 });
        }
        else {

            stepper.next();
        }


    }

    self.ConfirmSubmit = function (_self) {

        var itemCount = $("#tbltestprocedures").DataTable().data().count();

        if (itemCount > 0) {
            swal({
                title: 'Confirmation',
                html: 'Are you sure you want to submit this request',
                showCancelButton: true,
                cancelButtonText: 'No',
                confirmButtonText: 'Yes',
                showLoaderOnConfirm: true,
                preConfirm: function () {
                    return new Promise(function (resolve, reject) {

                        _self.SubmitRequest(reject).then(function (res) {
                            resolve();
                        });
                    })
                },



            }).then((result) => {

                if (result.value) {
                    stepper.next();
                } else {
                    swal('Notification', 'Cannot submit request', 'error', 3000);
                    return;
                }
            });
        } else {
            swal('VALIDATION REQUIREMENT', 'No item added', 'info', 3000);
        }
    }

    self.SubmitRequest = function (reject) {

        return new Promise(function( resolve){

            model = {
                RequestTypeId: $("#approvalrequesttypeid").val(),
                AuthorityId: $("#authorityid").val(),
                IPId: $("#patienttypeid").val() == 1 ? $("#ipregistrationno").select2('data')[0].ipid: null,
                CompanyId: $("#companyid").val(),
                CategoryId: $("#categoryid").val(),
                GradeId: $("#gradeid").val(),
                DoctorId: $("#doctorid").val(),
                PatientTypeId: $("#patienttypeid").val(),
                Registrationno: $("#patienttypeid").val() == 1 ? $("#ipregistrationno").val() : $("#opregistrationno").val(),
                TariffId: $("#companyid").select2('data')[0].tariffid,
                StationId: base.GetStation().Id,
                InsuranceCardNumber: $("#insurancecardno").val(),
                ContactNumber: $("#contactnos").val(),
                ClinicalData: $("#clinicaldata").val(),
                Items: $.map($("#tbltestprocedures").DataTable().rows().data(), function (item) { return item })

            }

            $.ajax({
                url: base.ApplicationBasePath() + "/api/approvalrequest",
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(model),
                success: function (response) {
                    resolve(response);
                }, error: function (e) {
                    reject("Request submission failed");
                }
            })
        });

    };
}