angular.module('HomeApp', [])
    .controller('HomeController', function ($scope, $http) {

        $scope.search = function () {

            var code = $("#txtSearch").val();
            var StartDate = $("#datetimepicker1").val();
            var FinishDate = $("#datetimepicker2").val();

            $http({
                method: "POST",
                url: "/Home/Search",
                headers: { "Content-Type": "Application/json;charset=utf-8" },
                data: { code: code, Start: StartDate, Finish: FinishDate }
            }).then(function (response) {
                $scope.searchList = response.data;
            });
        };



        $scope.excel = function () {


            if ($scope.searchList.length > 0) {
                var newData = [];
                $scope.searchList.forEach(function (e) {

                    newData.push({
                        "SiraNo": e.Id,
                        "IslemTur": e.ProcessType,
                        "EvrakNo": e.DocumentNo,
                        "Tarih": e.Date,
                        "GirisMiktar": e.EntryQuantity,
                        "CikisMiktar": e.OutputQuantity,
                        "Stok": e.Stock
                    });
                });

                var ws = XLSX.utils.json_to_sheet(newData, {
                    header: [
                        "SiraNo",
                        "IslemTur",
                        "EvrakNo",
                        "Tarih",
                        "GirisMiktar",
                        "CikisMiktar",
                        "Stok"
                    ]
                });

                //Set Columns Size !
                var wscols = [{ wch: 10 }, { wch: 15 }, { wch: 15 }, { wch: 20 }, { wch: 20 }, { wch: 20 }, { wch: 20 }, { wch: 20 }];
                ws['!cols'] = wscols;

                var wb = XLSX.utils.book_new();
                XLSX.utils.book_append_sheet(wb, ws, "stok");


                XLSX.utils.shee;
                var wbout = XLSX.write(wb, { bookType: 'xlsx', type: 'binary' });
                saveAs(new Blob([fireGenerateBlobData(wbout)], { type: "application/octet-stream" }), "stok.xlsx");
            }
        };




        $(document).ready(function () {
           
        });



    });