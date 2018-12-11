function Home() {
    self = this;

    self.init = function () {

        var today = moment(new Date()).format("DD-MMM-YYYY");

        var fromweeklydate = moment(new Date()).day("Sunday").format('DD-MMM-YYYY');
        var toweeklydate = moment(new Date()).day("Saturday").format('DD-MMM-YYYY');

        $("#weekstart").html(moment(fromweeklydate).format("D MMM, YYYY"));
        $("#weekend").html(moment(toweeklydate).format("D MMM, YYYY"));

        self.GetStatistics(today, today).then(function (data) {

            self.setTodayStatistics();
            console.log(data);

        });

        self.GetStatistics(fromweeklydate, toweeklydate).then(function (data) {

            self.setWeeklyStatistics(data);
  
        });


       
    }

    self.setWeeklyStatistics = function (data) {

        var labels = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Saturday"];

        var underprocess = [0, 0, 0, 0, 0, 0, 0];
        var forapproval = [0, 0, 0, 0, 0, 0, 0];
        var done = [0, 0, 0, 0, 0, 0, 0];

        var underprocesscount = 0;
        var forapprovalcount = 0;
        var donecount = 0;
        var totalcount = 0;

        var inpatientcount = 0;
        var outpatientcount = 0;
        var totalpatientcount = 0;

        $.each(data, function (index, item) {
            underprocess[(new Date(item.date)).getDay()] = item.underProcessCount;
            forapproval[(new Date(item.date)).getDay()] = item.forApprovalCount;
            done[(new Date(item.date)).getDay()] = item.doneCount;

            underprocesscount += item.underProcessCount;
            forapprovalcount += item.forApprovalCount;
            donecount += item.doneCount;

            outpatientcount += item.outPatientCount;
            inpatientcount += item.inPatientCount;
           
        });
        totalcount = underprocesscount + forapprovalcount + donecount;
        totalpatientcount = outpatientcount + inpatientcount;

        $("#forapprovalpercentage").html((Math.floor(forapprovalcount / totalcount * 100)) + "%");
        $("#inprocpercentage").html((Math.floor(underprocesscount / totalcount * 100)) + "%");
        $("#donepercentage").html((Math.floor(donecount / totalcount * 100)) + "%");
        $("#inproccount").html(underprocesscount);
        $("#forapprovalcount").html(forapprovalcount);
        $("#donecount").html(donecount);
        $("#totalcount").html(totalcount);

        $("#inpatientpercentage").html((Math.floor(inpatientcount / totalpatientcount * 100)) + "%");
        $("#outpatientpercentage").html((Math.floor(outpatientcount / totalpatientcount * 100)) + "%");
        $("#totalpatients").html(totalpatientcount);
       


        var ctx = document.getElementById("weeklyrecap").getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Saturday"],
                datasets: [
                    {
                        label: 'For Approval', data: forapproval, borderColor: "orange"
                        //, fill: 'start'
                        //, backgroundColor: "#f3e4ca"
                    },
                    {
                        label: 'Under Process', data: underprocess, borderColor: "#36a2eb"
                        //, fill: 'start'
                        //, backgroundColor: "#cfe8f9"
                    },
                    {
                        label: 'Done', data: done
                        //, fill: 'start'
                        , borderColor: "#00a65a"
                        //, backgroundColor: "#dff7df"
                    }
                ]
            }
        });
    }

    self.setTodayStatistics = function (data) {

    }


    self.GetStatistics = function (from, to) {
        return new Promise(function (resolve) {
            $.get(base.ApplicationBasePath() + "/api/approvalrequest/status/statistics/" + from + "/" + to).done(function (data) {
                resolve(data);
            });
        });
    }

}