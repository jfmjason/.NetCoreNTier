function ApprovalRequestType() {
    self = this;

    self.init = function () {
        debugger;
        self.SetUpTable();
        self.initButtons();
        self.TableRowClick();
    }

    self.SetUpTable = function () {
        $.ajax({
            url: base.ApplicationBasePath() +"/api/approvalrequesttype",
            success: function (data) {
                $("#data-items").DataTable({
                    data: data,
                    destroy: true,
                    language: {
                        search: "Filter : ",
                        searchPlaceholder: "Type here..."
                    },
                    dom: 'bfrip',

                    lengthMenu: [15, 30, 100] ,
                    columns: [
                        {
                            data: "id", title: "No.", width: "5%", searchable: false, orderable: true ,class:"text-center"
                            , render: function (nrow, display, data, tblsettings) {
                                return tblsettings.row+1;
                            }
                        },
                        { data: "name", title: "Description", width: "50%",  searchable: true, orderable: true },
                        { data: "code", title: "Code", width: "45%", searchable: true, orderable: true },

                    ]
                });

                $("#data-items_filter label").append("<button id='btnClearFilter' class='btn btn-sm btn-default' style='margin-left:10px;'><i class='fa fa-eraser'/> Clear </button>");
                $("#data-items_filter label").append("<button id='btnRefresh' class='btn btn-sm btn-primary' style='margin-left:10px;'><i class='fa fa-refresh '/> Refresh </button>");

            }
        });
    }

    self.initButtons = function () {
        $("#deleteentry").hide();
        $("#newentry").hide();
        $("#updateentry").hide();

        $("body").off("click");

        $("body").on("click","#newentry",function () {
            self.Clear();
            $("#description").focus();
            $("#clearentry").show();
            $("#saveentry").show();
            
            $("#deleteentry").hide();
            $("#newentry").hide();
            $("#updateentry").hide();
        });

        $("body").on("click","#saveentry",function () {
            self.Create();
        });

        $("body").on("click","#updateentry",function () {
            self.Update();
        });


        $("body").on("click","#deleteentry",function () {
            self.Delete();
        });

        $("body").on("click","#clearentry",function () {
            self.Clear();
            $("#description").focus();
        });


        $("body").on("click", "#btnClearFilter", function () {
            $("#data-items_filter input").val('').trigger("keyup");

        });

        $("body").on("click", "#btnRefresh", function () {
            self.SetUpTable();
        });


        
    };

    self.Clear = function () {

        $("#requesttypesid").val(0);
        $("#description").val("");
        $("#code").val("");

    }

    self.Create = function () {

        if (self.Validate()) {
            model = { name: $("#description").val(), code: $("#code").val() }

            $.ajax({
                url: base.ApplicationBasePath() +"/api/approvalrequesttype",
                type: "post",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(model),
                success: function (response) {
                    self.Clear();
                    self.SetUpTable();

                    swal({ title: "Notification", html: "Successfuly added", timer: 2000, type: "success" });
                }, error: function (e) {
                    console.log(e);
                }
            })
        }

    }

    self.Update = function () {
        if (self.Validate()) {
            swal({
                title: 'Confirmation',
                html: 'Are you sure you want to update this record?',
                showCancelButton: true,
                cancelButtonText: 'No',
                confirmButtonText: 'Yes',
                showLoaderOnConfirm: true,
                preConfirm: function () {
                    return new Promise(function (resolve, reject) {

                        model = { id: $("#requesttypesid").val(), name: $("#description").val(), code: $("#code").val() }
                        $.ajax({
                            url: base.ApplicationBasePath() +"/api/approvalrequesttype/" + $("#requesttypesid").val(),
                            type: "PUT",
                            contentType: "application/json",
                            dataType: "json",
                            data: JSON.stringify(model),
                            success: function (response) {
                                self.Clear();
                                self.SetUpTable();
                                $("#clearentry").show();
                                $("#saveentry").show();

                                $("#deleteentry").hide();
                                $("#newentry").hide();
                                $("#updateentry").hide();
                                resolve(response);
                            }, error: function (e) {

                                console.log(e);
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
    }

    self.Delete = function () {
        swal({
            title: 'Confirmation',
            html: 'Are you sure you want to delete this record?',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Yes',
            showLoaderOnConfirm: true,
            preConfirm: function () {
                return new Promise(function (resolve, reject) {
                  
                    $.ajax({
                        url: base.ApplicationBasePath() +"/api/approvalrequesttype/" + $("#requesttypesid").val(),
                        type: "DELETE",
                        contentType: "application/json",
                        dataType: "json",
                        success: function (response) {
                            self.Clear();
                            self.SetUpTable();

                            $("#clearentry").show();
                            $("#saveentry").show();

                            $("#updateentry").hide();
                            $("#deleteentry").hide();
                            $("#newentry").hide();
                            resolve(response);
                        }, error: function (e) {

                            console.log(e);
                            reject("Delete failed");

                        }
                    })
                })
            },
        }).then((result) => {

            if (result.value) {
                swal('Notification', 'Successfully deleted', 'success', 3000);
            } else {
                return;
            }
        });


    }

    self.Validate = function () {
        var message = [];

        if ($.trim($("#description").val()) == "") {
            message.push("Description is required");
        }

        if ($.trim($("#code").val()) == "") {
            message.push("Code is required");
        }

        if (message.length > 0) {
            messagedisplay = "";
            $.each(message, function (index, item) {

                messagedisplay += "<p class='text-red'  >" + item + "</p>"
            });
            swal({ title: "Validation Error", html: messagedisplay, type: "error" });
            
        }

        return message.length == 0;
    }

    self.TableRowClick = function () {
        $("#data-items").on('click', ' tbody tr[role="row"]', function () {

            var itemDT = $("#data-items").DataTable();

            var data = itemDT.row($(this)).data();

            $("#requesttypesid").val(data.id);
            $("#description").val(data.name);
            $("#code").val(data.code);


            $("#clearentry").show();
            $("#saveentry").hide();

            $("#deleteentry").show();
            $("#newentry").show();
            $("#updateentry").show();

        });
    }
}