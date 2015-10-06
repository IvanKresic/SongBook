$scope.emplist = [];

$scope.load = function () {
    $.ajax({
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        url: '/Home/dohvatiPjesme',
        success: function (data) {
            $scope.emplist = data;
            $scope.$apply();
            console.log($scope.emplist);
        }
    });
}

$scope.load();