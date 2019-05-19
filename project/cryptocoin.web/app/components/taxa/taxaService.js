app.service("taxaService", ['$http', '$window', '$timeout', function ($http, $window, $timeout) {
    var urlBase = uriAPI + "cripto/";

    this.obterlistacriptomoedas = function () {
        return $http.get(urlBase + "obterlistacriptomoedas").then(function (response) { return response.data; });
    };

    this.obtertaxarecomendadabtc = function () {
        return $http.get(urlBase + "obtertaxarecomendadabtc").then(function (response) { return response.data; });
    };

    this.obtertaxas = function (model) {
        return $http.post(urlBase + "obtertaxaconversaocriptomoedas", model).then(function (response) { return response.data; });
    };
}]);