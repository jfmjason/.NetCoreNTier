function ApprovalReleaseProcess() {
    self = this;

    self.init = function () {

        self.initButtons();
        self.initInputs();
        self.initSelect2();
    }

    self.initInputs = function () {
        $("#searchid").focus();
        $("#searchid").unbind("keyup").keyup(function (e) {
            if (e.keyCode == 13) {
                self.SearchRequest();
            }
        });
    }
    self.initButtons = function () {
       
        $("body").off('click');

        $("body").on("click","#btnsearch",function () {
            self.SearchRequest();
        });

      $("body").on("click","#btnclear", function () {
            self.Clear();
        });

       $("body").on("click","#btnrelease", function () {
            self.Update();
        });
        
    };

    self.initSelect2 = function () {

        $("#assignto").select2({
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
                            url: base.ApplicationBasePath() +"/api/approvalrequest/release/" + $("#requestid").val(),
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
                url: base.ApplicationBasePath() +"/api/approvalrequest/" + $("#searchid").val(),
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


   

}