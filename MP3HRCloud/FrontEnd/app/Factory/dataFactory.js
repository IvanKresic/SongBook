
app.factory('dataFactory', ['$http', function ($http) {
    var dataFactory = {};

    dataFactory.getAllData = function (url) {
        return $http.get(url);
    };

    dataFactory.getDataById = function (url, id) {
        return $http.get(url + id);
    };

    dataFactory.getDataByName = function (url, name) {
        return $http.get(url + name);
    };

    dataFactory.addData = function (url, data) {
        return $http.post(url, data);
    }

    dataFactory.editData = function (url, data) {
        return $http.put(url, data);
    }

    dataFactory.deleteData = function (url) {
        return $http.delete(url);
    }

    return dataFactory;
}])